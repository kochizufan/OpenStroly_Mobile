using System;
using System.Collections.Generic;
using System.Reflection;

using Xamarin.Forms;
using Tilemapjp.XF;
using System.IO;
using System.Text;

namespace Stroly
{
	public partial class SplashPage : ContentPage
	{
		public SplashPage ()
		{
			InitializeComponent ();

			this.BackgroundColor = Color.FromHex ("#ff0000");

			WebViewEx web = this.webView;
			web.ShouldLoad = ShouldLoad;
			web.UseCachedContent = UseCachedContent;
			web.WidthRequest = 200.0;
			web.HeightRequest = 400.0;

			var urlSource = new UrlWebViewSource ();
			urlSource.Url = "http://tilemap.jp/KochizuBurari/menu.html";
			web.Source = urlSource;

			this.Appearing += (object sender, EventArgs e) => {
				NavigationPage.SetHasNavigationBar(this,false);
			};

			var disp = DependencyService.Get<IDeviceProperty> ();
			System.Diagnostics.Debug.WriteLine ("########## Density: {0}", disp.ScreenDensity ());
			System.Diagnostics.Debug.WriteLine ("########## Width: {0}", disp.DisplayDpSize().Width);
			System.Diagnostics.Debug.WriteLine ("########## Height: {0}", disp.DisplayDpSize().Height);
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

				var contentString = Encoding.UTF8.GetString(content,0,content.Length);
				if (contentString.Contains ("#{")) {
					var trans = DependencyService.Get<ILuaEngine> ();
					contentString = trans.AttachTemplate (contentString);
					content = Encoding.UTF8.GetBytes (contentString);
				}
					
				return new WebViewExCachedContent {
					Mime = "text/html",
					Encoding = "UTF-8",
					Content = content
				};
			} else if (url.StartsWith("stroly.internalresource")) {
				var inter = DependencyService.Get<IInternalResource> ();
			}
			return null;
		}

		/*protected override void OnParentSet ()
		{
			NavigationPage.SetHasNavigationBar(this,false);
			base.OnParentSet ();
		}*/

		public void WillAppear ()
		{
			NavigationPage.SetHasNavigationBar(this,false);
		}

		public void DidDisappear ()
		{
			NavigationPage.SetHasNavigationBar(this,true);
		}
	}
}

