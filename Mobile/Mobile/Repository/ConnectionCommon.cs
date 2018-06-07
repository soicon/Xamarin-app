using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Mobile.Repository
{
    public class Connection
    {
        public static string GetConnection()
        {
            var sqliteFilename = "VikingVnrc.db3";
            if (Device.RuntimePlatform == Device.iOS)
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libraryPath = Path.Combine(documentsPath, "..", "Library");
                var path = Path.Combine(libraryPath, sqliteFilename);
                if (!File.Exists(path)) File.Create(path);
                return path;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, sqliteFilename);
                if (!File.Exists(path)) File.Create(path);
                return path;
            }
            else
            {
                return "";
            }
        }
    }
}
