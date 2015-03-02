using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndView = Android.Views.View;
using XLabs.Ioc;
using XLabs.Serialization;

namespace OpenStroly.Android
{
	[Activity (Label = "", Theme = "@style/NoActionBarTheme",
		MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.Window.RequestFeature(WindowFeatures.ActionBar);
			base.SetTheme(global::Android.Resource.Style.ThemeHoloLight);
			base.OnCreate(bundle);
			base.ActionBar.Hide();

			var resolverContainer = new SimpleContainer();

			//var hybridWebView = new MyHybridWebView (new JsonSerializer());
			//var dataSourceFactory = new DataSourceFactory ();

			//var documents = app.AppDataDirectory;

			resolverContainer//.Register<IDevice> (t => AppleDevice.CurrentDevice)
			//.Register<IDisplay> (t => t.Resolve<IDevice> ().Display)
			//.Register<IXFormsApp> (app)
			//.Register<IDependencyContainer> (t => resolverContainer)
			//.Register<MyHybridWebView> (hybridWebView)
			//.Register<IDataSourceFactory> (dataSourceFactory)
				.Register<IJsonSerializer, XLabs.Serialization.ServiceStack.JsonSerializer> ();


			Resolver.SetResolver(resolverContainer.GetResolver());


			Forms.Init(this, bundle);
			var app = new App ();
			NavigationPage.SetHasNavigationBar (app, false);
			LoadApplication(app);
		}
	}
}

