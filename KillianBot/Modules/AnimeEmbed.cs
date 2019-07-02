using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using KillianBot.Services;
using System.Runtime.InteropServices;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot.Modules
{
    public class Anime : ModuleBase<SocketCommandContext>
    {
        private static HttpClient client = new HttpClient();
        [Discord.Commands.Command("getAnime")]
        public async Task getAnime(string anime, [Optional] string one, [Optional] string two, [Optional] string three, [Optional] string four, [Optional] string five, 
            [Optional] string six, [Optional] string seven, [Optional] string eight, [Optional] string nine, [Optional] string ten)
        {
            anime = anime + " " + one + " " + two + " " + three + " " + four + " " + five + " " + six + " " + seven + " " + eight + " " + nine + " " + ten;
            var test = @"https://api.jikan.moe/v3/search/anime?q=" + anime + @"&limit=1";
            var JsonReturn = await client.GetStringAsync(test);
            var resultsBefore = JsonConvert.DeserializeObject<Collections.myAnimeList>(JsonReturn);

            var results = resultsBefore.data[0];

            EmbedBuilder embed = new EmbedBuilder()
                .WithAuthor(results.title)
                .WithDescription(results.synopsis)
                .AddField("Members", results.members.ToString("#,##0"), true)
                .WithImageUrl(results.image_url)
                .WithFooter(results.url)
                .AddField("Type", results.type, true)
                .WithColor(Color.Green);


            if (results.rated == null)
            {
                embed.AddField("Airing", "Upcoming Anime", true);

            }
            else
            {
                string airing = "No";
                if (results.airing == true) { airing = "Yes"; }
                embed.AddField("Episodes", results.episodes, true);
                embed.AddField("Airing", airing, true);
                embed.AddField("Score", results.score.ToString(), true);
                embed.AddField("Rating", results.rated.ToString(), true);
            }

            await ReplyAsync(embed: embed.Build());
            return;
        }
    }
}
