//
//  AlunoViewModel.cs
//
//  Author:
//       Wagner Teixeira <wagner2303@gmail.com>
//
//  Copyright (c) 2017 
//
using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using FormsSample.Models;
using System.Collections.Generic;
using FormsSample.Repositories;
using FormsSample.Services;
using System.Threading.Tasks;
using FormsSample.Pages;

namespace FormsSample.ViewModels {
	public class AlunoViewModel : BaseViewModel {
		
		public AlunoViewModel(INavigation navigation) : base (navigation){

			var sqlite = DependencyService.Get<ISQLite>();
			using (var scope = new TransactionScope(sqlite)) { 
				var service = new DataService(sqlite);
				if (service.GetAlunos().Count == 0) {
					service.SaveAluno(new Aluno { Nome = "João", Curso = "Matemática", Matricula = "2017010101" });
					service.SaveAluno(new Aluno { Nome = "Maria", Curso = "Português", Matricula = "2017010201" });
					service.SaveAluno(new Aluno { Nome = "Pedro", Curso = "Física", Matricula = "2017010301" });
					service.SaveAluno(new Aluno { Nome = "Carlos", Curso = "Arquitetura", Matricula = "2017010401" });
				}
				scope.Complete();
			}

			using (var scope = new TransactionScope(sqlite)){
				Alunos = new ObservableCollection<Aluno>(
					new DataService(sqlite).GetAlunos()
				);
				scope.Complete();
			}


			//var a = new List<Aluno>();
			//a.Add(new Aluno { Nome = "João", Curso = "Matemática", Matricula = "2017010101" });
			//a.Add(new Aluno { Nome = "Maria", Curso = "Português", Matricula = "2017010201" });
			//a.Add(new Aluno { Nome = "Pedro", Curso = "Física", Matricula = "2017010301" });
			//a.Add(new Aluno { Nome = "Carlos", Curso = "Arquitetura", Matricula = "2017010401" });
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

		string _Search = string.Empty;
		public string Search {
			get { return _Search; }
			set {
				_Search = value;
				var sqlite = DependencyService.Get<ISQLite>();
				Alunos = new ObservableCollection<Aluno>(new DataService(sqlite).FindAlunoByNome(_Search));
			}
		}

		Command _AddAlunoCommand;
		public Command AddAlunoCommand {
			get { return _AddAlunoCommand ?? (_AddAlunoCommand = new Command(async () => await ExecuteAddAlunoCommand())); }
		}

		async Task ExecuteAddAlunoCommand() {
			if (!IsBusy) {
				IsBusy = true;
				await Navigation.PushAsync(new AddAlunoPage());
				IsBusy = false;
			}
		}
	}
}
