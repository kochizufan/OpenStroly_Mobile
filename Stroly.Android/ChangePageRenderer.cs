using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Stroly;
using Stroly.Android;
using Android.App;

[assembly: ExportRenderer (typeof (ChangePage), typeof (ChangePageRenderer))]

namespace Stroly.Android
{
	public class ChangePageRenderer : PageRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);
			var frag = ((Activity)this.Context).FragmentManager;
			Console.WriteLine ("######2 {0}",frag);
		}

	}
}
