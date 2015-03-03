using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OpenStroly
{
	public struct SplashInfo {
		public string DeviceName;
		public float PxWidth;
		public float PxHeight;
		public float DpWidth;
		public float DpHeight;
		public bool IsPhone;
		public bool IsPortrait;
		public string SplashImage;
		public float Scale;
	}

	public class DeviceData
	{
		static SplashInfo? splashInfo = null;

		public static List<SplashInfo> SplashInfos = new List<SplashInfo> {
			new SplashInfo() {
				DeviceName = "iPhone3",
				PxWidth = 320f,
				PxHeight = 480f,
				IsPhone = true,
				IsPortrait = true,
				SplashImage = "Default.png"
			},
			new SplashInfo() {
				DeviceName = "iPhone4",
				PxWidth = 640f,
				PxHeight = 960f,
				IsPhone = true,
				IsPortrait = true,
				SplashImage = "Default@2x.png"
			},
			new SplashInfo() {
				DeviceName = "iPhone5",
				PxWidth = 640f,
				PxHeight = 1136f,
				IsPhone = true,
				IsPortrait = true,
				SplashImage = "Default-568h@2x.png"
			},
			new SplashInfo() {
				DeviceName = "iPhone6",
				PxWidth = 750f,
				PxHeight = 1334f,
				IsPhone = true,
				IsPortrait = true,
				SplashImage = "Default-667h@2x.png"
			},
			new SplashInfo() {
				DeviceName = "iPhone6+",
				PxWidth = 1242f,
				PxHeight = 2208f,
				IsPhone = true,
				IsPortrait = true,
				SplashImage = "Default-736h@3x.png"
			},
			new SplashInfo() {
				DeviceName = "iPad-Portrait",
				PxWidth = 768f,
				PxHeight = 1024f,
				IsPhone = false,
				IsPortrait = true,
				SplashImage = "Default-Portrait.png"
			},
			new SplashInfo() {
				DeviceName = "iPad-Landscape",
				PxWidth = 1024f,
				PxHeight = 768f,
				IsPhone = false,
				IsPortrait = false,
				SplashImage = "Default-Landscape.png"
			},
			new SplashInfo() {
				DeviceName = "iPad-Retina-Portrait",
				PxWidth = 1536f,
				PxHeight = 2048f,
				IsPhone = false,
				IsPortrait = true,
				SplashImage = "Default-Portrait@2x.png"
			},
			new SplashInfo() {
				DeviceName = "iPad-Retina-Landscape",
				PxWidth = 2048f,
				PxHeight = 1536f,
				IsPhone = false,
				IsPortrait = false,
				SplashImage = "Default-Landscape@2x.png"
			}
		};

		public DeviceData ()
		{
		}

		public static SplashInfo GetCompatibleSplashInfo ()
		{
			if (splashInfo.HasValue) {
				return splashInfo.Value;
			}

			var device = DependencyService.Get<IDeviceProperty> ();
			var original = device.DisplayPxSize ();
			SplashInfo? retVal = null;
			float wRatio = 0f, hRatio = 0f;
			foreach (var splash in SplashInfos) {
				if (!retVal.HasValue) {
					retVal = splash;
					wRatio = splash.PxWidth  / original.Width;
					hRatio = splash.PxHeight / original.Height;
					continue;
				}
				var wR = splash.PxWidth  / original.Width;
				var hR = splash.PxHeight / original.Height;
				if (wR > 1.0f || hR > 1.0f)
					continue;
				if (wR >= wRatio && hR >= hRatio) {
					wRatio = wR;
					hRatio = hR;
					retVal = splash;
				}
			}
			var ret = retVal.Value;
			ret.DpWidth  = ret.PxWidth  / device.ScreenDensity();
			ret.DpHeight = ret.PxHeight / device.ScreenDensity();
			ret.Scale = (float)Math.Floor((wRatio > hRatio ? 1.0f / wRatio : 1.0f / hRatio) * 10f) / 10f;
			splashInfo = ret;
			return splashInfo.Value;
		}
	}
}

