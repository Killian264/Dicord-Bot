using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using KillianBot.Services;
using Reddit;
using Discord.Net;
using Discord;

namespace KillianBot.Services
{
    class Collections
    {
        public static Dictionary<string, Settings> commands = new Dictionary<string, Settings>
        {
                {"Birthday", new Settings{
                    permission = GuildPermission.SendMessages,
                    aliases = new string[1] {"bday"},
                    description = "Checks birthdays and sends next birthday or checks if someones birthday is today.",
                    howUse = "!birthday"} },

                {"BirthdayAll", new Settings{
                    permission = GuildPermission.SendMessages,
                    aliases = new string[3] {"birthday all", "bday all", "bdayall"},
                    description = "Gets all birthdays from file",
                    howUse = "!birthdayAll" } },

                {"Define", new Settings{
                    permission = GuildPermission.SendMessages,
                    aliases = new string[2] {"definition", "def"},
                    description = "Defines word",
                    howUse = "!define word" } },

                {"DefineAll", new Settings{
                    permission = GuildPermission.SendMessages,
                    aliases = new string[5] {"define all", "definition all", "definitionall", "def all", "defall"},
                    description = "Gets all definitons of word",
                    howUse = "!defineAll word" } },

                {"RedditImages", new Settings{
                    permission = GuildPermission.SendMessages,
                    aliases = new string[4] {"ImagesReddit", "RedditImgGet", "Reddit Images", "Get Image Reddit"},
                    description = "Sends Images from a reddit of your choice",
                    howUse = "!redditImages subreddit howmanyImgs" } },

                {"Help", new Settings{
                    permission = GuildPermission.SendMessages,
                    aliases = new string[1] {"None"},
                    description = "Helps",
                    howUse = "!help or !help commandname" } }
        };
        public class myAnimeListData
        {
            public int mal_id { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public string title { get; set; }
            public bool airing { get; set; }
            public string synopsis { get; set; }
            public string type { get; set; }
            public int episodes { get; set; }
            public double score { get; set; }
            public int members { get; set; }
            public string rated { get; set; }
        }

        public class myAnimeList
        {
            public string request_hash { get; set; }
            public bool request_cached { get; set; }
            public int request_cache_expiry { get; set; }
            [JsonProperty("results")]
            public List<myAnimeListData> data { get; set; }
            public int last_page { get; set; }
        }
        public class Settings
        {
            public GuildPermission permission { get; set; }

            public string[] aliases { get; set; }

            public string description { get; set; }

            public string howUse { get; set; }
        }

        public class DictionaryList
        {
            public string word { get; set; }

            public string[] phonetic { get; set; }

            public string pronunciation { get; set; }

            public MeaningGet meaning { get; set; }
        }

        public class MeaningGet
        {
            public List<List<DictionaryDataList>> lists = new List<List<DictionaryDataList>>();
            public List<DictionaryDataList> noun {set { lists.Add(value); } }

            public List<DictionaryDataList> verb { set { lists.Add(value); } }

            public List<DictionaryDataList> adverb { set { lists.Add(value); } }

            public List<DictionaryDataList> adjective { set { lists.Add(value); } }

            public List<DictionaryDataList> exclamation { set { lists.Add(value); } }

            public List<DictionaryDataList> determiner { set { lists.Add(value); } }

            public List<DictionaryDataList> pronoun { set { lists.Add(value); } }

            public List<DictionaryDataList> preposition { set { lists.Add(value); } }

            public List<DictionaryDataList> conjunction { set { lists.Add(value); } }

            [JsonProperty("conjunction & adverb")]
            public List<DictionaryDataList> conjunctAndAdverb { set { lists.Add(value); } }

            [JsonProperty("determiner & pronoun")]
            public List<DictionaryDataList> deterAndPronoun { set { lists.Add(value); } }

            [JsonProperty("predeterminer, determiner, & pronoun")]
            public List<DictionaryDataList> preDetP { set { lists.Add(value); } }

            [JsonProperty("determiner, pronoun, & adjective")]
            public List<DictionaryDataList> detProAdj { set { lists.Add(value); } }

            public List<DictionaryDataList> number { set { lists.Add(value); } }
        }

        public class DictionaryDataList
        {
            public string definition { get; set; }

            public string example { get; set; }

            public string[] synonyms { get; set; }
        }

        public class ConfigList
        {
            public string BotToken { get; set; }

            public string BirthdayFileName { get; set; }

            public string DictionaryApi { get; set; }

            public string DictionaryLang { get; set; }

            public char CommandLetter { get; set; }

            public string MerriamBase { get; set; }

            public string GoogleFirst { get; set; }

            public string GoogleSecond { get; set; }

            public string[] WordTypes { get; set; }

            public int NumWordTypes { get; set; }

            public string RedditAppId { get; set; }

            public string RedditAppSecret { get; set; }

            public string RedditAppRefreshToken { get; set; }

            public AliasesOfEach aliases { get; set; }
        }

        public static class Config
        {
            public static ConfigList configList = new ConfigList();
            
            public static AliasesOfEach allAliases { get; set; }
        }

        public static class Dict
        {
            public static Dictionary<string, postsAndTime> subreddits = new Dictionary<string, postsAndTime>();
        }
        public class postsAndTime
        {
            public DateTime created { get; set; }
            public List<Reddit.Controllers.Post> posts { get; set; }
        }
        public class AliasesOfEach
        {
            public string[] birthday { get; set; }

            public string[] birthdayAll { get; set; }

            public string[] define { get; set; }
            public string[] definAll { get; set; }
            public string[] redditImages { get; set; }
        }
    }

}
