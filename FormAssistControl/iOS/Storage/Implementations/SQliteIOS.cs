using System;
using System.IO;
using FormAssistControl.IOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteIOS))]
namespace FormAssistControl.IOS
{
	public class SQliteIOS:ISQLite
	{
		public SQliteIOS()
		{
		}

		SQLiteConnection ISQLite.GetConnection()
		{
			//SQLitePCL.Batteries.Init();
			var sqliteFilename = "TodoSQlite.db3";
			string documentsPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "..", "Library", "Databases");
			if (!Directory.Exists(libraryPath))
			{
				Directory.CreateDirectory(libraryPath);
			}
			var path = Path.Combine(libraryPath,sqliteFilename);
			var conn = new SQLite.SQLiteConnection(path);
			return conn;
		}
	}
}
