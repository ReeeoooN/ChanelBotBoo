using System.Threading.Tasks;

namespace ChanelBotBoo.Models.Services;

public interface IAsnwerService
{
    public Task<string> getAnswerAsync(string question);
}