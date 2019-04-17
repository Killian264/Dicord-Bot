using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace KillianBot
{
    public class Program
    {
        const string _clientID = "ID";

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, _clientID);

            await _client.StartAsync();

            _handler = new CommandHandler(_client);

            await Task.Delay(-1);

        }
    }
}
