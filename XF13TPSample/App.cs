using System;
using Xamarin.Forms;

namespace XF13TPSample
{
	public class App : Application
	{
		public App()
		{
			var page = new CarouselPage ();
			page.Children.Add (new StylesPage ());
			page.Children.Add (new TriggersPage ());
			MainPage = page;
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

