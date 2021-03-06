using System;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Web.Extensibility.EntityActions
{
    public class EntityAction : IEquatable<EntityAction>
    {
        public Func<object, bool> Visible { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public Func<object, Task> Clicked { get; set; }
        public Func<object, string> ConfirmationMessage { get; set; }

        //public bool Primary { get; set; }
        //public object ActionType { get; set; }
        public bool Equals(EntityAction other)
        {
            return string.Equals(Text, other?.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}
