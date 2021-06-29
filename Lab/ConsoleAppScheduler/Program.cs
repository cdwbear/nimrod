using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppScheduler
{
    class Program
    {
        private static Timer MadaketTimer { get; set; }

        static void Main(string[] args)
        {
            MadaketTimer = new Timer();
        }
    }
}
