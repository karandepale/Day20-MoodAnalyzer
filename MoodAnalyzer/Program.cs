using System;

namespace MoodAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MoodAnalyzerClass obj = new MoodAnalyzerClass("null");
                string result = obj.AnalyzeMood();
                Console.WriteLine(result);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
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
