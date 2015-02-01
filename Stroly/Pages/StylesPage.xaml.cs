using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Stroly
{	
	public partial class StylesPage : ContentPage
	{	
		public StylesPage ()
		{
			InitializeComponent ();
		}

		async void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
			await this.Navigation.PushAsync (new TriggersPage ());
		}
	}
}

