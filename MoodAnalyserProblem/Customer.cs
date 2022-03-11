using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class Customer
    {
        
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }

        

        public Customer(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        public Customer()
        {
            this.Id = -1;
            this.Name = String.Empty;
        }
        //Method To Print Id
        public void PrintId()
        {
            Console.WriteLine("Id is : {0}", this.Id);
        }

        //Method To Print Name
        public void PrintName()
        {
            Console.WriteLine("Name is : {0}", this.Name);
        }
    }
}
