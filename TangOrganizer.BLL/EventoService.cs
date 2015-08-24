using System;
using System.Collections.Generic;
using System.Linq;
using TangOrganizer.DAL.Interfaces;
using TangOrganizer.Model.Models;

namespace TangOrganizer.Service
{
  public class EventoService : BaseService<Evento>
  {
    public EventoService(IRepository<Evento> baseRepository)
      : base(baseRepository)
    {
    }

    public List<Evento> GetEvents(int skip, int take)
    {
      return FindAll().OrderByDescending(x => x.BaseInfo_DataCreazione)
      .Skip(skip).Take(take).ToList();
    }

    /// <summary>
    /// Save new entity
    /// </summary>
    /// <param name="evento"></param>
    /// <param name="userName"></param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Save(Evento evento, string userName)
    {
      evento.Id = Guid.NewGuid();
      evento.BaseInfo_CreatoDa = evento.BaseInfo_ModificatoDa = userName;
      evento.BaseInfo_DataCreazione = evento.BaseInfo_DataUltimaModifica = DateTime.Now;
      
      return base.Save(evento);
    }

    /// <summary>
    /// Update event
    /// </summary>
    /// <param name="evento"></param>
    /// <param name="userName"></param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Update(Evento evento, string userName)
    {
      evento.BaseInfo_ModificatoDa = userName; 
      evento.BaseInfo_DataUltimaModifica = DateTime.Now;

      return base.Update(evento);
    }
  }
}
