using IDS_Integrador.Model.Entity;

namespace IDS_Integrador.Database
{
    public interface IStoreRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Role> Roles {get; }
    }    
}