using System;

using Xamarin.Forms;

namespace Stroly.Android
{
	public class ChangePageRenderer : ContentPage
	{
		public ChangePageRenderer ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


