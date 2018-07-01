using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SearchMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Started....");
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();

                //var result = Helper.SearchInLocalDrivesAllFiles();
                var result = Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[0]);


                Console.WriteLine("Total execution time: " + stopWatch.Elapsed.TotalSeconds);
                Console.WriteLine("The End....");


                var fileToCreate = Utilities.OutputDirCustom + "\\" + Utilities.fileNames[0];
                File.WriteAllLines(fileToCreate, result, Encoding.UTF8);

                //Console.WriteLine("Started....");
                //Stopwatch stopWatch = new Stopwatch();
                //stopWatch.Reset();
                //stopWatch.Start();


                //Thread FirstThread = new Thread(new ThreadStart(UpdatesMediaFiles.UpdateAllFiles));
                //FirstThread.Start();

                //Console.WriteLine("Total execution time: " + stopWatch.Elapsed.TotalSeconds);
                //Console.WriteLine("The End....");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
