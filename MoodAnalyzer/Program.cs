using System;

namespace MoodAnalyzer
{
    public class MoodAnalysisException : Exception
    {
        public MoodAnalysisException(string message) : base(message)
        {
        }
    }

    public enum Mood
    {
        Happy,
        Sad,
        Invalid
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MoodAnalyzerClass obj = new MoodAnalyzerClass(null);
                string result = obj.AnalyzeMood();
                Console.WriteLine(result);
            }
            catch (MoodAnalysisException ex)
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
            if (string.IsNullOrEmpty(mood))
            {
                throw new MoodAnalysisException("MoodAnalysisException");
            }
            else if (mood.Contains("null"))
            {
                return Mood.Happy.ToString();
            }
            else if (mood.Contains("I am in sad mood"))
            {
                return Mood.Sad.ToString();
            }
            else
            {
                return Mood.Invalid.ToString();
            }
        }
    }
}
