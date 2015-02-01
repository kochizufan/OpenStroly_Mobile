using System;
using System.Drawing;
using Stroly;
using Stroly.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly:Dependency(typeof(DeviceProperty))]

namespace Stroly.iOS
{
	public class DeviceProperty : IDeviceProperty
	{
		public DeviceProperty ()
		{
		}

		public float ScreenDensity()
		{
			return (float)UIScreen.MainScreen.Scale;
		}

		public SizeF DisplayDpSize() {
			var rect = UIScreen.MainScreen.Bounds;

			return new SizeF (){ 
				Width  = (float)rect.Width,
				Height = (float)rect.Height
			};
		}

		public SizeF DisplayPxSize() {
			var rect = UIScreen.MainScreen.Bounds;

			return new SizeF (){ 
				Width  = (float)rect.Width  * this.ScreenDensity(),
				Height = (float)rect.Height * this.ScreenDensity()
			};
		}
	}
}

