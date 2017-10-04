using System;
using System.Collections.Generic;
using System.IO;

namespace SearchMediaFiles
{
    public static class Utilities
    {
        public static readonly string OutputDirCurrent = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        public static readonly string OutputDirCustom = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\Output";

        public static readonly string[] fileNames = { "VideoMediaList.txt", "AudioMediaList.txt", "ImageMediaList.txt", "TotalFilesList.txt", "TotalFoldersList.txt" };

        public static readonly string[] mediaExtensionsVideo = { ".3g2", ".3gp", ".aaf", ".asf", ".avchd", ".avi", ".drc", ".flv", ".m2v", ".m4p", ".m4v", ".mkv", ".mng", ".mov", ".mp2", ".mp4", ".mpe", ".mpeg", ".mpg", ".mpv", ".mxf", ".nsv", ".ogg", ".ogv", ".qt", ".rm", ".rmvb", ".roq", ".svi", ".vob", ".webm", ".wmv", ".yuv", ".wmv" };
        public static readonly string[] mediaExtensionsAudio = new string[] { ".m4a", ".mp3", ".wma", ".3gp", ".aa", ".aac", ".aax", ".act", ".aiff", ".amr", ".ape", ".au", ".awb", ".dct", ".dss", ".dvf", ".flac", ".gsm", ".iklax", ".ivs", ".m4a", ".m4b", ".m4p", ".mmf", ".mp3", ".mpc", ".msv", ".ogg", ".oga", ".mogg", ".opus", ".ra", ".rm", ".raw", ".sln", ".tta", ".vox", ".wav", ".wma", "wv", "webm", ".8svx" };
        public static readonly string[] mediaExtensionsImage = { ".jpg", ".jpeg", ".jpe", ".bmp", ".gif", ".png", ".ico", ".tif", ".tiff", ".wmf" };
        public static readonly string[] mediaExtensionsAll = new string[] { "*.*" };
        public static readonly string[] mediaExtensionsFolders = new string[] { "*" };

        public static readonly string[][] searchTypesList = new string[][] { mediaExtensionsVideo, mediaExtensionsAudio, mediaExtensionsImage, mediaExtensionsAll, mediaExtensionsFolders };



        public static bool IsIgnorable(string dir)
        {
            if (dir.EndsWith("System Volume Information")) return true;
            if (dir.Contains("$RECYCLE.BIN")) return true;
            if (dir.Contains("$Recycle.Bin")) return true;
            if (dir.Contains("Config.Msi")) return true;
            return false;
        }


        public static double FileSizeInGB(string FileLoc)
        {
            double length = 0;
            if (FileLoc.Length < 248)
            {
                length = new FileInfo(FileLoc).Length;
            }

            return Math.Round(length / (1024 * 1024 * 1024), 2); ;
        }


        public static double FileNameLenght(string FileLoc)
        {
            FileInfo oFileInfo = new FileInfo(FileLoc);
            return oFileInfo.Name.Length;
        }


        public static string FilePathWriteTo(string FileName)
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\Output\\" + FileName;
        }


        public static List<string> FileToList(string FileLoc)
        {
            List<string> result = new List<string>(File.ReadAllLines(FileLoc));
            return result;

        }


    }
}
