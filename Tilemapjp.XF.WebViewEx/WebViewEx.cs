using System;
using Xamarin.Forms;
using System.Reactive.Subjects;
using System.IO;

namespace Tilemapjp.XF
{
	public struct WebViewExCachedContent {
		public string Mime;
		public string Encoding;
		public string Content;
	}

	public delegate bool WebViewExShouldLoad (WebViewEx webView, string url);

	public delegate WebViewExCachedContent? WebViewExUseCachedContent (string url);

	public class HandleStartedMessage
	{
		public Uri Uri { get; set; }
	}

	public class WebViewEx : WebView
	{
		public static WebViewExUseCachedContent _UseCachedContent { get; set; }

		Subject<HandleStartedMessage> _handleStarted = new Subject<HandleStartedMessage>();

		public IObservable<HandleStartedMessage> HandleStarted { get { return _handleStarted; } }

		public WebViewExShouldLoad ShouldLoad { get; set; }

		public WebViewExUseCachedContent UseCachedContent { 
			get { 
				return WebViewEx._UseCachedContent;
			}
			set { 
				WebViewEx._UseCachedContent = value;
			} 
		}

		public void RaiseHandleStarted(HandleStartedMessage message)
		{
			_handleStarted.OnNext(message);
		}

	}
}

