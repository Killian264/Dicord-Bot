using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.Linq;
using Discord;

namespace KillianBot.Modules
{
    public class Define : ModuleBase<SocketCommandContext>
    {
        [Discord.Commands.Command("define")]
        public async Task Definition(string word)
        {
            string MerriamBase = "https://www.merriam-webster.com/dictionary/";
            Services.KillianBotService.DictionaryList results = new Services.KillianBotService.DictionaryList();

            if (String.IsNullOrEmpty(word)) return;
            try
            {
                results = await Services.KillianBotService.DefinitionGet.GetDef(word);
            }
            catch
            {
                await ReplyAsync("No results");
            }

            var embed = new EmbedBuilder()
                .WithAuthor(word.First().ToString().ToUpper() + word.Substring(1) + "---Definition")
                .WithTitle("Definition Link")
                .WithUrl("https://www.google.com/search?rlz=1C1CHBF_enUS715US715&ei=KCq6XOvFAsOisAXRuJPYBQ&q=" + word + "+def&oq=dammit+def&gs_l=psy-ab.3..0i67i70i249j0l7j0i22i30l2.5814.9270..9323...8.0..0.157.2131.0j17....2..0....1..gws-wiz.....6..35i39j0i131j0i67j0i10j0i10i67j0i131i67.vr1ivIEsmVQ")
                .WithColor(Color.DarkerGrey)
                .WithFooter(MerriamBase + word);

            if (results.meaning.noun != null) embed.AddField("Noun", results.meaning.noun[0].definition);
            if (results.meaning.verb != null) embed.AddField("Verb", results.meaning.verb[0].definition);
            if (results.meaning.adverb != null) embed.AddField("Adverb", results.meaning.adverb[0].definition);
            if (results.meaning.adjective != null) embed.AddField("Adjective", results.meaning.adjective[0].definition);
            if (results.meaning.exclamation != null) embed.AddField("Exclamation", results.meaning.exclamation[0].definition);

            await ReplyAsync(embed: embed.Build());
        }
    }
    
}
