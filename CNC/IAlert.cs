using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC
{
    public interface IAlert
    {
        string Message { get; }
        void Execute();
    }
}
