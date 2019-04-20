using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;
using KillianBot.Services;

namespace KillianBot
{
    public class CommandHandler
    {
       private DiscordSocketClient _client;

       private CommandService _service;

       char cmdLetter = Collections.Config.CommandLetter;

       public CommandHandler(DiscordSocketClient client)
        {
            _client = client;

            _service = new CommandService();

            _service.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            _client.MessageReceived += HandleCommandAsync;

        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if(msg == null) return;

            var context = new SocketCommandContext(_client, msg);

            int argPos = 0;
            if (msg.HasCharPrefix(cmdLetter, ref argPos))
            {
                    var result = await _service.ExecuteAsync(context, argPos, null);

                    if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                    {
                        await context.Channel.SendMessageAsync(result.ErrorReason);
                    }
            }
        }
    }
}
