using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace XF13TPSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			NSUrlCache.SharedCache = new WebViewExCache ();

			Forms.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}
	}
}

