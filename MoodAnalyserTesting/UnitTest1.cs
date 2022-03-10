using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace MoodAnalyserTesting
{
    [TestClass]
    public class MoodAnasylserTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            [TestMethod]
            // Test Case -1
            [TestCategory("Sad Message")]
            void TestSadMoodInMessage()
            {
                //Arrange
                string message = "I am in sad Mood";
                string expected = "SAD";
                MoodAnalyser moodAnalyzer = new MoodAnalyser(message);

                //Act
                string actual = moodAnalyzer.AnalyseMood();

                //Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            // Test Case -2
            [TestCategory("Happy Message")]
            void TestHappyMoodInMessage()
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
        }
    }
}