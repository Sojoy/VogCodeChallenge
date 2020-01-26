using System;
using System.Collections.Generic;
using System.Text;

namespace VogCodeChallenge.ConsoleQuestion
{
    public static class QuestionClass
    {
        static List<string> NamesList = new List<string>()
        {
            "Jimmy",
            "Jeffrey"
        };

        public static void TestQuestion()
        {
            //the foreach statement is a straightforward and simpler syntax than directly iterating records using Enumerator object on a collection
            foreach (var name in NamesList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
