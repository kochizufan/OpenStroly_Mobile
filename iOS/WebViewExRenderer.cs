using System;
using XF13TPSample;
using XF13TPSample.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Foundation;

[assembly: ExportRenderer (typeof (WebViewEx), typeof (WebViewExRenderer))]

namespace XF13TPSample.iOS
{
	public class WebViewExRenderer : WebViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{
				this.ShouldStartLoad = HandleShouldStartLoad;
			}
		}

		bool HandleShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			var webViewEx = (WebViewEx)Element;
			webViewEx.RaiseHandleStarted(new HandleStartedMessage(){ Uri = new Uri(request.Url.ToString())});
			return true;
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
			var mime = "text/html";
			var enc  = "UTF-8";
			var bs   = @"<html><body>
    <h1>Xamarin.Forms</h1>
    <p>Welcome to WebView.</p>
    </body></html>";

			var data = NSData.FromString(bs);

			var a_res = new NSUrlResponse (request.Url, mime, (int)data.Length, enc);

			var cached = new NSCachedUrlResponse (a_res, data);
			return cached;
		}
	}
}

