using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public class EnvironmentAlert:IAlert
    {
        public string Message { get; private set; }

        public EnvironmentAlert(string message)
        {
            Message = message;
        }

        public void Execute()
        {
            Console.WriteLine("ENVIRONMENT ERORR!!!");
        }
    }
}
