using AntDesign;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zero.Abp.AspNetCore.Components.Web.AntdTheme
{
    public sealed class Layout : EnumValue<Layout>
    {
        public static readonly Layout Side = new(nameof(Side).ToLowerInvariant(), 1);
        public static readonly Layout Top = new(nameof(Top).ToLowerInvariant(), 2);
        public static readonly Layout Mix = new(nameof(Mix).ToLowerInvariant(), 3);
        private Layout(string name, int value) : base(name, value) { }
    }

    public static class Utils
    {
        public static IEnumerable<string> StyleOrClassNames(params OneOf<
            string
            , (string s, bool b)
            , (Func<string> func, bool b)
            , (string s, Func<bool> b)
            , (Func<string> func, Func<bool> b)
            >[] values)
        {
            var tempClassNames = values?.Select(s => s.Match(
                m0 => m0,
                m1 => m1.b ? m1.s : null,
                m2 => m2.b ? m2.func?.Invoke() : null,
                m3 => m3.b?.Invoke() ?? false ? m3.s : null,
                m4 => m4.b?.Invoke() ?? false ? m4.func?.Invoke() : null
                ));
            tempClassNames = tempClassNames?.Where(w => !w.IsNullOrWhiteSpace())?.Distinct()?.ToArray();
            return tempClassNames ?? Array.Empty<string>();
        }


        public static MenuTheme ToMenuTheme(this string theme)
            => theme switch { "light" => MenuTheme.Light, "dark" => MenuTheme.Dark, _ => MenuTheme.Light };

        public static SiderTheme ToSiderTheme(this string theme)
            => theme switch { "light" => SiderTheme.Light, "dark" => SiderTheme.Dark, _ => SiderTheme.Light };
    }
}
