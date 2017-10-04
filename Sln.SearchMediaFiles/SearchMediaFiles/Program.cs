using SearchMediaFiles.LIB;
using System;
using System.Diagnostics;
using System.Threading;

namespace SearchMediaFiles
{
    class Program
    {
        public Program()
        {

        }

        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Started....");
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();


                Thread FirstThread = new Thread(new ThreadStart(UpdatesMediaFiles.UpdateAllFiles));
                FirstThread.Start();

                Console.WriteLine("Total execution time: " + stopWatch.Elapsed.TotalSeconds);
                Console.WriteLine("The End....");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
