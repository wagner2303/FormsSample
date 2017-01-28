//
//  AlunosPage.xaml.cs
//
//  Author:
//       Wagner Teixeira <wagner2303@gmail.com>
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

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
			if (e == null) { 
				return; // has been set to null, do not 'process' tapped event 
			}
			((ListView)sender).SelectedItem = null; // de-select the row
		}
	}
}
