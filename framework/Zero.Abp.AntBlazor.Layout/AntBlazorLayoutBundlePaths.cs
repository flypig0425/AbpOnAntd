using System;

namespace Zero.Abp.AntBlazor.Layout
{
    public class AntBlazorLayoutBundlePaths
    {
        private static readonly string AssemblyName = typeof(AbpAntBlazorLayoutModule).Assembly.GetName().Name;

        public static readonly string[] Styles = new[]{
            $"/_content/{AssemblyName}/css/abp-antdesign-blazor.css"
        };

        public static readonly string[] Scripts = Array.Empty<string>();
    }
}