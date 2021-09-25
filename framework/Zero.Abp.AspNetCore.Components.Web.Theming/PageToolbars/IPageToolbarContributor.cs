using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Web.Theming.PageToolbars
{
    public interface IPageToolbarContributor
    {
        Task ContributeAsync(PageToolbarContributionContext context);
    }
}
