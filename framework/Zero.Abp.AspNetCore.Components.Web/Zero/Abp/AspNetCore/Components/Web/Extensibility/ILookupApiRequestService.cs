using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Zero.Abp.AspNetCore.Components.Web.Extensibility
{
    public interface ILookupApiRequestService
    {
        Task<string> SendAsync([NotNull]string url);
    }
}