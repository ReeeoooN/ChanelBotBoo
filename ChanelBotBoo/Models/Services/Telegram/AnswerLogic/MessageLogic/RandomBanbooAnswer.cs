using Telegram.Bot;
using Telegram.Bot.Types;
using Vostok.Logging.Abstractions;

namespace ChanelBotBoo.Models.Services.Telegram.AnswerLogic.MessageLogic;

public class RandomBanbooAnswer(ITelegramBotClient botClient, global::Telegram.Bot.Types.Message message, ILog logger) : MessageLogicBase(botClient, message, logger), IMessageLogic
{
    private static readonly Dictionary<int, string> Answers = new Dictionary<int, string>
    {
        {0, "Эн-на%..$"},
        { 1, "Эн нэ?" },
        { 2, "Эн нааа! Ну-на-наааа!" },
        { 3, "*&...%&...$*%" },
        { 4, "Эн наааа! На на?" },
        { 5, "Эн-наа-эн! Не-не-нааа!" },
        { 6, "&%...%$" },
        { 7, "Эн-наа-нуу?" },
        { 8, "Эн-на...#&%...наа?" },
        { 9, "Эн-нааа..." },
        { 10, "Неее-на-ну" }
    };
    public async Task getAnswerAsync()
    {
        try
        {
            var random = Math.Abs(message.Text.GetHashCode()) % Answers.Count;
            await botClient.SendMessage(message.Chat.Id, Answers[random], replyParameters: message);
        }
        catch (Exception e)
        {
            logger.Error(e, "Error while sending answer.");
            throw;
        }
    }
}