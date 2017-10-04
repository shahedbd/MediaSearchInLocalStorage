using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SearchMediaFiles.LIB
{
    public static class UpdatesMediaFiles
    {

        public static void UpdateAllFiles()
        {
            try
            {
                //Dir check
                if (!Directory.Exists(Utilities.OutputDirCustom))
                {
                    Directory.CreateDirectory(Utilities.OutputDirCustom);
                }


                //Files check
                foreach (var item in Utilities.fileNames)
                {
                    var fileToCreate = Utilities.OutputDirCustom + "\\" + item;
                    if (!File.Exists(fileToCreate))
                    {
                        File.Create(fileToCreate).Dispose();
                    }
                }

                int count = 0;
                //Updates Files
                foreach (var item in Utilities.searchTypesList)
                {
                    var fileToCreate = Utilities.OutputDirCustom + "\\" + Utilities.fileNames[count];
                    List<string> result = Helper.CustomSearch(item, Utilities.fileNames[count]);

                    //Write into Files
                    File.WriteAllLines(fileToCreate, result, Encoding.UTF8);
                    count = count + 1;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }








    }
}
