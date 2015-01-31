using System;
using NLua;
using Stroly;
#if __ANDROID__
using Stroly.Android;
#else
using Stroly.iOS;
#endif
using Xamarin.Forms;
using System.Reflection;
using System.Text;
using System.IO;

[assembly:Dependency(typeof(LuaEngine))]

#if __ANDROID__
namespace Stroly.Android
#else
namespace Stroly.iOS
#endif
{
	public class LuaEngine : ILuaEngine
	{
		Lua state;

		public LuaEngine ()
		{
			state = new Lua();
			state.LoadCLRPackage ();

			var slt2String = LuaLibrary.Slt2 ();
			var slt2 = state.DoString (slt2String)[0];
			state ["slt2"] = slt2;

			var result = state.DoString (@"
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
			Console.WriteLine ("{0}",state.DoString("return math.sin (10)*10 + 7")[0]);
		}
	}
}
