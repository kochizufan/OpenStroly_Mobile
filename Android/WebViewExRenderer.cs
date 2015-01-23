using System;
using XF13TPSample;
using XF13TPSample.Android;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Webkit;
using AndWebView = Android.Webkit.WebView;

[assembly: ExportRenderer (typeof (WebViewEx), typeof (WebViewExRenderer))]

namespace XF13TPSample.Android
{
	public class WebViewExRenderer : WebViewRenderer
	{
		public WebViewExRenderer () : base ()
		{
			var web = this.Control;
			web.SetWebViewClient (new _WebViewExClient (this));
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

		public override bool ShouldOverrideUrlLoading (AndWebView view, string url)
		{
			var webViewEx = (WebViewEx)Renderer.Element;
			webViewEx.RaiseHandleStarted(new HandleStartedMessage(){ Uri = new Uri(url)});
			return true;
		}

	}
}

