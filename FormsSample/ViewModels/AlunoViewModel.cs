//
//  AlunoViewModel.cs
//
//  Author:
//       Wagner Teixeira <wagner@sydy.com.br>
//
//  Copyright (c) 2017 
//
using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using FormsSample.Models;
using System.Collections.Generic;
namespace FormsSample.ViewModels {
	public class AlunoViewModel : BaseViewModel {
		
		public AlunoViewModel(INavigation navigation) : base (navigation){
			var a = new List<Aluno>();
			a.Add(new Aluno { Nome = "João", Curso = "Matemática", Matricula = "2017010101" });
			a.Add(new Aluno { Nome = "Maria", Curso = "Português", Matricula = "2017010201" });
			a.Add(new Aluno { Nome = "Pedro", Curso = "Física", Matricula = "2017010301" });
			a.Add(new Aluno { Nome = "Carlos", Curso = "Arquitetura", Matricula = "2017010401" });
			Alunos = new ObservableCollection<Aluno>(a);
		}

		ObservableCollection<Aluno> _Alunos;
		public ObservableCollection<Aluno> Alunos { 
			get {
				return _Alunos;
			} 
			set {
				_Alunos = value;
				SetPropertyChanged(nameof(Alunos));
			}
		}
	}
}
