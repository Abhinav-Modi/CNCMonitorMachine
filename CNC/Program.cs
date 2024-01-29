using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAlertNotifier alertNotifier = new ConsoleAlertNotifier();
            IObserver machineAlertObserver = new AlertNotifier(alertNotifier);
            IObserver environmentAlertObserver = new AlertNotifier(alertNotifier);
            ISubject cncMonitor = new CNCMonitor();

            cncMonitor.AddObserver(machineAlertObserver, isMachineObserver: true);

            cncMonitor.AddObserver(environmentAlertObserver, isMachineObserver: false);

            cncMonitor.UpdateCNCData(36.0f, 0.6f, 400, 0x01,DateTime.Now);
        }
    }
}
