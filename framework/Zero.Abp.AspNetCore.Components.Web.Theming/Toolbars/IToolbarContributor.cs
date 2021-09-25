using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Web.Theming.Toolbars
{
    public interface IToolbarContributor
    {
        Task ConfigureToolbarAsync(IToolbarConfigurationContext context);
    }
}