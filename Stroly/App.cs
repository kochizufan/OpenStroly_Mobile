using System;
using System.Reflection;
using Xamarin.Forms;

namespace Stroly
{
	public class App : Application
	{
		public App()
		{
			var page = new NavigationPage (App.GetMainPage());
			NavigationPage.SetHasNavigationBar(page,false);
			Strings.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
			//var page = new CarouselPage ();
			//page.Children.Add (new StylesPage ());
			//page.Children.Add (new TriggersPage ());

			/*page.ChildAdded += (object sender, ElementEventArgs e) => {
				var navPages = page.Navigation.NavigationStack;

				if (navPages.Count > 1) {
					var oldPage = navPages[navPages.Count-2];
					var oldType = oldPage.GetType();
					var omi = oldType.GetRuntimeMethod("DidDisappear",new Type[]{});
					if (omi != null) {
						omi.Invoke(oldPage,null);
					}
				}

				var addPage = navPages[navPages.Count-1];
				var addType = addPage.GetType();
				var ami = addType.GetRuntimeMethod("WillAppear",new Type[]{});
				if (ami != null) {
					ami.Invoke(addPage,null);
				}
			};

			page.ChildRemoved += (object sender, ElementEventArgs e) => {
				var delPage = e.Element;
				var delType = delPage.GetType();
				var dmi = delType.GetRuntimeMethod("DidDisappear",new Type[]{});
				if (dmi != null) {
					dmi.Invoke(delPage,null);
				}

				var navPages = page.Navigation.NavigationStack;

				if (navPages.Count > 0) {
					var newPage = navPages[navPages.Count-1];
					var newType = newPage.GetType();
					var nmi = newType.GetRuntimeMethod("WillAppear",new Type[]{});
					if (nmi != null) {
						nmi.Invoke(newPage,null);
					}
				}
			};*/

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

