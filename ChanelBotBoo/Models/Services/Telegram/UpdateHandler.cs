using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Vostok.Logging.Abstractions;

namespace ChanelBotBoo.Models.Services.Telegram;

public class UpdateHandler (ILog logger, IAsnwerService answerService) : IUpdateHandler
{
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                if (update.Message.IsAutomaticForward)
                {
                    await botClient.SendMessage(
                        chatId: update.Message.Chat.Id,
                        text: await answerService.getAnswerAsync(update.Message.Text),
                        replyParameters: update.Message.MessageId
                        );
                }
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