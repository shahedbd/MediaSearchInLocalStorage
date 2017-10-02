using System;
using System.Collections.Generic;

namespace SearchMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            //var abc = Utilities.FileSizeInGB(@"E:\Cine Plex\A Clockwork Orange (1971)\A Clockwork Orange (1971) [1080p].mp4");

            //Search video media
            List<string> VideoFilesList = Helper.SearchAllDrives(Utilities.mediaExtensionsVideo);
            foreach (var item in VideoFilesList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Total Files: " + VideoFilesList.Count);
            Console.WriteLine("Search Completed");


            ////Search image media
            //List<string> ImageFilesList = Helper.SearchAllDrivesIMG(Utilities.mediaExtensionsImage);
            //Console.WriteLine("Total Files: " + ImageFilesList.Count);
            //Console.WriteLine("Search Completed");


            Console.ReadLine();
        }
    }
}
