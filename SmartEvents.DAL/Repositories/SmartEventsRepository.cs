using SmartEvents.DAL.Interfaces;
using SmartEvents.Model.Models;

namespace SmartEvents.DAL.Repositories
{
  public class SmartEventsRepository<TEntity> : Repository<TEntity, TangOrganizerContext>, ISmartEventsRepository<TEntity>
    where TEntity : class
  {
    public SmartEventsRepository()
      : base(new TangOrganizerContext())
    {
    }
  }
}