using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForegroundBackgroundThread
{
    internal class ThreadingTest
    {
        readonly int maxIterations;
        public ThreadingTest(int maxIterations)
        {
            this.maxIterations = maxIterations;
        }
        public void RunLoop()
        {
            for (int i = 0; i < maxIterations; i++)
            {
                Console.WriteLine("{0} count: {1}", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread", i);
                Thread.Sleep(250);
            }
            Console.WriteLine("{0} finished counting.", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread");
        }
    }
}
