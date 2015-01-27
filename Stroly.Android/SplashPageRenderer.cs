using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Stroly;
using Stroly.Android;

[assembly: ExportRenderer (typeof (SplashPage), typeof (SplashPageRenderer))]

namespace Stroly.Android
{
	public class SplashPageRenderer : PageRenderer
	{
		protected override void OnAttachedToWindow ()
		{
			base.OnAttachedToWindow ();
		}

		protected override void OnDetachedFromWindow ()
		{
			base.OnDetachedFromWindow ();
		}
	}
}


