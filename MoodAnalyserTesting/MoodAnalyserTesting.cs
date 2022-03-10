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
        public void GivenNullMessageReturnHappyMood()
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
    }
}
