//
//  UnitOfWork.cs
//
//  Author:
//       Wagner Teixeira <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//
using FormsSample.Models;
using FormsSample.Repositories.Interfaces;
using SQLite.Net;

namespace FormsSample.Repositories {
	public class UnitOfWork : IUnitOfWork{
		public UnitOfWork(ISQLite sqlite) {
			DB = sqlite.GetConnection();

			_AlunoRepository = new GenericRepository<Aluno, long>(DB, DBLocker);

			lock (DBLocker) {
				DB.CreateTable<Aluno>();
			}
		}

		static object DBLocker = new object();
		readonly SQLiteConnection DB;

		IGenericRepository<Aluno, long> _AlunoRepository;
		public IGenericRepository<Aluno, long> AlunoRepository {
			get {
				return _AlunoRepository;
			}
		}
	}
}
