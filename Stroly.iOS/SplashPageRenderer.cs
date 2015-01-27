using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Stroly;
using Stroly.iOS;

[assembly: ExportRenderer (typeof (SplashPage), typeof (SplashPageRenderer))]

namespace Stroly.iOS
{
	public class SplashPageRenderer : PageRenderer
	{
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
	}
}

