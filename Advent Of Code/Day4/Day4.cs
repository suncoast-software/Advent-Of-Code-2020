using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Advent_Of_Code.Helper;

namespace Advent_Of_Code.Day4
{
    public class Day4
    {

        public static int SolvePart1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int validPassports = 0;
            Dictionary<string, bool> fieldIds = new Dictionary<string, bool>()
            {
                {"byr", true},
                {"iyr", true},
                {"eyr", true},
                {"hgt", true},
                {"hcl", true},
                {"ecl", true},
                {"pid", true},
                {"cid", false},
            };
            int expectedRequiredFieldCount = fieldIds.Where(x => x.Value).Count();
            string data = WebClientHelper.GetInput(4);
            var passports = data.Replace("\r", "").Replace("\n\n", "@").Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Found {passports.Length} passports");
            foreach (string passport in passports)
            {
                string[] parts = passport.Split(new char[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var fields = parts.Select(x => x.Split(':')).Select(x => new { key = x[0], value = x[1] }).ToList();
                int requiredFieldCount = 0;
                int optionalFieldCount = 0;

                foreach (var field in fields)
                {
                    if (fieldIds.TryGetValue(field.key, out bool required))
                    {
                        if (required) ++requiredFieldCount;
                        else ++optionalFieldCount;
                    }
                    else
                    {
                        Console.WriteLine($"field not recognised! '{field.key}'");
                    }

                }
                if (requiredFieldCount == expectedRequiredFieldCount) ++validPassports;
            }
            sw.Stop();
            Console.WriteLine($"Completed in : {sw.Elapsed} ms.");
            return validPassports;
        }


        public static int SolvePart2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int validPassports = 0;
            const string inches = "in", cm = nameof(cm);

            Func<string, bool> fourDigits = (val) => !string.IsNullOrWhiteSpace(val) && val.Length == 4 && int.TryParse(val, out int _);
            Func<string, int, int, bool> fourDigitsValue = (val, min, max) => !string.IsNullOrWhiteSpace(val) &&
                    val.Length == 4 && int.TryParse(val, out int year) && year >= min && year <= max;
            Func<string, bool> fourDigits1920 = (val) => fourDigitsValue(val, 1920, 2002);
            Func<string, bool> fourDigits2010 = (val) => fourDigitsValue(val, 2010, 2020);
            Func<string, bool> fourDigits2020 = (val) => fourDigitsValue(val, 2020, 2030);

            Func<string, string, bool> regexPattern = (val, pattern) => new Regex(pattern).Match(val).Success;
            Func<string, bool> hairColor = (val) => regexPattern(val, "^#[0-9a-f]{6}$");
            Func<string, bool> eyeColor = (val) => regexPattern(val, "^(amb|blu|brn|gry|grn|hzl|oth)$");
            Func<string, bool> ppId = (val) => regexPattern(val, "^[0-9]{9}$");
            Func<string, bool> funcLength = (val) =>
            {
                var match = new Regex(@"^(?<val>\d+)(?<kind>in|cm)$").Match(val);
                if (match.Success)
                {
                    if (!int.TryParse(match.Groups["val"].Value, out int length)) return false;

                    string kind = match.Groups["kind"].Value;
                    switch (kind)
                    {
                        case inches:
                            {
                                return length >= 59 && length <= 76;
                            }
                        case cm:
                            {
                                return length >= 150 && length <= 193;
                            }
                        default:
                            {
                                return false;
                            }

                    }
                }
                return false;
            };

            Dictionary<string, (bool required, Func<string, bool> validator)> fieldIds = new Dictionary<string, (bool required, Func<string, bool> validator)>()
            {
                {"byr", (true, fourDigits1920)},
                {"iyr", (true, fourDigits2010)},
                {"eyr", (true, fourDigits2020)},
                {"hgt", (true, funcLength)},
                {"hcl", (true, hairColor)},
                {"ecl", (true, eyeColor)},
                {"pid", (true, ppId)},
                {"cid", (false, null)},
            };
            int expectedRequiredFieldCount = fieldIds.Count(x => x.Value.required);
            string data = WebClientHelper.GetInput(4);
            var passports = data.Replace("\r", "").Replace("\n\n", "@").Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Found {passports.Length} passports");

            foreach (string passport in passports)
            {
                string[] parts = passport.Split(new char[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var fields = parts.Select(x => x.Split(':')).Select(x => new { key = x[0], value = x[1] }).ToList();
                int requiredFieldCount = 0;
                // int optionalFieldCount = 0;

                foreach (var field in fields)
                {
                    if (fieldIds.TryGetValue(field.key, out (bool required, Func<string, bool> validator) info))
                    {
                        if (info.required && info.validator(field.value)) ++requiredFieldCount;
                        // else ++optionalFieldCount;
                    }
                    else
                    {
                        Console.WriteLine($"field not recognised! '{field.key}'");
                    }

                }
                if (requiredFieldCount == expectedRequiredFieldCount) ++validPassports;
            }

            sw.Stop();
            Console.WriteLine($"Completed in : {sw.Elapsed} ms.");
            return validPassports;
        }
    }
}
