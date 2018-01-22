using System;
namespace ConsoleApplication.Common
{
    public class StopWatch
    {
        DateTime dt = DateTime.Now;
        public double ElapsedTime()
        {
            var ts = DateTime.Now - dt;
            return ts.TotalMilliseconds;
        }
    }
}
