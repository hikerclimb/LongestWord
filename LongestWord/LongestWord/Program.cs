using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestWord
{
    class Program
    {
        public static string CheckIfCharactersMatch(string a, string b, string c)
        {
            Console.WriteLine("a:" + a);
            Console.WriteLine("b:" + b);
            Console.WriteLine("c:" + c);

            bool output = false;

            string forward = a + b;

            for(int index = 0; index < c.Length; index++)
            {
                if(Char.ToLower(forward[index]) == Char.ToLower(c[index]))
                {
                    output = true;
                    continue;
                }
                else
                {
                    output = false;
                    break;
                }
            }

            string backward = b + a;
            for (int index = 0; index < c.Length; index++)
            {
                if (Char.ToLower(backward[index]) == Char.ToLower(c[index]))
                {
                    output = true;
                    continue;
                }
                else
                {
                    output = false;
                    break;
                }
            }

            Console.WriteLine(output);

            if(output == true)
            {
                return c;
            }
            else
            {
                return "";
            }
        }

        static void Main(string[] args)
        {
            string line = "";

            List<KeyValuePair<int, string>> lines = new List<KeyValuePair<int, string>>();

            while (!String.IsNullOrWhiteSpace(line=Console.ReadLine()))
            {
                lines.Add(new KeyValuePair<int, string>(line.Length, line));
            }

            lines = lines.OrderBy(x => x.Value.Length).ToList();
            int longestWord = 0;
            string a = "";
            string b = "";
            string c = "";

            for (int summation = 1; summation < lines.Count - 2; summation++)
            {
                for(int equalTo = 2; equalTo < lines.Count; equalTo++)
                {
                    if(lines[summation].Key + lines[summation+1].Key == lines[equalTo].Key)
                    {
                        //Console.WriteLine("summation:" + summation + "equalTo:" + equalTo);
                        if (longestWord < lines[equalTo].Key)
                        {
                            a = lines[summation].Value;
                            b = lines[summation + 1].Value;
                            c = lines[equalTo].Value;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine(CheckIfCharactersMatch(a, b, c));
            Console.ReadKey();
        }
    }
}