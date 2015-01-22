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

namespace XF13TPSample.Android
{
	[Activity (Label = "", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		public MainActivity () : base()
		{
			RequestWindowFeature(WindowFeatures.ActionBar);
			ActionBar.Hide ();
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			Forms.Init(this, bundle);
			LoadApplication(new App ());
		}
	}
}

