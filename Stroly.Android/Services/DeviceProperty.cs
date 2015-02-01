using System;
using System.Drawing;
using Stroly;
using Stroly.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using Android.Runtime;
using Android.Graphics;

[assembly:Dependency(typeof(DeviceProperty))]

namespace Stroly.Android
{
	public class DeviceProperty : IDeviceProperty
	{
		public DeviceProperty ()
		{
		}

		public float ScreenDensity()
		{
			return Forms.Context.Resources.DisplayMetrics.Density;
		}

		public SizeF DisplayDpSize() {
			return new SizeF () {
				Width  = Forms.Context.Resources.DisplayMetrics.WidthPixels  / this.ScreenDensity (),
				Height = Forms.Context.Resources.DisplayMetrics.HeightPixels / this.ScreenDensity ()
			};
			/*var windowManager = Forms.Context.GetSystemService("window").JavaCast<IWindowManager>();
			var disp = windowManager.DefaultDisplay;
			Rect rect = new Rect();
			disp.GetRectSize(rect);
			return new SizeF (){ 
				Width  = rect.Width(),
				Height = rect.Height()
			};*/
		}

		public SizeF DisplayPxSize() {
			return new SizeF () {
				Width  = Forms.Context.Resources.DisplayMetrics.WidthPixels,
				Height = Forms.Context.Resources.DisplayMetrics.HeightPixels
			};
		}
	}
}

