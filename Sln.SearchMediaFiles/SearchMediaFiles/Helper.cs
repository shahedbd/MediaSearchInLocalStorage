using SearchMediaFiles.LIB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SearchMediaFiles
{
    public static class Helper
    {
        public static List<string> CustomSearch(string[] mediaExtensions, string fileNames)
        {
            List<string> filesFound = new List<string>();
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady && x.Name != "C:\\"))
            {
                string[] DriveFolderList = Directory.GetDirectories(d.ToString());
                foreach (var item in DriveFolderList)
                {
                    if (!Utilities.IsIgnorable(item))
                    {
                        if (fileNames == "TotalFoldersList.txt")
                        {
                            foreach (string f in Directory.GetDirectories(item, "*", SearchOption.AllDirectories))
                            {
                                filesFound.Add(f);
                                //Console.WriteLine(f);
                            }
                        }
                        else if (fileNames == "TotalFilesList.txt")
                        {
                            foreach (string f in Directory.GetFiles(item, "*.*", SearchOption.AllDirectories))
                            {
                                filesFound.Add(f);
                                //Console.WriteLine(f);
                            }
                        }
                        else
                        {
                            foreach (string f in Directory.GetFiles(item, "*.*", SearchOption.AllDirectories))
                            {
                                if (mediaExtensions.Contains(Path.GetExtension(f).ToLower()))
                                {
                                    filesFound.Add(f);
                                    //Console.WriteLine(f);
                                }
                            }
                        }

                    }
                }

            }
            return filesFound;
        }


        public static List<string> SearchInLocalDrivesByTypes(string[] mediaExtensions, int SaveIN, bool CheckSize)
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
                                if (CheckSize)
                                {
                                    if (Utilities.FileSizeInMB(f) > 1000)
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
                        }
                    }
                }

            }

            var fileLoc = Utilities.OutputDirCustom + "\\" + Utilities.fileNames[SaveIN];
            File.WriteAllLines(fileLoc, filesFound, Encoding.UTF8);
            return filesFound;
        }

        public static List<string> SearchInLocalDrivesAllFiles(bool CheckSize)
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
                            if (CheckSize)
                            {
                                if (Utilities.FileSizeInMB(f) > 1000)
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
                    }
                }

            }

            var fileLoc = Utilities.OutputDirCustom + "\\" + Utilities.fileNames[3];
            File.WriteAllLines(fileLoc, filesFound, Encoding.UTF8);
            return filesFound;
        }


        public static List<string> TestCode(string[] mediaExtensions, int SaveIN, bool CheckSize)
        {
            List<string> filesFound = new List<string>();

            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady))  //&& x.Name != "C:\\"
            {
                string[] DriveFolderList = Directory.GetDirectories(d.ToString());
                foreach (var item in DriveFolderList)
                {
                    if (!Utilities.IsIgnorableTest(item))
                    {
                        foreach (string f in Directory.GetFiles(item, "*.*", SearchOption.AllDirectories))
                        {
                            if (mediaExtensions.Contains(Path.GetExtension(f).ToLower()))
                            {
                                if (CheckSize)
                                {
                                    if (Utilities.FileSizeInMB(f) > 1000)
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
                        }
                    }
                }

            }

            var fileLoc = Utilities.OutputDirCustom + "\\" + Utilities.fileNames[SaveIN];
            File.WriteAllLines(fileLoc, filesFound, Encoding.UTF8);
            return filesFound;
        }

    }
}
