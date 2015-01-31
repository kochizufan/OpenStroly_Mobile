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

	public class Translate
	{
		readonly CultureInfo ci;
		const string ResourceId = "Stroly.i18n.Strings";

		public Translate() {
			ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo ();
		}

		public string TextValue(string text)
		{
			ResourceManager resmgr = new ResourceManager(ResourceId
				, typeof(Translate).GetTypeInfo().Assembly);

			var translation = resmgr.GetString (text, ci);

			if (translation == null) {
				#if DEBUG
				throw new ArgumentException (
					String.Format ("Key '{0}' was not found in resources '{1}' for culture '{2}'.", text, ResourceId, ci.Name),
					"Text");
				#else
				translation = text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
				#endif
			}
			return translation;
		}
	}

	[ContentProperty ("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		//readonly CultureInfo ci;
		//const string ResourceId = "Stroly.i18n.Strings";
		Translate translate;

		public TranslateExtension() {
			//ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo ();
			translate = new Translate ();
		}

		public string Text { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			return translate.TextValue (Text);
			/*if (Text == null)
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
			return translation;*/
		}
	}
}

