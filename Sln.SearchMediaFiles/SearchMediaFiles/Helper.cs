using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SearchMediaFiles
{
    public static class Helper
    {
        public static List<string> SearchAllDrives(string[] mediaExtensions)
        {
            List<string> filesFound = new List<string>();
            //foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady))
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady && x.Name != "C:\\"))
            {
                string[] DriveFolderList = Directory.GetDirectories(d.ToString());
                foreach (var item in DriveFolderList)
                {
                    if (!Utilities.IsIgnorable(item))
                    {
                        foreach (string f in Directory.GetFiles(item, "*.*", SearchOption.AllDirectories))
                        {
                            if (mediaExtensions.Contains(Path.GetExtension(f).ToLower()))
                            {
                                filesFound.Add(f);
                            }
                        }
                    }
                }

            }
            return filesFound;
        }


        public static List<string> SearchAllDrivesIMG(string[] mediaExtensions)
        {
            List<string> filesFound = new List<string>();
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady && x.Name != "C:\\"))
            {
                string[] DriveFolderList = Directory.GetDirectories(d.ToString());
                foreach (var item in DriveFolderList)
                {
                    if (!Utilities.IsIgnorable(item))
                    {
                        foreach (string f in Directory.GetFiles(item, "*.*", SearchOption.AllDirectories))
                        {
                            if (mediaExtensions.Contains(Path.GetExtension(f).ToLower()))
                            {
                                filesFound.Add(f);
                                Console.WriteLine(f);
                            }
                        }
                    }
                }

            }
            return filesFound;
        }




        public static List<string> Search()
        {
            var files = new List<string>();
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady))
            {
                try
                {
                    files.AddRange(Directory.GetFiles(d.RootDirectory.FullName, "*.txt", SearchOption.AllDirectories));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return files;
        }
    }
}
