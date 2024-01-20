
using System;
using System.Collections.Generic;
using System.Linq;

public class HomofonicCipher
{
    private static readonly Dictionary<char, List<string>> Homophones = new Dictionary<char, List<string>>
    {
        {'A', new List<string> {"01","15","28","35","57","22","90","91","47","99","13"}},
        {'Ą', new List<string> {"25","64"}},
        {'B', new List<string> {"12","36","96"}},
        {'C', new List<string> {"18","17","33"}},
        {'Ć', new List<string> {"69"}},
        {'D', new List<string> {"07", "77"}},
        {'E', new List<string> {"66", "10","59","27","82","61","55"}},
        {'Ę', new List<string> {"86","05"}},
        {'F', new List<string> {"30", "62"}},
        {'G', new List<string> {"02", "74"}},
        {'H', new List<string> {"87", "34"}},
        {'I', new List<string> {"26", "41","71","89","19","52","38","81"}},
        {'J', new List<string> {"95", "44","23"}},
        {'K', new List<string> {"08", "58","24","37"}},
        {'L', new List<string> {"67", "85","48"}},
        {'Ł', new List<string> {"73", "32"}},
        {'M', new List<string> {"21", "65","80","29"}},
        {'N', new List<string> {"60", "09","70","78"}},
        {'Ń', new List<string> {"94", "53"}},
        {'O', new List<string> {"83", "06","68","79","111","101","128"}},
        {'Ó', new List<string> {"39", "50"}},
        {'P', new List<string> {"75", "76","121","189","177","122","164"}},
        {'Q', new List<string> {"54"}},
        {'R', new List<string> {"46", "15","188"}},
        {'S', new List<string> {"03", "97", "133","110","115"}},
        {'Ś', new List<string> {"72", "31"}},
        {'T', new List<string> {"63", "45","175","199","129"}},
        {'U', new List<string> {"88", "11","147","119","169","125","185"}},
        {'V', new List<string> {"42"}},
        {'W', new List<string> {"51", "20","191","166","117","172"}},
        {'X', new List<string> {"40"}},
        {'Y', new List<string> {"84", "49"}},
        {'Z', new List<string> {"04", "14"}},
        {'Ź', new List<string> {"56", "98"}},
        {'Ż', new List<string> {"92", "43"}}
    };

    public static string Encrypt(string input)
    {
        input = input.ToUpper();
        string result = "";

        foreach (char c in input)
        {
            if (Homophones.ContainsKey(c))
            {
                List<string> possibleCodes = Homophones[c];
                Random rand = new Random();
                int index = rand.Next(possibleCodes.Count);
                result += possibleCodes[index] + " ";
            }
            else
            {
                result += c;
            }
        }

        return result.Trim();
    }

    public static string Decrypt(string input)
    {
        string[] codes = input.Split(' ');
        string result = "";

        foreach (string code in codes)
        {
            if (code.Length > 0)
            {
                char decodedChar = FindDecodedChar(code);
                result += decodedChar;
            }
            else
            {
                result += " ";
            }
        }

        return result;
    }

    private static char FindDecodedChar(string code)
    {
        foreach (var pair in Homophones)
        {
            if (pair.Value.Contains(code))
            {
                return pair.Key;
            }
        }

        return ' ';
    }
}
