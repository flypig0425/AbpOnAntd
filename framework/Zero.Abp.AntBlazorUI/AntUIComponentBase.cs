using AntDesign;
using Microsoft.AspNetCore.Components;
using OneOf;
using System;
using System.Linq;
using Zero.Abp.AntBlazorUI.Core;

namespace Zero.Abp.AntBlazorUI
{
    public abstract class AntUIComponentBase : AntComponentBase
    {
        [Parameter] public string PrefixCls { get; set; } = "ant";

        [Parameter] public string Class { get; set; }
        [Parameter] public string Style { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Example: ClassNames(className ,(className,true|flase) ,(()=>className,true|flase))
        /// </summary>
        protected static string ClassNames(params OneOf<string, (string s, bool b), (Func<string> func, bool b)
                    , (string s, Func<bool> b), (Func<string> func, Func<bool> b)>[] classNames)
            => string.Join(" ", AntBlazorUtils.StyleOrClassNames(classNames));

        /// <summary>
        /// Example: StyleValues(style ,(style,true|flase) ,(()=>style,true|flase))
        /// </summary>
        protected static string StyleValues(params OneOf<string, (string s, bool b), (Func<string> func, bool b)
                    , (string s, Func<bool> b), (Func<string> func, Func<bool> b)>[] styleValues)
            => string.Join(";", AntBlazorUtils.StyleOrClassNames(styleValues)?.Select(s => s.TrimEnd(';')));


        protected static bool AllNoNull(params object[] values)
        {
            return values.All(a => a != null);
        }

        protected static bool AnyNoNull(params object[] values)
        {
            return values.Any(a => a != null);
        }
    }
}
