using System;
using System.Drawing;

namespace OpenStroly
{
	public interface IDeviceProperty
	{
		float ScreenDensity();

		SizeF DisplayDpSize();

		SizeF DisplayPxSize();
	}
}

