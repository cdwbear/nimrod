using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            int iptrSize = IntPtr.Size;
            var longSize = sizeof(long);
            bool is64bitProcess = Environment.Is64BitProcess;
            bool is64BitOsSystem = Environment.Is64BitOperatingSystem;

            Console.WriteLine($"iptrSize = {iptrSize}, longSize = {longSize}");
            Console.ReadLine();
        }
    }
}
