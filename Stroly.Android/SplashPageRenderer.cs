using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Stroly;
using Stroly.Android;
using Android.App;

[assembly: ExportRenderer (typeof (SplashPage), typeof (SplashPageRenderer))]

namespace Stroly.Android
{
	public class SplashPageRenderer : PageRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);
			((Activity)this.Context).FragmentManager.Dump ("", null, new Java.IO.PrintWriter(new System.IO.Stream(), null), null);
		}

	}
}


