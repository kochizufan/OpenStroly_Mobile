using System;
using Xamarin.Forms;

namespace XF13TPSample
{
	public class App : Application
	{
		public App()
		{
			var page = new NavigationPage (App.GetMainPage());
			NavigationPage.SetHasNavigationBar(page,false);
			//var page = new CarouselPage ();
			//page.Children.Add (new StylesPage ());
			//page.Children.Add (new TriggersPage ());
			MainPage = page;
		}

		public static Page GetMainPage()
		{
			var datePicker = new DatePicker { };
			var timePicker = new TimePicker { };
			var button1 = new Button {
				Text = "ChangeUpper"
			};
			var button2 = new Button {
				Text = "NextPage"
			};

			var page = new ContentPage {

				Content = new StackLayout {
					Children = {
						datePicker,
						button1,
						button2
					},
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center
				}
			};
					
			page.Appearing += (object sender, EventArgs e) => {
				NavigationPage.SetHasNavigationBar(page,false);
			};

			page.Disappearing += (object sender, EventArgs e) => {
				NavigationPage.SetHasNavigationBar(page,true);
			};

			button1.Clicked += (sender, e) =>
			{
				var views = ((StackLayout)page.Content).Children;
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
				await page.Navigation.PushAsync(new StylesPage ());
			};

			return page;
		}

		//		protected override void OnSleep()
		//		{
		//			base.OnSleep();
		//		}

		//		protected override void OnResume()
		//		{
		//			base.OnResume();
		//		}

		//		protected override void OnStart()
		//		{
		//			base.OnStart();
		//		}
	}
}

