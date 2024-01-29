using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public interface IAlertNotifier
    {
        void Notify(IAlert alert);
    }
}
