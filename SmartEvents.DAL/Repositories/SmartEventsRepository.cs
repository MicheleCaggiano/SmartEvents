using SmartEvents.DAL.Interfaces;
using SmartEvents.Model.Models;

namespace SmartEvents.DAL.Repositories
{
  public class SmartEventsRepository<TEntity> : Repository<TEntity, SmartEventsContext>, ISmartEventsRepository<TEntity>
    where TEntity : class
  {
    public SmartEventsRepository()
      : base(new SmartEventsContext())
    {
    }
  }
}