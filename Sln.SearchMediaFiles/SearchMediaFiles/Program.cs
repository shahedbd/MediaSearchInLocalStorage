using System;
using System.Collections.Generic;

namespace SearchMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            //Search image media
            List<string> ImageFilesList = Helper.SearchAllDrivesIMG(Utilities.mediaExtensionsImage);
            Console.WriteLine("Total Files: " + ImageFilesList.Count);
            Console.WriteLine("Search Completed");

            //Search video media
            //List<string> VideoFilesList = Helper.SearchAllDrives(Utilities.mediaExtensionsVideo);
            //foreach (var item in VideoFilesList)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("Total Files: " + VideoFilesList.Count);
            //Console.WriteLine("Search Completed");

            Console.ReadLine();
        }
    }
}
