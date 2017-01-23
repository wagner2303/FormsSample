//
//  App.xaml.cs
//
//  Author:
//       Wagner Teixeira <wagner@sydy.com.br>
//
//  Copyright (c) 2017 
//
using Xamarin.Forms;
using FormsSample.Pages;

namespace FormsSample {
	public partial class App : Application {
		public App() {
			InitializeComponent();

			MainPage = new NavigationPage(new AlunosPage());
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}
