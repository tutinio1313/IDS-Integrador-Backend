using IDS_Integrador.Model.Entity;

namespace IDS_Integrador.Database
{
    public class EFStoreRepository : IStoreRepository
    {
        private IDSBContext context;
        public EFStoreRepository(IDSBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<User> Users => context.Users;
        public IQueryable<Role> Roles => context.Roles;
    }
}