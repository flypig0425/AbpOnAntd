﻿using AntDesign;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zero.Abp.AntdesignUI.Layout
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

        public static readonly Dictionary<string, string> ThemeColors = new()
        {
            { "#1890ff", "default" },
            { "#F5222D", "dust" },
            { "#FA541C", "volcano" },
            { "#FAAD14", "sunset" },
            { "#13C2C2", "cyan" },
            { "#52C41A", "green" },
            { "#2F54EB", "geekblue" },
            { "#722ED1", "purple" }
        };

        public static IEnumerable<string> StyleOrClassNames(params OneOf<string, (string s, bool b), (Func<string> func, bool b)>[] values)
        {
            var tempClassNames = values?.Select(s => s.Match(
                m0 => m0,
                m1 => m1.b ? m1.s : null,
                m2 => m2.b ? m2.func?.Invoke() : null
                ));
            tempClassNames = tempClassNames?.Where(w => !w.IsNullOrWhiteSpace())?.Distinct()?.ToArray();
            return tempClassNames ?? Array.Empty<string>();
        }

    }
}
