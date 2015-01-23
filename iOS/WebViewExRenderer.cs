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
				ShouldStartLoad = HandleShouldStartLoad;
			}
		}
		bool HandleShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			var webViewEx = (WebViewEx)Element;
			webViewEx.RaiseHandleStarted(new HandleStartedMessage(){ Uri = new Uri(request.Url.ToString())});
			return true;
		}
	}
}

