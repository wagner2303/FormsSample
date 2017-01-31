//
//  SQLite_iOS.cs
//
//  Author:
//       Wagner Rodrigo <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//
using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FormsSample.iOS.SQLite_iOS))]
namespace FormsSample.iOS {
	public class SQLite_iOS : ISQLite {
		const string sqliteFilename = "dn_name.db";

		public bool FileExists(string fileName) {
			return File.Exists(fileName);
		}

		public SQLiteConnection GetConnection() {
			return GetConnection(sqliteFilename);
		}

		public SQLiteConnection GetConnection(string DBFileName) {
			var path = Path.Combine(GetDBPath(), DBFileName);
			return new SQLiteConnection(new SQLitePlatformIOS(), path);
		}

		public string GetDBPath() {
			return Path.Combine(
				Environment.GetFolderPath(
					Environment.SpecialFolder.Personal
				), 
				"..", 
				"Library"
			);
		}

		public void SaveDBFile(string fileName, byte[] file) {
			File.WriteAllBytes(Path.Combine(GetDBPath(), fileName), file);
		}
	}
}
