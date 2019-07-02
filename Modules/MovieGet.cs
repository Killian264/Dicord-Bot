using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;

namespace DiscordBot.Modules
{
    public class Movie : ModuleBase<SocketCommandContext>
    {
        private static HttpClient client = new HttpClient();
        [Command("getMovie")]
        [Alias("yea")]
        public async Task getAnime(string movie)
        {
            var client = new RestClient("https://api.themoviedb.org/3/authentication/token/new?api_key=%3C%3Capi_key%3E%3E");
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine();
        }
    }
}
