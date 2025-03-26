using ChanelBotBoo.Models.Services.Telegram;
using ChanelBotBoo.Models.Services.Telegram.AnswerLogic.MessageLogic;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Vostok.Logging.Abstractions;
using Vostok.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ILog, ConsoleLog>();
builder.Services.AddSingleton<IUpdateHandler, UpdateHandler>();
builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>(provider =>
    new TelegramBotClient(Environment.GetEnvironmentVariable("API_KEY")));
builder.Services.AddSingleton<MessageAnswerFabric>();
builder.Services.AddHostedService<TgBot>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
