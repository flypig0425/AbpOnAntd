using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AspNetCore.Components.Web.AntdTheme
{
    public static class IMenuManagerExtensions
    {
        public static async Task<ApplicationMenuItemList> GetMainMenuItemsAsync(this IMenuManager menuManager)
        {
            return (await menuManager.GetMainMenuAsync())?.Items ?? new ApplicationMenuItemList();
        }

        public static string[] GetMatchMenuKeys(this NavigationManager navigationManager, ApplicationMenuItemList applicationMenus, bool fullKeys)
        {
            var flatMenus = GetFlatMenu(applicationMenus);
            return navigationManager.GetMatchMenuKeys(flatMenus, fullKeys);
        }

        #region 内部方法
        /// <summary>
        /// 获取平面菜单
        /// </summary>
        /// <param name="menuData">树形菜单数据</param>
        /// <param name="parentsName">父级路径名</param>
        /// <returns></returns>
        private static List<(string Name, ApplicationMenuItem MenuItem, string[] PathsName, string Url, bool IsLeaf)> GetFlatMenu(
            ApplicationMenuItemList menuData, List<string> parentsName = null)
        {
            var menus = new List<(string name, ApplicationMenuItem menuItem, string[] pathsName, string url, bool isLeaf)>();
            if (menuData.IsNullOrEmpty()) { return menus; }
            parentsName ??= new List<string> { };
            menuData = new ApplicationMenuItemList(menuData.OrderBy(o => o.Order));
            menuData.ForEach(item =>
           {
               if (item?.Name == null) { return; }
               var tempPathsName = parentsName.Select(s => s).ToList();
               tempPathsName.AddLast(item.Name);
               var menuItem = new ApplicationMenuItem(item.Name, item.DisplayName, item.Url, item.Icon, item.Order, item.CustomData, item.Target, item.ElementId, item.CssClass);
               menus.Add((item.Name, menuItem, tempPathsName.ToArray(), item?.Url?.TrimStart('~'), item.IsLeaf));
               if (!item.IsLeaf)
               {
                   menus.AddRange(GetFlatMenu(item?.Items ?? new ApplicationMenuItemList(), tempPathsName));
               }
           });
            return menus;
        }


        private static string[] GetMatchMenuKeys(this NavigationManager navigationManager,
            List<(string Name, ApplicationMenuItem MenuItem, string[] PathsName, string Url, bool IsLeaf)> flatMenus, bool fullKeys)
        {
            if (flatMenus.IsNullOrEmpty()) { return Array.Empty<string>(); }
            var tempFlatMenus = flatMenus
                .Where(w => !w.Url.IsNullOrWhiteSpace())
                .Select(item => (item.PathsName, item.Url)).ToList();
            var menuPathKeys = navigationManager.GetMenuMatches(tempFlatMenus);
            if (menuPathKeys.IsNullOrEmpty()) { return Array.Empty<string>(); }
            if (!fullKeys) { menuPathKeys = new string[] { menuPathKeys.LastOrDefault() }; }
            return menuPathKeys;
        }

        private static string[] GetMenuMatches(this NavigationManager navigationManager, List<(string[] PathsName, string Url)> flatMenus)
        {
            var tempFlatMenus = flatMenus.Where(w => !w.Url.IsNullOrWhiteSpace()).ToList();
            var currentUriAbsolute = navigationManager.Uri;
            return tempFlatMenus.Find(item =>
            {
                if (!item.Url.StartsWith("http"))
                {
                    var _hrefAbsolute = navigationManager.ToAbsoluteUri(item.Url).AbsoluteUri;
                    if (string.Equals(currentUriAbsolute, _hrefAbsolute, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    if (currentUriAbsolute.Length == _hrefAbsolute.Length - 1)
                    {
                        if (_hrefAbsolute[^1] == '/' && _hrefAbsolute.StartsWith(currentUriAbsolute, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                    //if (item.Match == NavLinkMatch.Prefix)
                    //{
                    //    int prefixLength = _hrefAbsolute.Length;
                    //    if (currentUriAbsolute.Length > prefixLength)
                    //    {
                    //        return currentUriAbsolute.StartsWith(_hrefAbsolute, StringComparison.OrdinalIgnoreCase)
                    //    && (prefixLength == 0
                    //    || !char.IsLetterOrDigit(_hrefAbsolute[prefixLength - 1])
                    //    || !char.IsLetterOrDigit(_hrefAbsolute[prefixLength])
                    //    );
                    //    }
                    //}
                }
                return false;
            }).PathsName;
        }

        #endregion
    }
}
