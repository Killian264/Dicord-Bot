# Discord-Bot
C# Discord Bot that I am currently working on using .NET and Discord.Net.

------------------------------------------------------
# What I learned

Async design and implementation.

Api calls and serialization and deserilization to and from models.

Config files and JSON config files.

------------------------------------------------------
Commands:

!birthday - Returns next birthday or any birthdays that are today.

!birthdayall - Returns a list of the birthdays on file in a Discord Embed.

!define (word) - returns the definition of a word with 1 of each def type in a Discord Embed.

!defineall (word) - returns all definitions of a word in a Discord Embed.

!Reddit Images (subreddit) (NumImages max 100) - returns NumImages images in a Discord Embed.

!help - gives help on all commands or just one

!info - gives discord guild information

!getanime - searches for an anime and returns myAnimeList info on it.

------------------------------------------------------

Implemented:

Birthday Module that will read a file and print the next birthday from the list. Added Birthday All command.

Merged Castle's code which simplified TryParse with try and get, add more detailed errors, and simplified some other code. 

Async framework that allows for more modules

Dictionary Module that gives you definition of a word

Config File - bin/Debug/netcoreapp2.0 - If you change location update filePaths in code.

Reddit Image Get - given a subreddit and the amount of images you would like gets 100 of the top posts for the day and uploads the images to discord.

Help Command

Implemented privileges

-----------------------------------------------------

TODO Methods:

Song Player - Plays song from youtube

-----------------------------------------------------

TODO General:

Tidy up
