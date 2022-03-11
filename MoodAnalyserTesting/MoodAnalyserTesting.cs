using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace MoodAnalyserTesting
{
    [TestClass]
    public class MoodAnalyserTesting
    {
        //Method to test Sad Mood
        [TestMethod]
        [TestCategory("Sad Message")]
        public void TestMehod1()
        {
            //Arrange
            string message = "I am in sad Mood";
            string expected = "SAD";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);

            //Act
            string actual = moodAnalyser.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Method to test Happy Mood
        [TestMethod]
        [TestCategory("Happy Message")]
        public void TestMethod2()
        {
            //Arrange
            string message = "I am in Any Mood";
            string expected = "HAPPY";
            MoodAnalyser moodAnalyzer = new MoodAnalyser(message);

            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Method to test Happy Mood in null message
        [TestMethod]
        [TestCategory("Null Exception")]
        public void TestMethod3()
        {
            //Arrange
            string message = null;
            string expected = "HAPPY";
            MoodAnalyser moodAnalyzer = new MoodAnalyser(message);

            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        //TC 3.1 - Method to test Custom exception for null message
        [TestMethod]
        [TestCategory("Custom Exception")]
        [DataRow(null, "Message should not be null")]
        [DataRow("", "Message should not be empty")]
        public void TestMethod4(string userInput, string expected)
        {
            //Arrange
            //string message = null;
            //string expected = "HAPPY";
            MoodAnalyser moodAnalyzer = new MoodAnalyser(userInput);
            try
            {
                //Act
                string actual = moodAnalyzer.AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                //Assert
                Assert.AreEqual(expected, ex.Message);
            }
        }

        //TC 4.1 - Proper class details are provided and expected to return the MoodAnalyser Object
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyserProblem.Reflection.Customer", "Customer")]
        public void GivenMoodAnalyzerClassName_ReturnMoodAnalyzerObject(string className, string constructorName)
        {
            MoodAnalyser expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.CreateMoodAnalyse(className, constructorName);
            expected.Equals(actual);
        }

        //TC 4.2 - improper class details are provided and expected to throw exception Class not found
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyzerProblem.Reflection.Owner", "Reflection.Owner", "Class not found")]
        public void GivenImproperClassName_ThrowException(string className, string constructorName, string expected)
        {
            try
            {
                object actual = MoodAnalyserFactory.CreateMoodAnalyse(className, constructorName);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }

        //TC 4.3 - improper constructor details are provided and expected to throw exception Constructor not found
        [TestMethod]
        [TestCategory("Reflection")]
        [DataRow("MoodAnalyzerProblem.Reflection.Customer", "Reflection.OwnerMood", "Constructor not found")]
        public void GivenImproperConstructorName_ThrowException(string className, string constructorName, string expected)
        {
            try
            {
                object actual = MoodAnalyserFactory.CreateMoodAnalyse(className, constructorName);
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
