﻿using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Web.Theming.PageToolbars
{
    public abstract class PageToolbarContributor : IPageToolbarContributor
    {
        public abstract Task ContributeAsync(PageToolbarContributionContext context);
    }
}
