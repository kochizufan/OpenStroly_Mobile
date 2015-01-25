using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Tilemapjp.XF;

namespace XF13TPSample
{
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			InitializeComponent ();

			WebViewEx web = this.webView;
			web.ShouldLoad = (WebViewEx WebViewEx, string url) => {
				return false;
			};
			web.UseCachedContent = (string url) => {
				return new WebViewExCachedContent {
					Mime = "text/html",
					Encoding = "UTF-8",
					Content = @"<html><body>
    <h1>Xamarin.Forms</h1>
    <p>Welcome to WebView.</p>
    </body></html>"
				};
			};

			var urlSource = new UrlWebViewSource ();
			urlSource.Url = "http://google.com/";
			web.Source = urlSource;
		}
	}
}

