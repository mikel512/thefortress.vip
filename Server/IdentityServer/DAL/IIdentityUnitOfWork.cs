using IdentityServer.Services;

namespace IdentityServer.DAL
{
    public interface IIdentityUnitOfWork
    {
        IUserAuthRepository UserAuth { get; }
    }
}
