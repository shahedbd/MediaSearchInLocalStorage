using SearchMediaFiles.LIB;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //int mediaType = (int)MediaExtensionsTypes.Video;

                //Console.WriteLine("Started....");
                //Stopwatch stopWatch = new Stopwatch();
                //stopWatch.Reset();
                //stopWatch.Start();
                //var result = Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[mediaType]);
                //Console.WriteLine("Total execution time: " + stopWatch.Elapsed.TotalSeconds);
                //Console.WriteLine("The End....");

                //var fileLoc = Utilities.OutputDirCustom + "\\" + Utilities.fileNames[mediaType];
                //File.WriteAllLines(fileLoc, result, Encoding.UTF8);


                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Reset();
                stopWatch.Start();
                Task task1 = Task.Factory.StartNew(() => Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[(int)MediaExtensionsTypes.Video], 0));
                Task task2 = Task.Factory.StartNew(() => Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[(int)MediaExtensionsTypes.Audio], 1));
                Task task3 = Task.Factory.StartNew(() => Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[(int)MediaExtensionsTypes.Image], 2));

                Task.WaitAll(task1, task2, task3);
                Console.WriteLine("All threads complete");
                Console.WriteLine("Total execution time: " + stopWatch.Elapsed.TotalSeconds);
                Console.WriteLine("The End....");


                //Thread FirstThread = new Thread(new ThreadStart(UpdatesMediaFiles.UpdateAllFiles));
                //FirstThread.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }
    }
}
