using SearchMediaFiles.LIB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

                //Helper.SearchInLocalDrivesAllFiles(true);
                UsingStopWAndThread();

                //SearchInLocalDrivesAllFiles(true);

                //Thread FirstThread = new Thread(new ThreadStart(UpdatesMediaFiles.UpdateAllFiles));
                //FirstThread.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();

        }





        static void UsingStopWAndThread()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();
            stopWatch.Start();
            Task task1 = Task.Factory.StartNew(() => Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[(int)MediaExtensionsTypes.Video], 0,false));
            Task task2 = Task.Factory.StartNew(() => Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[(int)MediaExtensionsTypes.Audio], 1, false));
            Task task3 = Task.Factory.StartNew(() => Helper.SearchInLocalDrivesByTypes(Utilities.searchTypesList[(int)MediaExtensionsTypes.Image], 2, false));

            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("All threads complete");
            Console.WriteLine("Total execution time: " + stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("The End....");
        }


        static List<string> SearchInLocalDrivesAllFiles(bool CheckSize)
        {
            string path = @"G:\TheGitCloning\UVA-CODES";
            List<string> filesFound = new List<string>();
            //foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady && x.Name != "C:\\"))
            //{             
            //}


            //string[] DriveFolderList = Directory.GetDirectories(path);
            //foreach (var item in DriveFolderList)
            //{              
            //}

            foreach (string f in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                if (!CheckSize)
                {
                    if (Utilities.FileSizeInMB(f) > 100)
                    {
                        filesFound.Add(f);
                        Console.WriteLine(f);
                    }
                }
                else
                {
                    filesFound.Add(f);
                    Console.WriteLine(f);
                }
            }


            var fileLoc = Utilities.OutputDirCustom + "\\" + Utilities.fileNames[3];
            File.WriteAllLines(fileLoc, filesFound, Encoding.UTF8);
            return filesFound;
        }

    }
}
