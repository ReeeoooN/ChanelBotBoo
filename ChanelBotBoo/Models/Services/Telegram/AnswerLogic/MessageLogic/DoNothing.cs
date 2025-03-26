using ChanelBotBoo.Models.Services.Telegram.AnswerLogic.MessageLogic;
using Telegram.Bot;
using Vostok.Logging.Abstractions;

namespace ChanelBotBoo.Models.Services.Telegram.AnswerLogic.Message;

public class DoNothing (ITelegramBotClient botClient, global::Telegram.Bot.Types.Message message, ILog logger) : MessageLogicBase(botClient, message, logger), IMessageLogic
{
    public Task getAnswerAsync()
    {
        logger.Info("DoNothing received");
        return Task.CompletedTask;
    }
}