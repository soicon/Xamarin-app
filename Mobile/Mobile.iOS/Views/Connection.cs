using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Mobile.iOS.Views;
using Mobile.Repository;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Connection))]
namespace Mobile.iOS.Views
{
    class Connection : IConnection
    {
        public void SetConnection()
        {
            var sqliteFilename = "VikingVnrc.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            App._connection = conn;
        }
    }
}