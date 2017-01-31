//
//  Aluno.cs
//
//  Author:
//       Wagner Teixeira <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//

using SQLite.Net.Attributes;

namespace FormsSample.Models {
	public class Aluno {
		[PrimaryKey, AutoIncrement]
		public long? Id { get; set; }
		public string Nome { get; set;}
		public string Curso { get; set; }
		public string Matricula { get; set; }
	}
}
