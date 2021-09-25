using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    public abstract class AbpTagHelperService<TTagHelper> : IAbpTagHelperService<TTagHelper>
        where TTagHelper : TagHelper
    {
        public TTagHelper TagHelper { get; internal set; }

        public virtual int Order { get; }

        public virtual void Init(TagHelperContext context)
        {

        }

        public virtual void Process(TagHelperContext context, TagHelperOutput output)
        {

        }

        public virtual Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            Process(context, output);
            return Task.CompletedTask;
        }
    }
}
