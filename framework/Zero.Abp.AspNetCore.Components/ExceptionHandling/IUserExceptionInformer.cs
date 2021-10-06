using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.ExceptionHandling
{
    public interface IUserExceptionInformer
    {
        void Inform(UserExceptionInformerContext context);
        
        Task InformAsync(UserExceptionInformerContext context);
    }
}
