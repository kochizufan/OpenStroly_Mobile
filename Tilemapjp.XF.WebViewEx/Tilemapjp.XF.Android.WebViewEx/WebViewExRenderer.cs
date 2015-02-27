using System;
using Tilemapjp.XF;
using Tilemapjp.XF.Android;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Webkit;
using AndWebView = Android.Webkit.WebView;
using System.IO;
using System.Text;
using XLabs.Forms.Controls;

[assembly: ExportRenderer (typeof (WebViewEx), typeof (WebViewExRenderer))]

namespace Tilemapjp.XF.Android
{
	public class WebViewExRenderer : HybridWebViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<HybridWebViewRenderer> e)
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
			if (WebViewEx._UseCachedContent == null)
				return null;

			var ncached = WebViewEx._UseCachedContent (url);
			if (!ncached.HasValue)
				return null;
			var cached = ncached.Value;

			var mime     = cached.Mime;
			var encoding = cached.Encoding;
			var content  = cached.Content;

			var webResourceResponse = new WebResourceResponse (mime, encoding, new MemoryStream (content));
				//new MemoryStream (Encoding.GetEncoding(encoding).GetBytes (content)));
			return webResourceResponse;
		}

		public override bool ShouldOverrideUrlLoading(AndWebView View, string Url) {
			/*if (Url.StartsWith ("tel:")) { 
				Intent intent = new Intent (Intent.ActionDial, Android.Net.Uri.Parse (Url));
				OwnerActivity.StartActivity (intent); 
				return true;
			} else if (Url.StartsWith ("browser:")) {
				Url = Url.Replace ("browser:", "");
				Intent intent = new Intent (Intent.ActionView, Android.Net.Uri.Parse (Url));
				OwnerActivity.StartActivity (intent);
				return true;
			}*/
			var webViewEx = (WebViewEx)Renderer.Element;
			webViewEx.RaiseHandleStarted(new HandleStartedMessage(){ Uri = new Uri(Url)});

			return webViewEx.ShouldLoad == null ? false : !webViewEx.ShouldLoad(webViewEx, Url);
		}
	}
}

