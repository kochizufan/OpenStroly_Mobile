using System;

using Xamarin.Forms;

namespace Stroly
{
	public partial class ChangePage : ContentPage
	{
		public ChangePage ()
		{
			var datePicker = new DatePicker { };
			var timePicker = new TimePicker { };
			var button1 = new Button {
				Text = "ChangeUpper"
			};
			var button2 = new Button {
				Text = "NextPage"
			};

			Content = new StackLayout {
				Children = {
					datePicker,
					button1,
					button2
				},
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			button1.Clicked += (sender, e) =>
			{
				var views = ((StackLayout)this.Content).Children;
				var view = views[0];
				views.RemoveAt(0);
				if (view.Equals(datePicker)) {
					views.Insert(0,timePicker);
				} else {
					views.Insert(0,datePicker);
				}
			};
			button2.Clicked += async (sender, e) => 
			{
				await this.Navigation.PushAsync(new StylesPage ());
			};

			this.Appearing += (object sender, EventArgs e) => {
				NavigationPage.SetHasNavigationBar(this,true);
			};
		}
	}
}


