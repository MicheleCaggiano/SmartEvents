using TangOrganizer.DAL.Interfaces;
using TangOrganizer.Model.Models;

namespace TangOrganizer.DAL.Repositories
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