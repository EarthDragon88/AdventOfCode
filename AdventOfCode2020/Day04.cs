using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day04 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var passportTexts = raw.Trim().Split("\n\n");

            var validCount = 0;
            for (int i = 0; i < passportTexts.Length; i++)
                if (IsValidPuzzle1(passportTexts[i]))
                    validCount++;

            return validCount.ToString();
        }

        private bool IsValidPuzzle1(string passportText)
        {
            var passportFormatted = passportText
                .Replace('\n', ' ')
                .Split(' ');

            var passportDictionary = new Dictionary<string, string>();

            foreach (var passportInfo in passportFormatted)
            {
                var passportInfoSplit = passportInfo.Split(':');
                var key = passportInfoSplit[0];
                var value = passportInfoSplit[1];
                passportDictionary.Add(key, value);
            }

            return HasAllKeysExceptCid(passportDictionary);
        }

        private bool HasAllKeysExceptCid(Dictionary<string, string> passportDictionary)
        {
            return passportDictionary.ContainsKey("byr")
                && passportDictionary.ContainsKey("iyr")
                && passportDictionary.ContainsKey("eyr")
                && passportDictionary.ContainsKey("hgt")
                && passportDictionary.ContainsKey("hcl")
                && passportDictionary.ContainsKey("ecl")
                && passportDictionary.ContainsKey("pid");
        }

        public override string SolvePuzzle2()
        {
            var passportTexts = raw.Trim().Split("\n\n");

            var validCount = 0;
            for (int i = 0; i < passportTexts.Length; i++)
                if (IsValidPuzzle2(passportTexts[i]))
                    validCount++;

            return validCount.ToString();
        }

        private bool IsValidPuzzle2(string passportText)
        {
            var passportFormatted = passportText
                .Replace('\n', ' ')
                .Split(' ');

            var passportDictionary = new Dictionary<string, string>();

            foreach (var passportInfo in passportFormatted)
            {
                var passportInfoSplit = passportInfo.Split(':');
                var key = passportInfoSplit[0];
                var value = passportInfoSplit[1];
                passportDictionary.Add(key, value);
            }

            if(HasAllKeysExceptCid(passportDictionary)
                && IsValidBirthYear(passportDictionary["byr"])
                && IsValidIssueYear(passportDictionary["iyr"])
                && IsValidExpirationYear(passportDictionary["eyr"])
                && IsValidHeight(passportDictionary["hgt"])
                && IsValidHairColor(passportDictionary["hcl"])
                && IsValidEyeColor(passportDictionary["ecl"])
                && IsValidPassportId(passportDictionary["pid"]))
                return true;

            return false;
        }

        private bool IsValidBirthYear(string year)
        {
            var parsed = int.Parse(year);
            return parsed >= 1920 && parsed <= 2002;
        }

        private bool IsValidIssueYear(string year)
        {
            var parsed = int.Parse(year);
            return parsed >= 2010 && parsed <= 2020;
        }

        private bool IsValidExpirationYear(string year)
        {
            var parsed = int.Parse(year);
            return parsed >= 2020 && parsed <= 2030;
        }

        private bool IsValidHeight(string height)
        {
            if (height.EndsWith("cm"))
            {
                var heightInCm = int.Parse(height.Substring(0, height.Length - 2));
                return heightInCm >= 150 && heightInCm <= 193;
            }
            else if (height.EndsWith("in"))
            {
                var heightInCm = int.Parse(height.Substring(0, height.Length - 2));
                return heightInCm >= 59 && heightInCm <= 76;
            }
            else
                return false;
        }

        private bool IsValidHairColor(string color)
        {
            if (color.Length != 7)
                return false;
            if (color[0] != '#')
                return false;

            for (int i = 1; i < color.Length; i++)
                if (!IsHexLetter(color[i]))
                    return false;

            return true;
        }

        private bool IsHexLetter(char c)
        {
            return (c >= '0' && c <= '9')
                || (c >= 'a' && c <= 'f');
        }

        private bool IsValidEyeColor(string color)
        {
            var set = new HashSet<string>()
            {
                "amb",
                "blu",
                "brn",
                "gry",
                "grn",
                "hzl",
                "oth"
            };

            return set.Contains(color);
        }

        private bool IsValidPassportId(string id)
        {
            if (id.Length != 9)
                return false;

            for (int i = 0; i < id.Length; i++)
                if (!Char.IsDigit(id[i]))
                    return false;

            return true;
        }
    }
}
