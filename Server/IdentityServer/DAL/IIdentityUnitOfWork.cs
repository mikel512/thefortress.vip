using IdentityServer.Interfaces;

namespace IdentityServer.DAL
{
    public interface IIdentityUnitOfWork
    {
        IUserAuthRepository UserAuth { get; }
    }
}
