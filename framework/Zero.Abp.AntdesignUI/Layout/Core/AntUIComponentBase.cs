using AntDesign;
using Microsoft.AspNetCore.Components;
using OneOf;
using System;
using System.Linq;

namespace Zero.Abp.AntdesignUI.Layout
{
    public abstract class AntUIComponentBase : AntComponentBase
    {
        [Parameter] public string PrefixCls { get; set; } = "ant-pro";
        [Parameter] public string Class { get; set; }
        [Parameter] public string Style { get; set; }

        /// <summary>
        /// Example: ClassNames(className ,(className,true|flase) ,(()=>className,true|flase))
        /// </summary>
        protected static string ClassNames(params OneOf<string, (string s, bool b), (Func<string> func, bool b)
                    , (string s, Func<bool> b), (Func<string> func, Func<bool> b)>[] classNames)
            => string.Join(" ", Utils.StyleOrClassNames(classNames));

        /// <summary>
        /// Example: StyleValues(style ,(style,true|flase) ,(()=>style,true|flase))
        /// </summary>
        protected static string StyleValues(params OneOf<string, (string s, bool b), (Func<string> func, bool b)
                    , (string s, Func<bool> b), (Func<string> func, Func<bool> b)>[] styleValues)
            => string.Join(";", Utils.StyleOrClassNames(styleValues)?.Select(s => s.TrimEnd(';')));
    }
}
