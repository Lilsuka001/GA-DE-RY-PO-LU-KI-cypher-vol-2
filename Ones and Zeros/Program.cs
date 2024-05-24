using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = "regulaminowy";
            string inputString = "Hmdr nge brres";
            Encode(inputString, key);
            Decode(inputString, key);
        }
        public static Dictionary<char, char> GenerateDic(string key)
        {
            string code = key;
            Dictionary<char, char> encoder = new Dictionary<char, char>();
            for (int i = 0; i < key.Length; i += 2)
            {
                char firstChar = key[i];
                char secondChar = key[i + 1];
              
                encoder.Add(char.ToUpper(firstChar), char.ToUpper(secondChar));
                encoder.Add(char.ToLower(firstChar), char.ToLower(secondChar));
                encoder.Add(char.ToUpper(secondChar), char.ToUpper(firstChar));
                encoder.Add(char.ToLower(secondChar), char.ToLower(firstChar));
            }
            return encoder;
        }
        public static string Encode(string str, string key)
        {
            Dictionary<char, char> encoder = GenerateDic(key);

            StringBuilder encryptedStr = new StringBuilder();

            foreach (char c in str)
            {
                if (encoder.ContainsValue(c))
                {
                    encryptedStr.Append(encoder[c]);
                }
                else
                {
                    encryptedStr.Append(c);
                }
            }
            Console.WriteLine(encryptedStr);
            return encryptedStr.ToString();
        }

        public static string Decode(string str, string key)
        {

            return Encode(str,key);
        }

    }
}