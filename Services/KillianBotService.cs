using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using KillianBot.Services;
using System.Reflection;
using System.IO;
using System;

namespace KillianBot.Services
{
    class KillianBotService
    {
        public class DefinitionGet
        {
            private static HttpClient client = new HttpClient();

            public static async Task<Collections.DictionaryList> GetDef(string word)
            {
                //string url = Collections.Config.configList.DictionaryApi;
                //word = WebUtility.UrlEncode(word.Trim());
                //string lang = WebUtility.UrlEncode(Collections.Config.configList.DictionaryLang);

                var JsonReturn = await client.GetStringAsync(
                    Config.config.DictionaryApi
                    + WebUtility.UrlEncode(word.Trim())
                    + WebUtility.UrlEncode(Config.config.DictionaryLang));

                return JsonConvert.DeserializeObject<Collections.DictionaryList>(JsonReturn);
            }
        }
        public class ConfigGet
        {
            public static void GetConfig()
            {
                var results = JsonConvert.DeserializeObject<Config.ConfigList>(File.ReadAllText(System.AppContext.BaseDirectory + "config.json"));
                Config.config = results;
            }
        }

    }

}
