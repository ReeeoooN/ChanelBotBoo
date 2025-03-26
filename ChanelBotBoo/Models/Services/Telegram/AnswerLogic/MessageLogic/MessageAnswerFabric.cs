using ChanelBotBoo.Models.Services.Telegram.AnswerLogic.Message;
using Telegram.Bot;
using Vostok.Logging.Abstractions;

namespace ChanelBotBoo.Models.Services.Telegram.AnswerLogic.MessageLogic;

public class MessageAnswerFabric (ITelegramBotClient botClient, ILog logger)
{
    public IMessageLogic GetMessageLogic(global::Telegram.Bot.Types.Message message)
    {
        if (message.IsAutomaticForward)
        {
            return new RandomBanbooAnswer(botClient, message, logger);
        }

        if (message.ReplyToMessage is not null && message.ReplyToMessage.From.Id == botClient.BotId)
        {
            return new RandomBanbooAnswer(botClient, message, logger);
        }

        return new DoNothing(botClient, message, logger);

    }
}