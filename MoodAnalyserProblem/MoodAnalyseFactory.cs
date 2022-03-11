using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// default Constructor - Create MoodAnalyserFactory and specify static method to create MoodAnalyser Object
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserException"></exception>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (ArgumentNullException)
                {

                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD, "Constructor not found");
            }
        }
    }
}
