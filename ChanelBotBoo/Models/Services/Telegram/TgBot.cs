using System.Threading;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Vostok.Logging.Abstractions;

namespace ChanelBotBoo.Models.Services.Telegram;

public class TgBot (IUpdateHandler updateHandler, ITelegramBotClient bot, ILog logger) : IHostedService
{
    private static readonly ReceiverOptions receiverOptions = new()
    {
        AllowedUpdates =
        [
            UpdateType.Message,
            UpdateType.ChannelPost
        ]
    };

    private readonly CancellationTokenSource cts = new();

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            bot.StartReceiving(updateHandler.HandleUpdateAsync, updateHandler.HandleErrorAsync, receiverOptions, cts.Token);
            var botInfo = await bot.GetMe(cts.Token);
            logger.Info($"starting {botInfo.FirstName} service");
        }
        catch (Exception e)
        {
            logger.Error(e, "Failed to start tgservice");
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
         cts.Cancel();
         return Task.CompletedTask;
    }
}