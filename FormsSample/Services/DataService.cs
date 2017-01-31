//
//  DataService.cs
//
//  Author:
//       Wagner Teixeira <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//
using System;
using System.Collections.Generic;
using FormsSample.Models;
using SQLite.Net;
using FormsSample.Repositories;
using System.Linq;

namespace FormsSample.Services {
	public class DataService {
		public UnitOfWork UnitOfWork { get; private set; }

		public DataService(ISQLite sqlite) {
			UnitOfWork = new UnitOfWork(sqlite);
		}

		public List<Aluno> GetAlunos(){
			return UnitOfWork.AlunoRepository.GetAll().ToList();
		}

		public void SaveAluno(Aluno aluno){
			UnitOfWork.AlunoRepository.AddOrUpdate(aluno);
		}

		public List<Aluno> FindAlunoByNome(string nome){
			return UnitOfWork.AlunoRepository.Find(a => a.Nome == nome).ToList();
		}
	}
}
