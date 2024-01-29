using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public class MachineAlert:IAlert
    {
        public string Message { get; private set; }

        public MachineAlert(string message)
        {
            Message = message;
        }

        public void Execute() { 
            Console.WriteLine("MACHINE ERORR!!!");
        }
    }
}
