using System;
using System.Collections.Generic;

public class Mixing
{
    public static string Mix(string s1, string s2)
    {
        Dictionary<char, int> dictS1 = new Dictionary<char, int>();
        Dictionary<char, int> dictS2 = new Dictionary<char, int>();
        Dictionary<char, int> even = new Dictionary<char, int>();
        List<int> lettersCount = new List<int>();
        List<string> resultList = new List<string>();
        string result;

        //creating 2 alphabetically sorted dictionaries representing letters and their count of each given string
        for (char c = 'a'; c <= 'z'; c++)
        {
            foreach (char s in s1)
            {
                if (s == c && !dictS1.ContainsKey(s)) { dictS1.Add(s, 1); }
                else if (s == c && dictS1.ContainsKey(s)) { dictS1[s]++; }

            }
            foreach (char s in s2)
            {
                if (s == c && !dictS2.ContainsKey(s)) { dictS2.Add(s, 1); }
                else if (s == c && dictS2.ContainsKey(s)) { dictS2[s]++; }
            }
        }

        // creating list of counts to sort and getting rid of once repeated letters
        foreach (int i in dictS1.Values) { if (i > 1 && !lettersCount.Contains(i)) { lettersCount.Add(i); } }
        foreach (int i in dictS2.Values) { if (i > 1 && !lettersCount.Contains(i)) { lettersCount.Add(i); } }
        lettersCount.Sort();
        lettersCount.Reverse();

        // creating dictionary with even letters and valuse from both give strings and getting rid of duplicates from each dictionary
        foreach (char c in dictS1.Keys) { if (dictS2.ContainsKey(c) && dictS1[c] == dictS2[c]) { even.Add(c, dictS1[c]); } }
        foreach (char c in even.Keys) { dictS1.Remove(c); dictS2.Remove(c); }
        foreach (char c in dictS1.Keys) { if (dictS2.ContainsKey(c) && dictS1[c] > dictS2[c]) { dictS2.Remove(c); } }
        foreach (char c in dictS2.Keys) { if (dictS1.ContainsKey(c) && dictS2[c] > dictS1[c]) { dictS1.Remove(c); } }

        // consistently creating the result ordered by length -> alphabetical order -> even appearing
        foreach (int i in lettersCount)
        {
            foreach (char c in dictS1.Keys) { if (dictS1[c] == i) { resultList.Add("1:" + new String(c, dictS1[c])); } }

            foreach (char c in dictS2.Keys) { if (dictS2[c] == i) { resultList.Add("2:" + new String(c, dictS2[c])); } }

            foreach (char c in even.Keys) { if (even[c] == i) { resultList.Add("=:" + new String(c, even[c])); } }
        }

        result = String.Join("/", resultList);
        return result;
    }
}