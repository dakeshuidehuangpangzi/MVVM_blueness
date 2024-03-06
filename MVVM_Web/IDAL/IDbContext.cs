using EFCore;

namespace IDAL
{
    public interface IDbContext
    {
        EFCoreContext GetDbContext();
    }
}