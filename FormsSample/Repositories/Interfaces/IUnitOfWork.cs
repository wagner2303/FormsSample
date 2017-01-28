//
//  IUnitOfWork.cs
//
//  Author:
//       Wagner Rodrigo <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//
using FormsSample.Models;
namespace FormsSample.Repositories.Interfaces {
	public interface IUnitOfWork {
		IGenericRepository<Aluno, long> AlunoRepository { get; }
	}
}
