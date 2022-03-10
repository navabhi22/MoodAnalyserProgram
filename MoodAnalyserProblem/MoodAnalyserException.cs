using System.Runtime.Serialization;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserException : Exception
    {
        public ExceptionTypes type;

        //Enum to differentiate mood analysis errors
        public enum ExceptionTypes
        {
            NULL_MOOD_EXCEPTION,
            EMPTY_MOOD_EXCEPTION
        }

        //Constructor to initialize ExceptionTypes
        public MoodAnalyserException(ExceptionTypes type, string message) : base(message)
        {
            this.type = type;
        }
    }
}