﻿namespace SearchMediaFiles
{
    public static class Utilities
    {
        public static string[] mediaExtensionsTMP = { ".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", ".WAV", ".MID", ".MIDI", ".WMA", ".MP3", ".OGG", ".RMA", ".AVI", ".MP4", ".DIVX", ".WMV" };
        public static string[] mediaExtensionsVideo = { ".3g2", ".3gp", ".aaf", ".asf", ".avchd", ".avi", ".drc", ".flv", ".m2v", ".m4p", ".m4v", ".mkv", ".mng", ".mov", ".mp2", ".mp4", ".mpe", ".mpeg", ".mpg", ".mpv", ".mxf", ".nsv", ".ogg", ".ogv", ".qt", ".rm", ".rmvb", ".roq", ".svi", ".vob", ".webm", ".wmv", ".yuv", ".wmv" };
        public static string[] mediaExtensionsImage = { ".jpg", ".jpeg", ".jpe", ".bmp", ".gif", ".png", ".ico", ".tif", ".tiff", ".wmf" };


        public static bool IsIgnorable(string dir)
        {
            if (dir.EndsWith("System Volume Information")) return true;
            if (dir.Contains("$RECYCLE.BIN")) return true;
            if (dir.Contains("$Recycle.Bin")) return true;
            if (dir.Contains("Config.Msi")) return true;
            return false;
        }
    }
}