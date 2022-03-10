using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        /// <summary>
        /// Analysing mood from message
        /// </summary>
        public string message;

        //Constructor for initializing the message
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
      
        //Method to analyse mood form a given message
        public string AnalyseMood()
        {
            try
            {
                if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                return "HAPPY";
            }
        }
    }
}
