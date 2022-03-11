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

        //UC5 - Using Reflection Create MoodAnalyser with parameter constructor
        public static object CreateMoodAnalyserParameterObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD, "Could not find constructor");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_CLASS, "Could not find class");
            }

            //UC6 - Use Reflector to invoke MoodAnalyzer method 
            static string InvokeMoodAnalyser(string message, string methodName)
            {
                try
                {
                    Type type = typeof(MoodAnalyser);
                    MethodInfo methodInfo = type.GetMethod(methodName);
                    object moodAnalyserObject = CreateMoodAnalyserParameterObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                    object info = methodInfo.Invoke(moodAnalyserObject, null);
                    return info.ToString();
                }
                catch (NullReferenceException)
                {

                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD, "Method not found");
                }
            }
        }

        public static string InvokeMoodAnalyser(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
