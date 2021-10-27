using System.Collections.Generic;

namespace Zero.Abp.AspNetCore.Components.Web.Extensibility.TableToolbar
{
    public class TableToolbarDictionary : Dictionary<string, List<TableToolbarItem>>
    {
        public List<TableToolbarItem> Get<T>()
        {
            return this.GetOrAdd(typeof(T).FullName, () => new List<TableToolbarItem>());
        }
    }
}