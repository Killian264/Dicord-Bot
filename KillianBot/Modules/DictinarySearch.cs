using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.Linq;
using Discord;
using KillianBot.Services;
using System.Collections.Generic;

namespace KillianBot.Modules
{
    public class Define : ModuleBase<SocketCommandContext>
    {
        [Discord.Commands.Command("define")]
        public async Task Definition(string word)
        {
            string MerriamBase = Collections.Config.MerriamBase;
            string gF = Collections.Config.GoogleFirst;
            string gS = Collections.Config.GoogleSecond;

            Collections.DictionaryList results = new Collections.DictionaryList();

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
                .WithUrl(gF + word + gS)
                .WithColor(Color.DarkerGrey)
                .WithFooter(MerriamBase + word);

            if (results.meaning.noun != null) embed.AddField("Noun", results.meaning.noun[0].definition);
            if (results.meaning.verb != null) embed.AddField("Verb", results.meaning.verb[0].definition);
            if (results.meaning.adverb != null) embed.AddField("Adverb", results.meaning.adverb[0].definition);
            if (results.meaning.adjective != null) embed.AddField("Adjective", results.meaning.adjective[0].definition);
            if (results.meaning.exclamation != null) embed.AddField("Exclamation", results.meaning.exclamation[0].definition);
            if (results.meaning.determiner != null) embed.AddField("Determiner", results.meaning.determiner[0].definition);
            if (results.meaning.pronoun != null) embed.AddField("ProNoun", results.meaning.pronoun[0].definition);
            if (results.meaning.preposition != null) embed.AddField("Preposition", results.meaning.preposition[0].definition);
            if (results.meaning.conjunction != null) embed.AddField("Conjunction", results.meaning.conjunction[0].definition);
            if (results.meaning.conjunctAndAdverb != null) embed.AddField("Conjunction & Adverb", results.meaning.conjunctAndAdverb[0].definition);
            if (results.meaning.deterAndPronoun != null) embed.AddField("Determiner & Pronoun", results.meaning.deterAndPronoun[0].definition);
            if (results.meaning.preDetP != null) embed.AddField("Predeterminer, Determiner, & Pronoun", results.meaning.preDetP[0].definition);
            if (results.meaning.number != null) embed.AddField("Number", results.meaning.number[0]);
            if (results.meaning.detProAdj != null) embed.AddField("Determiner, Pronoun, & Adjective", results.meaning.detProAdj[0].definition);

            await ReplyAsync(embed: embed.Build());
        }
    }
    
}
