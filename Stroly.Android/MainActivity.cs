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

namespace Stroly.Android
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

			Forms.Init(this, bundle);
			var app = new App ();
			NavigationPage.SetHasNavigationBar (app, false);
			LoadApplication(app);
		}
	}
}

