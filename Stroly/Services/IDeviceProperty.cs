using System;
using System.Drawing;

namespace Stroly
{
	public interface IDeviceProperty
	{
		float ScreenDensity();

		SizeF DisplayDpSize();

		SizeF DisplayPxSize();
	}
}

