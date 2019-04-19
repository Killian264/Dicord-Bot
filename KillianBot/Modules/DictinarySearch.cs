using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using Discord.WebSocket;
using KillianBot.Services;
using Newtonsoft.Json;
using System.Linq;
using Discord;

namespace KillianBot.Modules
{
    public class Define : ModuleBase<SocketCommandContext>
    {
        string MerriamBase = "https://www.merriam-webster.com/dictionary/";

        [Discord.Commands.Command("define")]
        public async Task define(string word)
        {
            if (String.IsNullOrEmpty(word)) return;
            var results = await Services.KillianBotService.DefinitionGet.GetDef(word);
            if (results.word != word) await ReplyAsync("No results"); 
            else
            {
                var embed = new EmbedBuilder()
                        .WithAuthor(word.First().ToString().ToUpper() + word.Substring(1) + "---Definition")
                        .WithColor(Color.Blue)
                        .WithFooter(MerriamBase + word);

                if(results.meaning.noun != null)
                {
                    embed.AddField("Noun", results.meaning.noun[0].definition);
                }
                if (results.meaning.verb != null)
                {
                    embed.AddField("Verb", results.meaning.verb[0].definition);
                }
                if (results.meaning.adverb != null)
                {
                    embed.AddField("Adverb", results.meaning.adverb[0].definition);
                }
                if (results.meaning.adjective != null)
                {
                    embed.AddField("Adjective", results.meaning.adjective[0].definition);
                }
                if (results.meaning.exclamation != null)
                {
                    embed.AddField("Exclamation", results.meaning.exclamation[0].definition);
                }
                await ReplyAsync(embed: embed.Build());
            }
        }
    }
    
}
