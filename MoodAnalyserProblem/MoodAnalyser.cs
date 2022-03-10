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
            //Custom Exception Handling
            try
            {
                if (this.message.Equals(null))
                {
                    throw new MoodNullException("Message should not be null");
                }
                else if (this.message.Equals(string.Empty))
                {
                    throw new MoodEmptyException("Message should not be empty");
                }
                else if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (MoodNullException)
            {
                return "HAPPY";
            }
            catch (MoodEmptyException ex)
            {
                Console.WriteLine(ex.Message);
                return "HAPPY";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "HAPPY";
            }
        }
    }
}
