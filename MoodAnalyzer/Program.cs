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
                MoodAnalyzerClass obj1 = MoodAnalyzerFactory.CreateMoodAnalyzer();
                MoodAnalyzerClass obj2 = MoodAnalyzerFactory.CreateMoodAnalyzer();

                Console.WriteLine("Object 1: " + obj1);
                Console.WriteLine("Object 2: " + obj2);
                Console.WriteLine("Objects are equal: " + obj1.Equals(obj2));
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
            try
            {
                Type moodAnalyzerType = typeof(MoodAnalyzerClass);
                ConstructorInfo constructor = moodAnalyzerType.GetConstructor(Type.EmptyTypes);
                MoodAnalyzerClass moodAnalyzer = (MoodAnalyzerClass)constructor.Invoke(null);
                return moodAnalyzer;
            }
            catch (TargetInvocationException ex)
            {
                throw new MoodAnalysisException("No Such Class Error");
            }
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MoodAnalyzerClass other = (MoodAnalyzerClass)obj;
            return mood == other.mood;
        }

        public override int GetHashCode()
        {
            return mood.GetHashCode();
        }

        public override string ToString()
        {
            return mood;
        }
    }
}
