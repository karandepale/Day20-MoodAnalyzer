using System;
using System.Reflection;

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
                MoodAnalyzerClass obj = MoodAnalyzerFactory.CreateMoodAnalyzer();
                string result = obj.AnalyzeMood();
                Console.WriteLine(result);
            }
            catch (MoodAnalysisException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class MoodAnalyzerFactory
    {
        public static MoodAnalyzerClass CreateMoodAnalyzer()
        {
            Type moodAnalyzerType = typeof(MoodAnalyzerClass);
            ConstructorInfo constructor = moodAnalyzerType.GetConstructor(Type.EmptyTypes);
            MoodAnalyzerClass moodAnalyzer = (MoodAnalyzerClass)constructor.Invoke(null);
            return moodAnalyzer;
        }
    }

    public class MoodAnalyzerClass
    {
        private string mood;

        public MoodAnalyzerClass()
        {
            this.mood = "Default Mood";
        }

        public string AnalyzeMood()
        {
            if (string.IsNullOrEmpty(mood))
            {
                throw new MoodAnalysisException("Empty Mood");
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
