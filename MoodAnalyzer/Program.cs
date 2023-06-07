using System;

namespace MoodAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyzerClass obj = new MoodAnalyzerClass("I am in sad mood");
            string result = obj.AnalyzeMood();
            Console.WriteLine(result);
        }
    }

    public class MoodAnalyzerClass
    {
        private string mood;

        public MoodAnalyzerClass(string mood)
        {
            this.mood = mood;
        }

        public string AnalyzeMood()
        {
            if (mood.Contains("I am in any mood"))
            {
                return "Happy";
            }
            else if (mood.Contains("I am in sad mood"))
            {
                return "Sad";
            }
            else
            {
                return "Invalid";
            }
        }
    }
}
