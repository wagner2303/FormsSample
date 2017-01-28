using SQLite.Net;

namespace FormsSample {
	public interface ISQLite {
		SQLiteConnection GetConnection ();
		SQLiteConnection GetConnection (string DBFileName);
		string GetDBPath ();
		void SaveDBFile(string fileName, byte[] file);
		bool FileExists(string fileName);
	}
}

