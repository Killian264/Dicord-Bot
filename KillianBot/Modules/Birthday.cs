using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using Discord.WebSocket;
using KillianBot.Services;

namespace KillianBot.Modules
{
    public class Birthday : ModuleBase<SocketCommandContext>
    {
        string filePath = @"FILEPATH";
        string splitChar = " ";
        TimeSpan day = TimeSpan.FromDays(1);

        [Discord.Commands.Command("Birthday")]
        public async Task birthday()
        {
            DateTime today = DateTime.Now;
            string[] arr = initilize(File.ReadAllLines(filePath));
            int i = 0, loc = 0, test = 0;
            string[] parsedArr;
            string[] birthDayNames = new string[arr.Length];
            DateTime comp = DateTime.Parse(parseArr(arr[0])[1]);
            foreach (string line in arr)
            {
                parsedArr = parseArr(line);
                DateTime birthday = DateTime.Parse(parsedArr[1]);
                if (birthday < comp && birthday > DateTime.Now.Subtract(day) && birthday > DateTime.Now.Add(day))
                {
                    comp = birthday;
                    loc = i;
                }
                else if (birthday < DateTime.Now.Subtract(day) && birthday < DateTime.Now.Add(day))
                {
                    birthDayNames[i] = parsedArr[0];
                    test++;
                }
                i++;
            }
            if (test == 1)
            {
                await ReplyAsync("It is " + birthDayNames[0] + "'s birthday!");
            }
            else if (test > 1)
            {
                await ReplyAsync("These are " + birthDayNames.Length + " birthdays today!:");
                foreach (string line in birthDayNames)
                {
                    await ReplyAsync(line + ",");
                }
            }
            else
            {
                await ReplyAsync(arr[loc] + " has the next birthday in " + DateTime.Now.Subtract(comp).ToString("dd") + " days");
            }
        }
        private string[] initilize(string[] arr)
        {
            string lines;
            string[] parsedArr;
            int len;
            int i = 0;
            bool clean = true;
            DateTime today = DateTime.Now;

            foreach (string line in arr)
            {
                parsedArr = parseArr(line);
                len = parsedArr.Length;
                if (len > 2)
                {
                    lines = cleanLine(line);
                    arr[i] = (parsedArr[0] + " " + lines);
                    clean = false;
                }
                else if (len < 1)
                {
                    ReplyAsync("Error birthday line " + (i + 1));
                }
                if (today.Subtract(day) > DateTime.Parse(parsedArr[1]))
                {
                    parsedArr[1] = upDate(DateTime.Parse(parsedArr[1])).ToString("yyyy/MM/dd");
                    arr[i] = parsedArr[0] + " " + parsedArr[1];
                }
                i++;
            }
            if (clean == false)
            {
                System.IO.File.WriteAllLines(filePath, arr);
            }
            return arr;
        }
        private string[] parseArr(string arr)
        {
            return (arr.Split(splitChar));
        }
        private string cleanLine(string date)
        {
            string[] arr = date.Split(splitChar);
            string sep = "/";

            if (String.IsNullOrEmpty(arr[1]) == true)
            {
                arr[1] = DateTime.Now.ToString("yyyy");
            }
            if (int.TryParse(arr[2], out int errOut) == false)
            {
                if (KillianBotService.monthsOfYear.monthDict.TryGetValue(arr[2], out int value) == true)
                {
                    arr[2] = value.ToString();
                }
                else
                {
                    arr[2] = "13";
                }
            }
            return (int.Parse(arr[1]) + sep + int.Parse(arr[2]) + sep + int.Parse(arr[3]));
        }
        private DateTime upDate(DateTime birthDate)
        {
            while (DateTime.Now.Subtract(TimeSpan.FromDays(1)) > birthDate)
            {
                birthDate = birthDate + TimeSpan.FromDays(365);
            }
            return birthDate;

        }
    }
}
