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
            string expected = "Happy";
            string actual = obj.AnalyzeMood("I am in any mood");

            // Assert
            Assert.AreEqual(expected, actual);


        }
    }
}