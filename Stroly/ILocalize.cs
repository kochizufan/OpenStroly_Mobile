using System;
using System.Globalization;
using System.Resources;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stroly
{
	public interface ILocalize
	{
		CultureInfo GetCurrentCultureInfo ();
	}

	[ContentProperty ("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		readonly CultureInfo ci;
		const string ResourceId = "UsingResxLocalization.Resx.AppResources";

		public TranslateExtension() {
			ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo ();
		}

		public string Text { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Text == null)
				return "";

			ResourceManager resmgr = new ResourceManager(ResourceId
				, typeof(TranslateExtension).GetTypeInfo().Assembly);

			var translation = resmgr.GetString (Text, ci);

			if (translation == null) {
				#if DEBUG
				throw new ArgumentException (
					String.Format ("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
					"Text");
				#else
				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
				#endif
			}
			return translation;
		}
	}
}

