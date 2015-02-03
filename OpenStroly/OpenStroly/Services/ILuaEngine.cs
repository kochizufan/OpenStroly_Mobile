using System;
using System.Reflection;
using System.IO;

namespace OpenStroly
{
	public interface ILuaEngine
	{
		string AttachTemplate(string template);
	}

	public class LuaLibrary {
		static string slt2 = null;
		public static string Slt2 () {
			if (slt2 == null) {
				var slt2Stream = typeof(LuaLibrary).GetTypeInfo().Assembly.GetManifestResourceStream ("OpenStroly.slt2.lua");
				slt2 = (new StreamReader(slt2Stream)).ReadToEnd();
			}
			return slt2;
		}
	}
}

