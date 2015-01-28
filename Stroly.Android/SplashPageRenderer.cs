using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Stroly;
using Stroly.Android;
using Android.App;

using AndView = Android.Views.View;

[assembly: ExportRenderer (typeof (SplashPage), typeof (SplashPageRenderer))]

namespace Stroly.Android
{
	public class SplashPageRenderer : PageRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);
		}

		protected override void OnAttachedToWindow ()
		{
			base.OnAttachedToWindow ();
			var navR = (NavigationRenderer)this.Parent.Parent;
			var navP = (NavigationPage)navR.Element;
			navR.
			navP.ChildAdded += (object sender, ElementEventArgs e1) => {
				Console.WriteLine("Pushed {0}",e1);
			};
			navP.ChildRemoved += (object sender, ElementEventArgs e1) => {
				Console.WriteLine("Popped {0}",e1);
			};
		}
	}
}


