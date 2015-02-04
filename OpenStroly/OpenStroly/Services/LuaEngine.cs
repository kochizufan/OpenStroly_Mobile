using System;
using NLua;
using OpenStroly;
#if __ANDROID__
using OpenStroly.Android;
#elif __IOS__
using OpenStroly.iOS;
#endif
using Xamarin.Forms;
using System.Reflection;
using System.Text;
using System.IO;

[assembly:Dependency(typeof(LuaEngine))]

#if __ANDROID__
namespace OpenStroly.Android
#elif __IOS__
namespace OpenStroly.iOS
#endif
{
	public class LuaEngine : ILuaEngine
	{
		Lua state;

		public LuaEngine ()
		{
			state = new Lua ();
			state.LoadCLRPackage ();

			var slt2String = LuaLibrary.Slt2 ();
			var slt2 = state.DoString (slt2String) [0];
			state ["slt2"] = slt2;

			var translate = new Translate ();
			state ["trans"] = translate;
			state.DoString (@"
function translate (val)
    return trans:TextValue(val)
end

function template (val)
	local tmpl = slt2.loadstring(val)
    return slt2.render(tmpl, {})
end
");
		}

		public string AttachTemplate(string template)
		{
			/*state ["_template"] = template;
			var result = state.DoString (@"
return slt2.loadstring(_template);
")[0];
			return (string)result;*/

			var func = state ["template"] as LuaFunction;
			var result = func.Call (template);
			return (string)result[0];
		}
/*			var result = state.DoString (@"
local user = {
    name = '<world>'
}

function escapeHTML(str)
    local tt = {
        ['&'] = '&amp;',
        ['<'] = '&lt;',
        ['>'] = '&gt;',
        ['""'] = '&quot;',
        [""'""] = '&#39;',
    }
    local r = string.gsub(str, '[&<>""\']', tt)
    return r
end

local tmpl = slt2.loadstring([[<span>
#{ if user ~= nil then }#
Hello, #{= escapeHTML(user.name) }#!
#{ else }#
<a href=""/login"">login</a>
#{ end }#
</span>
]])

return slt2.render(tmpl, {user = user})
")[0];
			Console.WriteLine (result);

			result = state.DoString (@"
return translate(""ChangeUpperContent"");
")[0];
			Console.WriteLine (result);
			Console.WriteLine ("{0}",state.DoString("return math.sin (10)*10 + 7")[0]);
		}*/
	}
}
