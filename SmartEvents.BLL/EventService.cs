using System.Collections.Generic;
using System.Linq;
using SmartEvents.DAL.Interfaces;
using SmartEvents.Model;

namespace SmartEvents.BLL
{
  public class EventService : BaseService<Event>
  {
    public EventService(IRepository<Event> baseRepository)
      : base(baseRepository)
    {
    }

    public IEnumerable<Event> GetEvents(int skip, int take)
    {
      return FindAll().Skip(skip).Take(take).ToList();
    }
  }
}
