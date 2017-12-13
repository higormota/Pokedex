using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Pokedex.Database;
using Pokedex.Droid.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]
namespace Pokedex.Droid.Database
{
    class SqliteService : ISQLite
    {
        public SqliteService() { }

        #region ISQLite implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "pokedex.db3";
            string documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroidN();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            // Return the database connection 
            return conn;
        }

        #endregion
    }
}