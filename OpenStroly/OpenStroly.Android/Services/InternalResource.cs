using System;
using System.IO;
using OpenStroly.Android;
using Xamarin.Forms;

[assembly:Dependency(typeof(InternalResource))]

namespace OpenStroly.Android
{
	public class InternalResource : IInternalResource
	{
		public InternalResource ()
		{
		}

		public byte[] GetResourceData(string fileName)
		{
			string normName = "";

			if (fileName == "Default.png") {
				var splashData = DeviceData.GetCompatibleSplashInfo ();
				normName = splashData.SplashImage;
				if (normName == "Default.png")
					normName = "Default_.png";
			} else {
			}
			normName = normName.Replace ('@', '_').Replace ('-', '_');
			using (var st = Forms.Context.Assets.Open (normName))
			{
				byte[] buf = new byte[32768];
				using (var ms = new MemoryStream()) {
					while (true) {
						int read = st.Read(buf, 0, buf.Length);

						if (read > 0) {
							ms.Write(buf, 0, read);
						} else {
							break;
						}
					}
					return ms.ToArray();
				}
			}
		}
	}
}

