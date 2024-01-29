using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public class ConsoleAlertNotifier : IAlertNotifier
    {
        public void Notify(IAlert alert)
        {
            Console.WriteLine($"Alert: {alert.Message}");
            alert.Execute();
        }
    }
}
