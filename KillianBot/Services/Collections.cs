using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using KillianBot.Services;

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
            public List<DictionaryDataList> noun { get; set; }

            public List<DictionaryDataList> verb { get; set; }

            public List<DictionaryDataList> adverb { get; set; }

            public List<DictionaryDataList> adjective { get; set; }

            public List<DictionaryDataList> exclamation { get; set; }

            public List<DictionaryDataList> determiner { get; set; }

            public List<DictionaryDataList> pronoun { get; set; }

            public List<DictionaryDataList> preposition { get; set; }

            public List<DictionaryDataList> conjunction { get; set; }

            [JsonProperty("conjunction & adverb")]
            public List<DictionaryDataList> conjunctAndAdverb { get; set; }

            [JsonProperty("determiner & pronoun")]
            public List<DictionaryDataList> deterAndPronoun { get; set; }

            [JsonProperty("predeterminer, determiner, & pronoun")]
            public List<DictionaryDataList> preDetP { get; set; }

            [JsonProperty("determiner, pronoun, & adjective")]
            public List<DictionaryDataList> detProAdj { get; set; }

            public List<DictionaryDataList> number { get; set; }
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

            public List<string> WordTypes { get; set; }

            public int NumWordTypes { get; set; }
        }

        public static class Config
        {
            public static string BotToken;

            public static string BirthdayFileName;

            public static string DictionaryApi;

            public static string DictionaryLang;

            public static char CommandLetter;

            public static string MerriamBase;

            public static string GoogleFirst;

            public static string GoogleSecond;

            public static List<string> WordTypes;

            public static int NumWordTypes;
        }
    }

}
