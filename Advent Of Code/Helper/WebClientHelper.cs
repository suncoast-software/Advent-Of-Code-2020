using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Advent_Of_Code.Helper
{
   public class WebClientHelper
    {
        const string BaseUrl = "https://adventofcode.com/2020/day";
        const string InputSuffix = "input";

        public static string GetInput(int day)
        {
            string cashedFile = $"Day{day}\\day{day}input.txt";
            if (File.Exists(cashedFile)) return File.ReadAllText(cashedFile);
            else
            {
                var wc = new WebClient();
                string contents = wc.DownloadString($"{BaseUrl}/{day}/{InputSuffix}");
                File.WriteAllText(cashedFile, contents);
                return contents;
            } 
        }
    }
}
