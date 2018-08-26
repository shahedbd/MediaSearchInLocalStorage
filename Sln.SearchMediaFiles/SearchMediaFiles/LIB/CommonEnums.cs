namespace SearchMediaFiles.LIB
{
    class CommonEnums
    {
    }

    public enum MediaExtensionsTypes : int
    {
        Video = 0,
        Audio = 1,
        Image = 2,
        All = 3,
        Folders = 4
    }

    public enum SaveIn : int
    {
        VideoMediaList = 0,
        AudioMediaList = 1,
        ImageMediaList = 2,
        TotalFilesList = 3,
        TotalFoldersList = 4
    }
}
