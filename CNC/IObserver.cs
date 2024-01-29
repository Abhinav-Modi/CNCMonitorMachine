using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public interface IObserver
    {
         void Update(float temperature, float dimension, int duration, byte selfstatuscode, DateTime timestamp);
    }
}
