using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using OpenStroly;
using OpenStroly.iOS;

[assembly: ExportRenderer (typeof (SplashPage), typeof (SplashPageRenderer))]

namespace OpenStroly.iOS
{
	public class SplashPageRenderer : PageRenderer
	{
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			((SplashPage)this.Element).WillAppear ();
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
			((SplashPage)this.Element).DidDisappear ();
		}
	}
}

