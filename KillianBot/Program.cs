using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.IO;
using KillianBot.Services;

namespace KillianBot
{
    public class Program
    {
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;

        public async Task StartAsync()
        {

            _client = new DiscordSocketClient();

            KillianBotService.ConfigGet.GetConfig();

            await _client.LoginAsync(TokenType.Bot, Collections.Config.configList.BotToken);

            await _client.StartAsync();

            _handler = new CommandHandler(_client);

            await Task.Delay(-1);

        }
    }
}
