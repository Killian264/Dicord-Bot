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
                string url = Collections.Config.configList.DictionaryApi;
                word = WebUtility.UrlEncode(word.Trim());
                string lang = WebUtility.UrlEncode(Collections.Config.configList.DictionaryLang);

                var JsonReturn = await client.GetStringAsync(url + word + lang);
                return JsonConvert.DeserializeObject<Collections.DictionaryList>(JsonReturn);
            }
        }
        public class ConfigGet
        {
            public static void GetConfig()
            {
                var results = JsonConvert.DeserializeObject<Collections.ConfigList>(File.ReadAllText(System.AppContext.BaseDirectory + "config.json"));
                Collections.Config.configList.BotToken = results.BotToken;
                Collections.Config.configList.BirthdayFileName = results.BirthdayFileName;
                Collections.Config.configList.DictionaryApi = results.DictionaryApi;
                Collections.Config.configList.DictionaryLang = results.DictionaryLang;
                Collections.Config.configList.CommandLetter = results.CommandLetter;
                Collections.Config.configList.MerriamBase = results.MerriamBase;
                Collections.Config.configList.GoogleFirst = results.GoogleFirst;
                Collections.Config.configList.GoogleSecond = results.GoogleSecond;
                Collections.Config.configList.WordTypes = results.WordTypes;
                Collections.Config.configList.NumWordTypes = results.NumWordTypes;
                Collections.Config.configList.RedditAppId = results.RedditAppId;
                Collections.Config.configList.RedditAppRefreshToken = results.RedditAppRefreshToken;
                Collections.Config.configList.RedditAppSecret = results.RedditAppSecret;
            }
        }

    }

}
