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
                string url = Collections.Config.DictionaryApi;
                word = WebUtility.UrlEncode(word.Trim());
                string lang = WebUtility.UrlEncode(Collections.Config.DictionaryLang);

                var JsonReturn = await client.GetStringAsync(url + word + lang);
                return JsonConvert.DeserializeObject<Collections.DictionaryList>(JsonReturn);
            }
        }

        public class ConfigGet
        {
            public static void GetConfig()
            {
                var results = JsonConvert.DeserializeObject<Collections.ConfigList>(File.ReadAllText(@"C:\Users\Killian\Desktop\KillianBot\bin\Debug\netcoreapp2.0/config.json"));
                Collections.Config.BotToken = results.BotToken;
                Collections.Config.BirthdayFileName = results.BirthdayFileName;
                Collections.Config.DictionaryApi = results.DictionaryApi;
                Collections.Config.DictionaryLang = results.DictionaryLang;
                Collections.Config.CommandLetter = results.CommandLetter;
                Collections.Config.MerriamBase = results.MerriamBase;
                Collections.Config.GoogleFirst = results.GoogleFirst;
                Collections.Config.GoogleSecond = results.GoogleSecond;
                Collections.Config.WordTypes = results.WordTypes;
                Collections.Config.NumWordTypes = results.NumWordTypes;
            }
        }

    }

}
