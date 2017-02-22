using System;
using System.IO;
using FormAssistControl.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteDroid))]
namespace FormAssistControl.Droid
{
	public class SQliteDroid:ISQLite
	{
		public SQliteDroid()
		{
		}

		SQLiteConnection ISQLite.GetConnection()
		{
			SQLitePCL.Batteries.Init();
			var sqliteFilename = "TodoSQlite.db3";
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, sqliteFilename);
			var conn = new SQLite.SQLiteConnection(path);
			return conn;
		}
	}
}
