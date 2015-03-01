using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Tilemapjp.XF.iOS;
using XLabs.Ioc;
using XLabs.Serialization;

namespace OpenStroly.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			NSUrlCache.SharedCache = new WebViewExCache ();
			//WebViewExRenderer.CacheInitialize ();

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



			Forms.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}
	}
}

