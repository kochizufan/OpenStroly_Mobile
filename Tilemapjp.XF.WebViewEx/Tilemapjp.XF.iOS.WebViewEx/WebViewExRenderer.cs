using System;
using Tilemapjp.XF;
using Tilemapjp.XF.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Foundation;
using XLabs.Forms.Controls;

[assembly: ExportRenderer (typeof (WebViewEx), typeof (WebViewExRenderer))]

namespace Tilemapjp.XF.iOS
{
	public class WebViewExRenderer : HybridWebViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<HybridWebView> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{
				this.ShouldStartLoad = HandleShouldStartLoad;

				var web = (UIWebView)this.NativeView;
				foreach (var subView in web.Subviews) {
					if (subView.IsKindOfClass(new ObjCRuntime.Class(typeof(UIScrollView)))) {
						((UIScrollView)subView).ScrollEnabled = false;
						((UIScrollView)subView).Bounces = false;
					}
				}
			}
		}

		bool HandleShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			var webViewEx = (WebViewEx)Element;
			var url = request.Url.ToString ();
			webViewEx.RaiseHandleStarted(new HandleStartedMessage(){ Uri = new Uri(url)});

			return webViewEx.ShouldLoad == null ? true : webViewEx.ShouldLoad(webViewEx, url);
		}

		public static void CacheInitialize ()
		{
			NSUrlCache.SharedCache = new WebViewExCache ();
		}
	}

	public class WebViewExCache : NSUrlCache
	{
		public WebViewExCache (uint memoryCapacity, uint diskCapacity, string diskPath) 
			: base(memoryCapacity, diskCapacity, diskPath)
		{			
		}
		public WebViewExCache () : base ()
		{
			
		}

		public override NSCachedUrlResponse CachedResponseForRequest (NSUrlRequest request)
		{
			if (WebViewEx._UseCachedContent == null)
				return null;

			var ncached = WebViewEx._UseCachedContent (request.Url.ToString ());
			if (!ncached.HasValue)
				return null;
			var cached = ncached.Value;

			var mime     = cached.Mime;
			var encoding = cached.Encoding;
			var content  = cached.Content;
			/*var mime = "text/html";
			var encoding = "UTF-8";
			var content  = @"<html><body>
    <h1>Xamarin.Forms</h1>
    <p>Welcome to WebView.</p>
    </body></html>";*/

			var data = NSData.FromArray (content);
			//var data = NSData.FromString(content);

			var res = new NSUrlResponse (request.Url, mime, (int)data.Length, encoding);

			return new NSCachedUrlResponse (res, data);
		}
	}
}