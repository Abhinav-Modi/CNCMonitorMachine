using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public interface ISubject
    {
        void AddObserver(IObserver observer,bool isMachineObserver);
        void RemoveObserver(IObserver observer);
        void UpdateCNCData(float temperature,float dimension, int duration, byte selfstatuscode, DateTime timestamp);   
    }
}
