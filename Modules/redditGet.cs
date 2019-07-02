using System;
using System.Collections.Generic;
using Discord.Commands;
using System.Threading.Tasks;
using KillianBot.Services;
using Discord;
using Reddit;
using Reddit.Models;
using Reddit.Exceptions;
using Reddit.Inputs;
using Reddit.Controllers;

namespace KillianBot.Modules
{
    public class redditGet : ModuleBase<SocketCommandContext>
    {
        readonly string filePath = AppContext.BaseDirectory + @"reddit.txt";

        [Command("RedditImages"), 
            Summary("Sends Images from a reddit of your choice"),
            Alias("ImagesReddit", "RedditImgGet", "Reddit Images", "Get Image Reddit")]
        public async Task redditImages(string subRedditName, int importNum)
        {
            Collections.postsAndTime postsAndTime = new Collections.postsAndTime();

            if (Collections.Dict.subreddits.ContainsKey(subRedditName))
            {
                postsAndTime = Collections.Dict.subreddits[subRedditName];
            }
            else
            {
                postsAndTime.created = DateTime.Now - TimeSpan.FromDays(1);
            }

            if (postsAndTime.created <= (DateTime.Now - TimeSpan.FromDays(1)))  //&& postLines[1] != subRedditName) || postLines[1] != subRedditName)
            {
                Collections.Dict.subreddits.Remove(subRedditName);
                //if(importNum < 100) { importNum = 100; }
                var topPosts = GetTopRedditPosts(subRedditName, 100, "top", "day");
                
                postsAndTime.created = DateTime.Now;
                postsAndTime.posts = topPosts;
                Collections.Dict.subreddits.Add(subRedditName, postsAndTime);

                await ImgBuildSendEmbed(topPosts, importNum);
            }
            else
            {
                await ImgBuildSendEmbed(postsAndTime.posts, importNum);
            }
        }
        private async Task ImgBuildSendEmbed(List<Post> topPosts, int importNum)
        {
            int i = 0;
            foreach (LinkPost posts in topPosts)
            {
                if (!string.IsNullOrEmpty(posts.URL))
                {
                    EmbedBuilder embed = new EmbedBuilder()
                        .WithTitle(posts.Title)
                        .WithImageUrl(posts.URL)
                        .WithFooter(posts.UpVotes + " Upvotes | Posted " + posts.Created);
                    await ReplyAsync(embed: embed.Build());
                    i++;
                }
                if(importNum <= i)
                {
                    return;
                }
            }
            return;
        }

        private List<Post> GetTopRedditPosts(string subRedditName, int amountOfPosts, string sortType, string sortTypeTopType)
        {
            //Add your reddit bot appID which is right below the use of the app and your secret. You can get your refreashtoken from a easy to use reddit python script.
            var reddit = new RedditAPI(
                appId: Config.config.RedditAppId, 
                appSecret: Config.config.RedditAppSecret, 
                refreshToken: Config.config.RedditAppRefreshToken);

            Subreddit posts;

            if (amountOfPosts > 100) { amountOfPosts = 100; }

            switch (sortType)
                {
                    case "top":
                        posts = reddit.Subreddit(subRedditName).About();
                        return (posts.Posts.GetTop(sortTypeTopType, "", "", amountOfPosts));
                    case "hot":
                        posts = reddit.Subreddit(subRedditName).About();
                        return (posts.Posts.GetHot("", "", "", amountOfPosts));
                    case "new":
                        posts = reddit.Subreddit(subRedditName).About();
                        return (posts.Posts.GetNew("", "", amountOfPosts));
                    case "rising":
                        posts = reddit.Subreddit(subRedditName).About();
                        return (posts.Posts.GetControversial("top", "", "", amountOfPosts));
                    default:
                        posts = reddit.Subreddit(subRedditName).About();
                        return (posts.Posts.GetTop(sortTypeTopType, "", "", amountOfPosts));
                }
        }
    }
}
