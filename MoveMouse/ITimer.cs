using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoveMouse
{
    interface ITimer
    {
         void Start();
         void Stop();
         short czasDo { get; set; }
    }
}
