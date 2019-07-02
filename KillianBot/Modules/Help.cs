using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Net;
using Discord.Commands;
using System.Threading.Tasks;
using KillianBot.Services;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;

namespace KillianBot.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Discord.Commands.Command("help"), Summary("help")]
        public async Task help([Optional] string str)
        {
            string concat = "";

            if(str == null)
            {
                Collections.Settings command;
                var keyList = Collections.commands.Keys.ToList();
                EmbedBuilder embed = new EmbedBuilder().WithTitle("Command List");
                foreach (string key in keyList)
                {
                    concat = "";
                    command = Collections.commands[key];
                    foreach (string line in command.aliases)
                    {
                        concat = concat + " \"" + line + "\"";
                    }
                    embed.AddField(key, "**Aliases: **" + concat + "\n" + "**Description: **" + command.description + "\n" + "**Perm Level: **" + command.permission.ToString() + "\n" + "**How To Use **" + command.howUse);
                }
                await ReplyAsync(embed: embed.Build());
                return;
            }
            else
            {
                try
                {
                    str = str.First().ToString().ToUpper() + str.Substring(1);
                    var command = Collections.commands[str];

                    EmbedBuilder embed = new EmbedBuilder();
                    
                    embed.WithAuthor(str);
                    foreach (string line in command.aliases)
                    {
                        concat = concat + " " + line;
                    }
                    //embed.WithTitle("Aliases: " + concat);
                    //embed.WithDescription(command.description);
                    embed.WithDescription("**Aliases: **" + concat + "\n" + "**Description: **" + command.description + "\n" + "**Perm Level: **" + command.permission.ToString() + "\n" + command.howUse);
                    await ReplyAsync(embed: embed.Build());
                }
                catch
                {
                    await ReplyAsync("No command of that name. Note: Use only proper name of command that can be found using !help");
                }
            }
        }
        
        [Command("info")]
        public async Task GetServer()
        {
            var output = new EmbedBuilder()
                .WithAuthor($"Owner: #{Context.Guild.Owner.Username}", iconUrl: string.IsNullOrEmpty(Context.Guild.Owner.AvatarId) ? null : Context.Guild.Owner.GetAvatarUrl())
                .WithTitle(Context.Guild.Name + $" (ID: {Context.Guild.Id.ToString()})")
                .AddField("Created on", Context.Guild.CreatedAt.DateTime.ToString(CultureInfo.InvariantCulture), true)
                .AddField("Member Count", Context.Guild.MemberCount.ToString(), true)
                .AddField("Region", Context.Guild.VoiceRegionId.ToUpperInvariant(), true)
                .AddField("Authentication", Context.Guild.MfaLevel.ToString(), true)
                .AddField("Content Filter", Context.Guild.ExplicitContentFilter.ToString(), true)
                .AddField("Verification", Context.Guild.VerificationLevel.ToString(), true)
                .WithFooter(Context.Guild.Name + " / #" + Context.Channel.Name + " / " + DateTime.Now);
            if (!string.IsNullOrEmpty(Context.Guild.IconId))
                output.WithThumbnailUrl(Context.Guild.IconUrl);
            var roles = new StringBuilder();
            foreach (var role in Context.Guild.Roles)
                roles.Append($"[`{role.Name}`]");
            if (roles.Length == 0) roles.Append("None");
            output.AddField("Roles", roles.ToString());

            var emojis = new StringBuilder();
            foreach (var emoji in Context.Guild.Emotes)
                emojis.Append(emoji.Name);
            if (emojis.Length != 0) output.AddField("Emojis", emojis.ToString(), true);
            await ReplyAsync(embed: output.Build());
        }
        [Command("purge")]
        public async Task GetMessages([Optional] int amount)
        {
            var test = Context.Channel.GetMessagesAsync();
            //make this do stuff later
        }
    }
}
