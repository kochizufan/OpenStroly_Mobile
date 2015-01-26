using System;
using System.Collections.Generic;
using System.Reflection;

using Xamarin.Forms;
using Tilemapjp.XF;
using System.IO;

namespace Stroly
{
	public partial class SplashPage : ContentPage
	{
		public SplashPage ()
		{
			InitializeComponent ();

			WebViewEx web = this.webView;
			web.ShouldLoad = ShouldLoad;
			web.UseCachedContent = UseCachedContent;

			var urlSource = new UrlWebViewSource ();
			urlSource.Url = "http://tilemap.jp/default.html";
			web.Source = urlSource;

			this.Appearing += (object sender, EventArgs e) => {
				NavigationPage.SetHasNavigationBar(this,false);
			};

			this.Disappearing += (object sender, EventArgs e) => {
				NavigationPage.SetHasNavigationBar(this,true);
			};
		}

		protected bool ShouldLoad (WebViewEx WebViewEx, string url)
		{
			if (url.StartsWith ("strolyapp://")) {
				url = url.Replace ("strolyapp://", "");
				var nameSpace = this.GetType().Namespace;
				var pageType = Type.GetType(nameSpace + "." + url);
				var page = (Page)Activator.CreateInstance(pageType);
				PagePushAsync (page);
				return false;
			}

			return true;
		}

		protected async void PagePushAsync (Page page)
		{
			await this.Navigation.PushAsync (page);
		}

		protected WebViewExCachedContent? UseCachedContent (string url)
		{
			if (url.StartsWith("http")) {
				url = url.Replace("http://","").Replace("/",".");
				Type type = this.GetType();
				var nameSpace = type.Namespace;
				Stream manifestResourceStream = type.GetTypeInfo().Assembly.GetManifestResourceStream (nameSpace + ".content." + url);
				if (manifestResourceStream == null) { return null; }
				//var reader = new StreamReader(manifestResourceStream);
				//var content = reader.ReadToEnd();
				var content = manifestResourceStream.ToByteArray ();

				return new WebViewExCachedContent {
					Mime = "text/html",
					Encoding = "UTF-8",
					Content = content
				};
			}
			return null;
		}

		protected override void OnParentSet ()
		{
			NavigationPage.SetHasNavigationBar(this,false);
			base.OnParentSet ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
		}
	}
}

