using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using OpenStroly;
using OpenStroly.Android;
using Android.App;

using AndView = Android.Views.View;
using System.Reflection;
using Android.Graphics;

[assembly: ExportRenderer (typeof (NavigationPage), typeof (NavigationPageRenderer))]

namespace OpenStroly.Android
{
	public class NavigationPageRenderer : NavigationRenderer
	{
		protected override System.Threading.Tasks.Task<bool> OnPushAsync (Page view, bool animated)
		{
			var nav      = ((NavigationPage)this.Element);
			var navPages = nav.Navigation.NavigationStack;

			if (navPages.Count > 0) {
				var oldPage = navPages[navPages.Count-1];
				var oldType = oldPage.GetType();
				var omi = oldType.GetRuntimeMethod("DidDisappear",new Type[]{});
				if (omi != null) {
					omi.Invoke(oldPage,null);
				}
			}

			var addPage = view;
			var addType = addPage.GetType();
			var ami = addType.GetRuntimeMethod("WillAppear",new Type[]{});
			if (ami != null) {
				ami.Invoke(addPage,null);
			}

			return base.OnPushAsync (view, animated);
		}

		protected override System.Threading.Tasks.Task<bool> OnPopViewAsync (Page page, bool animated)
		{
			var nav      = ((NavigationPage)this.Element);
			var navPages = nav.Navigation.NavigationStack;

			var delPage = page;
			var delType = delPage.GetType();
			var dmi = delType.GetRuntimeMethod("DidDisappear",new Type[]{});
			if (dmi != null) {
				dmi.Invoke(delPage,null);
			}

			if (navPages.Count > 1) {
				var newPage = navPages[navPages.Count-2];
				var newType = newPage.GetType();
				var nmi = newType.GetRuntimeMethod("WillAppear",new Type[]{});
				if (nmi != null) {
					nmi.Invoke(newPage,null);
				}
			}

			return base.OnPopViewAsync (page, animated);
		}
	}
}

