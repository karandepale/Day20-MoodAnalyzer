using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static MoodAnalyzer.Program;

namespace MoodAnalyzerTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            MoodAnalyzerClass obj = new MoodAnalyzerClass();

            // Act
            string expected = "Sad";
            string actual = obj.AnalyzeMood("I am in sad mood");

            // Assert
            Assert.AreEqual(expected, actual);


        }
    }
}