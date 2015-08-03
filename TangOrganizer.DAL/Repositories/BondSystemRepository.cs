using BondSystem.DAL.Interfaces;
using BondSystem.Model.BondSystemEntities;

namespace BondSystem.DAL.Repositories
{
    public class BondSystemRepository<TEntity> : Repository<TEntity, BondSystemContext>, IBondSystemRepository<TEntity>
            where TEntity : class
    {
        public BondSystemRepository()
            : base(new BondSystemContext())
        {
        }
    }
}