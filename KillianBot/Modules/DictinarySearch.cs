using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.Linq;
using Discord;
using KillianBot.Services;
using System.Collections.Generic;
using System.Reflection;
using Discord.Commands.Builders;

namespace KillianBot.Modules
{
    public class Define : ModuleBase<SocketCommandContext>
    {
        int count = 0;
        string[] types = Collections.Config.WordTypes;

        [Discord.Commands.Command("define"), Summary("Defines word")]
        public async Task Definition(string word)
        {

            var results = await baseDefine(word);
            var embed = await baseEmbed(word);
            embed.WithAuthor(word.First().ToString().ToUpper() + word.Substring(1) + "---Definitions");

            foreach (List<Collections.DictionaryDataList> type in results.meaning.lists)
            {
                if (type != null) embed.AddField(types[count], type[0].definition);
                count++;
            }

            await ReplyAsync(embed: embed.Build());
        }
        [Discord.Commands.Command("defineall"), Summary("Gets all definitons of word")]
        public async Task DefineAll(string word)
        {
            var results = await baseDefine(word);
            var embed = await baseEmbed(word);

            embed.WithAuthor(word.First().ToString().ToUpper() + word.Substring(1) + "---All Definitions");
            string conCat = "";

            foreach (List<Collections.DictionaryDataList> type in results.meaning.lists)
            {
                conCat = "";
                for (int i = 0; i < type.Count; i++)
                {
                    if (type != null)
                    {
                        conCat = string.Concat(conCat, "\n\n", type[i].definition);
                    }
                }
                conCat = string.Concat(conCat, "\n----------");
                if (type != null) embed.AddField(types[count], conCat);
                //embed.AddField("----------", "----------");
                count++;
            }

            await ReplyAsync(embed: embed.Build());
        }

        private async Task<Collections.DictionaryList> baseDefine(string word)
        {
            Collections.DictionaryList results = new Collections.DictionaryList();

            if (String.IsNullOrEmpty(word)) return null;
            try
            {
                return results = await Services.KillianBotService.DefinitionGet.GetDef(word);
            }
            catch
            {
                await ReplyAsync("No results");
                return null;
            }
        }
        private async Task<EmbedBuilder> baseEmbed(string word)
        {
            string MerriamBase = Collections.Config.MerriamBase;
            string gF = Collections.Config.GoogleFirst;
            string gS = Collections.Config.GoogleSecond;

            var embed = new EmbedBuilder()
                .WithTitle("Definition Link")
                .WithUrl(gF + word + gS)
                .WithColor(Color.DarkerGrey)
                .WithFooter(MerriamBase + word);

            return embed;
        }
    }
    
}
