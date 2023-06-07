using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class Program
    {

        public class MoodAnalyzerClass
        {
            public string AnalyzeMood(string mood)
            {
                if (mood.Contains("I am in any mood"))
                {
                    return "Happy";
                    //Console.WriteLine("Happy");
                }
                else if (mood.Contains("I am in sad mood"))
                {
                    return "Sad";
                   //  Console.WriteLine("Sad");
                }
                else
                {
                    return "Invalid ";
                }
            }
        }

        static void Main(string[] args)
        {
            MoodAnalyzerClass obj = new MoodAnalyzerClass();
            string result = obj.AnalyzeMood("I am in any mood");
            Console.WriteLine(result);
        }

    }
}