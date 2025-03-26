using System;
using System.Threading;
using System.Threading.Tasks;
using ChanelBotBoo.Models.Services.Telegram.AnswerLogic.Message;
using ChanelBotBoo.Models.Services.Telegram.AnswerLogic.MessageLogic;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Vostok.Logging.Abstractions;

namespace ChanelBotBoo.Models.Services.Telegram;

public class UpdateHandler (ILog logger, MessageAnswerFabric messageAnswerFabric) : IUpdateHandler
{
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
               messageAnswerFabric.GetMessageLogic(update.Message).getAnswerAsync();
                break;
        }
    }

    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source,
        CancellationToken cancellationToken)
    {
        logger.Error(exception, $"HandleError");
        return Task.CompletedTask;
    }
}