using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    }
}
