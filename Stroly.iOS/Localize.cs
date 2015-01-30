using System;
using System.Globalization;
using Stroly;
using Stroly.iOS;
using Xamarin.Forms;
using Foundation;

[assembly:Dependency(typeof(Localize))]

namespace Stroly.iOS
{
	public class Localize : ILocalize
	{
		public CultureInfo GetCurrentCultureInfo ()
		{
			var netLanguage = "ja";
			if (NSLocale.PreferredLanguages.Length > 0) {
				var pref = NSLocale.PreferredLanguages [0];
				netLanguage = pref.Replace ("_", "-"); // turns pt_BR into pt-BR
			}
			return new CultureInfo(netLanguage);
		}
	}
}

