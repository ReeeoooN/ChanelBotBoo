namespace ChanelBotBoo.Models.Services.Telegram;

public interface IAsnwerService
{
    public Task<string> getAnswerAsync(string question);
}