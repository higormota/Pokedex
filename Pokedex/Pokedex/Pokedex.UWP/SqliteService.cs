using Pokedex.Database;
using Pokedex.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]
namespace Pokedex.UWP
{
    class SqliteService : ISQLite
    {
        public SqliteService() { }

        #region ISQLite implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "pokedex.db3";
            string documentsPath = ApplicationData.Current.LocalFolder.Path; // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            // Return the database connection 
            return conn;
        }

        #endregion
    }
}
