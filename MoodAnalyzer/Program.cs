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
                if(mood == "Happy")
                {
                    return "Happy";
                    //Console.WriteLine("Happy");
                }else if(mood == "Sad")
                {
                    return "Sad";
                   // Console.WriteLine("Sad");
                }
                else
                {
                    return "-1";
                }
            }
        }

        static void Main(string[] args)
        {
            
        }
    }
}
