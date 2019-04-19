using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace KillianBot.Services
{
    class KillianBotService
    {
        public class DefinitionGet
        {
            //If you use this code make sure that you concatenate the api you plan to use properly
            const string url = "API MAIN URL";
            const string lang = "SECONDARY API URL";

            private static HttpClient client = new HttpClient();

            public static async Task<DictionaryList> GetDef(string word)
            {
                var JsonReturn = await client.GetStringAsync(url + WebUtility.UrlEncode(word.Trim()) + WebUtility.UrlEncode(lang));
                return JsonConvert.DeserializeObject<DictionaryList>(JsonReturn);
            }
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
            public List<DictionaryDataList> noun { get; set; }

            public List<DictionaryDataList> verb { get; set; }

            public List<DictionaryDataList> adverb { get; set; }

            public List<DictionaryDataList> adjective { get; set; }

            public List<DictionaryDataList> exclamation { get; set; }
        }

        public class DictionaryDataList
            {
            public string definition { get; set; }

            public string example { get; set; }

            public string[] synonyms { get; set; }
        }
    }

}
