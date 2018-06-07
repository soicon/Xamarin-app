using Mobile.Repository;
using System;
using System.IO;

namespace Mobile.Droid.Views
{
    [assembly: Dependency(typeof(FileHelper))]
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}