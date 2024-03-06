using EFCore;
using IDAL;

namespace DAL
{
    public class EFCoreDbContext : IDbContext
    {
        EFCoreContext eFCoreContext = null;
        public EFCoreDbContext() {
            eFCoreContext= new EFCoreContext();
        }
        public EFCoreContext GetDbContext() => eFCoreContext;
    }
}