//
//  AlunosPage.xaml.cs
//
//  Author:
//       Wagner Teixeira <wagner@sydy.com.br>
//
//  Copyright (c) 2017 
//
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormsSample.ViewModels;

namespace FormsSample.Pages {
	public partial class AlunosPage : ContentPage {
		public AlunosPage() {
			BindingContext = new AlunoViewModel(Navigation);
			InitializeComponent();
		}
	}
}
