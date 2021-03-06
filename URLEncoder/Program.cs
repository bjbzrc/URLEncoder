﻿using System;
using System.Collections.Generic;

namespace URLEncoder
{
    class Program
    {
        static Dictionary<string, string> conversions = new Dictionary<string, string>
        {
            {" ", "%20"}, {"<", "%3C"}, {">", "%3E"}, {"#", "%23"}, {"\"", "%22"}, {";", "%3B"},
            {"/", "%2F"}, {"?", "%3F"}, {":", "%3A"}, {"@", "%40"}, {"&", "%26"}, {"=", "%3D"},
            {"+", "%2B"}, {"$", "%24"}, {",", "%2C"}, {"{", "%7B"}, {"}", "%7D"}, {"|", "%7C"},
            {"\\", "%5C"}, {"^", "%5E"}, {"[", "%5B"}, {"]", "%5D"}, {"`", "%60"}
        };

        static List<int> characters = new List<int>(new int[]
        {
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D,
            0x0E, 0x0F, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B,
            0x1C, 0x1D, 0x1E, 0x1F, 0x7F
        });

        static string GetUserInput()
        {
            string input = "";
            bool check = false;

            while (!check)
            {
                input = Console.ReadLine();
                check = true;

                foreach (char c in input.ToCharArray())
                {
                    if (characters.Contains(c))
                    {
                        Console.WriteLine("Invalid character, please re-enter: ");

                        check = false;
                    }
                }
            }

            return input;
        }

        static string Encode(string value)
        {
            value = value.Replace("%", "%25");

            foreach (var conversion in conversions)
            {
                value = value.Replace(conversion.Key, conversion.Value);
            }

            return value;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("URL Encoder");

            do
            {
                Console.Write("\nProject name: ");
                string projectName = Encode(GetUserInput());

                Console.Write("Activity name: ");
                string activityName = Encode(GetUserInput());

                Console.WriteLine("https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf",
                    projectName, activityName);

                Console.Write("Would you like to do another? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }
    }
}
