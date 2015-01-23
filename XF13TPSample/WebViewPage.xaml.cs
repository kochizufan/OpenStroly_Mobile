using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XF13TPSample
{
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			InitializeComponent ();

			WebViewEx web = this.webView;

			var urlSource = new UrlWebViewSource ();
			urlSource.Url = "http://google.com/";
			web.Source = urlSource;
		}
	}
}

