using System;
using SQLite;

namespace FormAssistControl
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
