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
                MoodAnalyzerClass obj1 = MoodAnalyzerFactory.CreateMoodAnalyzer("I am in a happy mood");
                MoodAnalyzerClass obj2 = MoodAnalyzerFactory.CreateMoodAnalyzer("I am in a happy mood");

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
        public static MoodAnalyzerClass CreateMoodAnalyzer(string message)
        {
            try
            {
                string className = "MoodAnalyzerClass"; // Provide the class name here

                Type moodAnalyzerType = Type.GetType(className);
                if (moodAnalyzerType == null)
                {
                    throw new MoodAnalysisException("No Such Class Error");
                }

                ConstructorInfo constructor = moodAnalyzerType.GetConstructor(new[] { typeof(string) });

                if (constructor == null)
                {
                    throw new MoodAnalysisException("No Such Constructor Error");
                }

                MoodAnalyzerClass moodAnalyzer = (MoodAnalyzerClass)constructor.Invoke(new object[] { message });
                return moodAnalyzer;
            }
            catch (TargetException ex)
            {
                throw new MoodAnalysisException("No Such Constructor Error");
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
