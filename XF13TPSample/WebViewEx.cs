using System;
using Xamarin.Forms;
using System.Reactive.Subjects;

namespace XF13TPSample
{
	public class HandleStartedMessage
	{
		public Uri Uri { get; set; }
	}

	public class WebViewEx : WebView
	{
		Subject<HandleStartedMessage> _handleStarted = new Subject<HandleStartedMessage>();

		public IObservable<HandleStartedMessage> HandleStarted { get { return _handleStarted; } }

		public void RaiseHandleStarted(HandleStartedMessage message)
		{
			_handleStarted.OnNext(message);
		}

	}
}

