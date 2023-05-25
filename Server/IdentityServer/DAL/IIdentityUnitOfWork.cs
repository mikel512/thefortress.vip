using vApplication.Interface;

namespace IdentityServer.DAL
{
    public interface IIdentityUnitOfWork
    {
        IUserAuthRepository UserAuth { get; }
    }
}
