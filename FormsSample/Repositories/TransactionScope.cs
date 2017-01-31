//
//  TransactionScope.cs
//
//  Author:
//       Wagner Teixeira <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//
using System;
using FormsSample.Repositories.Interfaces;
using SQLite.Net;

namespace FormsSample.Repositories {
	public class TransactionScope : IDisposable, ITransactionScope {
		
		readonly SQLiteConnection _dataBase;
		string _savePointId;
		bool _completed = false;

		public TransactionScope(ISQLite SQLite) {
			_dataBase = SQLite.GetConnection();
			_savePointId = BeginTransaction();
		}

		public TransactionScope(SQLiteConnection connection) {
			_dataBase = connection;
			_savePointId = BeginTransaction();
		}

		public string BeginTransaction() {
			string savePointId = Guid.NewGuid().ToString();
			_dataBase.Execute("SAVEPOINT '" + savePointId + "';");
			return savePointId;
		}

		public void EndTransaction(string savePointId) {
			_dataBase.Execute("RELEASE SAVEPOINT '" + savePointId + "';");
		}

		public void RollBack(string savePointId) {
			_dataBase.Execute("ROLLBACK TRANSACTION TO SAVEPOINT '" + savePointId + "';");
		}

		public void Complete() {
			_completed = true;
		}

		public void Dispose() {
			if (!_completed) {
				RollBack(_savePointId);
			}
			EndTransaction(_savePointId);
		}
	}
}
