using System;
using System.Collections.Generic;

namespace OpenStroly
{
	public struct SplashInfo {
		public string DeviceName;
		public int Width;
		public int Height;
		public bool IsPhone;
		public bool IsPortrait;
		public string SplashImage;
	}

	public class DeviceData
	{
		public List<SplashInfo> SplashInfos = new List<SplashInfo> {
			new SplashInfo() {
				DeviceName = "iPhone3",

			},
			new SplashInfo() {
				DeviceName = "iPhone4",
			}
		};

		public DeviceData ()
		{
		}
		
	}
}

