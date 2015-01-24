using System;
using XF13TPSample;
using XF13TPSample.Android;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Webkit;
using AndWebView = Android.Webkit.WebView;
using System.IO;
using System.Text;

[assembly: ExportRenderer (typeof (WebViewEx), typeof (WebViewExRenderer))]

namespace XF13TPSample.Android
{
	public class WebViewExRenderer : WebViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				var webView = this.Control;
				webView.Settings.JavaScriptEnabled = true;
				webView.SetWebViewClient (new _WebViewExClient (this));
			}
		}
	}

	public class _WebViewExClient : WebViewClient
	{
		WeakReference _renderer;
		public WebViewExRenderer Renderer
		{
			set {
				_renderer = (value == null) ? null : new WeakReference (value);
			}

			get { 
				return (_renderer == null) ? null : (WebViewExRenderer)_renderer.Target;
			}
		}

		public _WebViewExClient (WebViewExRenderer renderer)
		{
			this.Renderer = renderer;
		}

		public override WebResourceResponse ShouldInterceptRequest (AndWebView view, string url)
		{
			var webViewEx = (WebViewEx)Renderer.Element;
			webViewEx.RaiseHandleStarted(new HandleStartedMessage(){ Uri = new Uri(url)});

			var mime = "text/html";
			var enc  = "UTF-8";
			var bs   = @"<html><body>
    <h1>Xamarin.Forms</h1>
    <p>Welcome to WebView.</p>
    </body></html>";

			var webResourceResponse = new WebResourceResponse (mime, enc, new MemoryStream (Encoding.UTF8.GetBytes (bs)));
			return webResourceResponse;
		}

		/*public override bool ShouldOverrideUrlLoading(WebView View, string Url) {
			if (Url.StartsWith ("tel:")) { 
				Intent intent = new Intent (Intent.ActionDial, Android.Net.Uri.Parse (Url));
				OwnerActivity.StartActivity (intent); 
				return true;
			} else if (Url.StartsWith ("browser:")) {
				Url = Url.Replace ("browser:", "");
				Intent intent = new Intent (Intent.ActionView, Android.Net.Uri.Parse (Url));
				OwnerActivity.StartActivity (intent);
				return true;
			}
			return false;
		}


		*/
	}
}

