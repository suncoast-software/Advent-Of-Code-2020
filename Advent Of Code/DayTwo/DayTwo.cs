using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Advent_Of_Code.DayTwo
{
   public class DayTwo
    {

        private static List<string> GetPasswords()
        {
            var passwords = new List<string>();
            using (var reader = new StreamReader(@"DayTwo/daytwoinput.txt"))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] details = line.Split(':');
                    passwords.Add(details[1].Trim());
                }
            }
            return passwords;
        }

        private static List<string> GetPolicies()
        {
            var policies = new List<string>();
            using (var reader = new StreamReader(@"DayTwo/daytwoinput.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] details = line.Split(':');
                    policies.Add(details[0].Trim());
                }
            }
            return policies;
        }

        public static int ParsePasswordInput()
        {
            var passwords = GetPasswords();
            var policies = GetPolicies();
            var valid = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < passwords.Count; i++)
            {
                string minPosLetter = null;
                string maxPosLetter = null;
                string[] policy = policies[i].Split(' ');
                var password = passwords[i];
                var minMax = policy[0].Split('-');
                var letter = policy[1].Replace(":", string.Empty);
                var min = int.Parse(minMax[0]);
                var max = int.Parse(minMax[1]);
                // var count = 0;

                minPosLetter = password.Substring(min - 1, 1);
                maxPosLetter = password.Substring(max - 1, 1);

                if (minPosLetter == letter && maxPosLetter == letter)
                {
                    Console.WriteLine($"Invalid : {password}");
                }
                else if (minPosLetter != letter && maxPosLetter != letter)
                {
                    Console.WriteLine($"Invalid : {password}");
                }
                else if (minPosLetter == letter && maxPosLetter != letter)
                {
                    valid++;
                }
                else if (minPosLetter != letter && maxPosLetter == letter)
                {
                    valid++;
                }


            }
            sw.Stop();
            Console.WriteLine($"Finished in : {sw.ElapsedMilliseconds} ms");
            return valid;
        }
    }
}
