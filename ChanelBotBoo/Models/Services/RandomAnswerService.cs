using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChanelBotBoo.Models.Services;

public class RandomAnswerService : IAsnwerService
{
    private static readonly Dictionary<int, string> Answers = new Dictionary<int, string>
    {
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
    public Task<string> getAnswerAsync(string question)
    {
        var random = Math.Abs(question.GetHashCode()) % Answers.Count;
        return Task.FromResult(Answers[random]);
    }
}