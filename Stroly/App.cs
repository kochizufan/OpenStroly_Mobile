using System;
using Xamarin.Forms;

namespace Stroly
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
			return new SplashPage ();//SplashPage();
		}

		//		protected override void OnSleep()
		//		{
		//			base.OnSleep();
		//		}

		//		protected override void OnResume()
		//		{
		//			base.OnResume();
		//		}

		//protected override void OnStart()
		//{
		//	base.OnStart();
		//	NavigationPage.SetHasNavigationBar(this,false);
		//}
	}
}

