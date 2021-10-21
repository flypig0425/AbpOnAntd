using Microsoft.Extensions.Localization;
using System;
using Volo.Abp.Localization;

namespace Zero.Abp.AntBlazorUI.Components.ObjectExtending
{
    public static class EnumHelper
    {
        public static string GetLocalizedMemberName(Type enumType, object value, IStringLocalizerFactory stringLocalizerFactory)
        {
            var memberName = enumType.GetEnumName(value);
            var localizedMemberName = AbpInternalLocalizationHelper.LocalizeWithFallback(
                new[]
                {
                        stringLocalizerFactory.CreateDefaultOrNull()
                },
                new[]
                {
                        $"Enum:{enumType.Name}.{memberName}",
                        $"{enumType.Name}.{memberName}",
                        memberName
                },
                memberName
            );

            return localizedMemberName;
        }
    }
}
