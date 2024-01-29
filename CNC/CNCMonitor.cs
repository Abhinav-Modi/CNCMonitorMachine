using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public class CNCMonitor :ISubject
    {
        private readonly List<IObserver> machineObservers = new List<IObserver>();
        private readonly List<IObserver> environmentObservers = new List<IObserver>();
        public void AddObserver(IObserver observer, bool isMachineObserver) {
            if (observer == null) throw new ArgumentNullException(nameof(observer));
            else if (isMachineObserver) machineObservers.Add(observer);
            else environmentObservers.Add(observer);
        }
        public void RemoveObserver(IObserver observer) {
            machineObservers.Remove(observer);
            environmentObservers.Remove(observer);
        }
        public void UpdateCNCData(float temperature, float dimension, int duration, byte selfstatuscode,DateTime timestamp) {
            foreach(IObserver observer in machineObservers)
            {
                observer.Update(temperature, dimension, duration, selfstatuscode, timestamp);
            }
            foreach (IObserver observer in environmentObservers) 
            { 
                observer.Update(temperature,dimension, duration, selfstatuscode,timestamp);            
            }
        }
    }
}
