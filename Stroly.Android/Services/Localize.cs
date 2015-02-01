using System;
using System.Globalization;
using Stroly;
using Stroly.Android;
using Xamarin.Forms;

[assembly:Dependency(typeof(Localize))]

namespace Stroly.Android
{
	public class Localize : ILocalize
	{
		public CultureInfo GetCurrentCultureInfo ()
		{
			var androidLocale = Java.Util.Locale.Default;
			var netLanguage = androidLocale.ToString().Replace ("_", "-"); // turns pt_BR into pt-BR
			return new CultureInfo(netLanguage);
		}
	}
}

