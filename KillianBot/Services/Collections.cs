using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using KillianBot.Services;
using Reddit;

namespace KillianBot.Services
{
    class Collections
    {
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
        }

        public static class Config
        {
            public static ConfigList configList = new ConfigList();
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
    }

}
