using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class RouteManager : IRouteManager, ITransientDependency
    {
        protected IMenuManager MenuManager { get; }
        protected NavigationManager NavigationManager { get; }

        public RouteManager(
            IMenuManager menuManager,
            NavigationManager navigationManager)
        {
            MenuManager = menuManager;
            NavigationManager = navigationManager;
        }

        public async Task<ApplicationMenuItemList> GetMenuDataAsync()
        {
            return (await MenuManager.GetMainMenuAsync())?.GetAdministration()?.Items ?? new ApplicationMenuItemList();
        }

        public async Task<string[]> GetMatchMenuKeysAsync(bool fullKeys)
        {
            var flatMenus = await GetFlatMenuAsync();
            return GetMatchMenuKeys(flatMenus, fullKeys);
        }

        public async Task<string[]> GetFirstLeafPathsNameAsync(string name)
        {
            var flatMenus = await GetFlatMenuAsync();
            return flatMenus.Find(f => f.IsLeaf && f.PathsName.Contains(name)).PathsName.ToArray();
        }

        public async Task<ApplicationMenuItemList> GetMatchMenusAsync(bool fullKeys)
        {
            var flatMenus = await GetFlatMenuAsync();
            var menuPathKeys = GetMatchMenuKeys(flatMenus, fullKeys);
            var matchMenus = menuPathKeys.Select(menuPathKey => flatMenus.Find(f => f.Name == menuPathKey).MenuItem);
            return new ApplicationMenuItemList(matchMenus);
        }

        #region 内部方法
        /// <summary>
        /// 获取平面菜单
        /// </summary>
        /// <param name="menuData">树形菜单数据</param>
        /// <param name="parentsName">父级路径名</param>
        /// <returns></returns>
        private async Task<List<(string Name, ApplicationMenuItem MenuItem, string[] PathsName, string Url, bool IsLeaf)>> GetFlatMenuAsync(
            ApplicationMenuItemList menuData = null, List<string> parentsName = null)
        {
            parentsName ??= new List<string> { };
            menuData ??= await GetMenuDataAsync();
            menuData = new ApplicationMenuItemList(menuData.OrderBy(o => o.Order));
            var menus = new List<(string name, ApplicationMenuItem menuItem, string[] pathsName, string url, bool isLeaf)>();
            menuData.ForEach(async item =>
            {
                if (item?.Name == null) { return; }
                var tempPathsName = parentsName.Select(s => s).ToList();
                tempPathsName.AddLast(item.Name);
                var menuItem = new ApplicationMenuItem(item.Name, item.DisplayName, item.Url, item.Icon, item.Order, item.CustomData, item.Target, item.ElementId, item.CssClass);
                menus.Add((item.Name, menuItem, tempPathsName.ToArray(), item?.Url?.TrimStart('~'), item.IsLeaf));
                if (!item.IsLeaf)
                {
                    menus.AddRange(await GetFlatMenuAsync(item?.Items ?? new ApplicationMenuItemList(), tempPathsName));
                }
            });
            return menus;
        }

        private string[] GetMatchMenuKeys(List<(string Name, ApplicationMenuItem MenuItem, string[] PathsName, string Url, bool IsLeaf)> flatMenus, bool fullKeys)
        {
            if (flatMenus.IsNullOrEmpty()) { return Array.Empty<string>(); }
            var tempFlatMenus = flatMenus
                .Where(w => !w.Url.IsNullOrWhiteSpace())
                .Select(item => (item.PathsName, item.Url)).ToList();
            var menuPathKeys = GetMenuMatches(tempFlatMenus);
            if (menuPathKeys.IsNullOrEmpty()) { return Array.Empty<string>(); }
            if (!fullKeys) { menuPathKeys = new string[] { menuPathKeys.LastOrDefault() }; }
            return menuPathKeys;
        }
        private string[] GetMenuMatches(List<(string[] PathsName, string Url)> flatMenus)
        {
            var tempFlatMenus = flatMenus.Where(w => !w.Url.IsNullOrWhiteSpace()).ToList();
            var currentUriAbsolute = NavigationManager.Uri;
            return tempFlatMenus.Find(item =>
            {
                if (!item.Url.StartsWith("http"))
                {
                    var _hrefAbsolute = NavigationManager.ToAbsoluteUri(item.Url).AbsoluteUri;
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

    public interface IRouteManager
    {
        Task<ApplicationMenuItemList> GetMenuDataAsync();
        Task<string[]> GetMatchMenuKeysAsync(bool fullKeys);
        Task<string[]> GetFirstLeafPathsNameAsync(string name);
        Task<ApplicationMenuItemList> GetMatchMenusAsync(bool fullKeys);
    }
}
