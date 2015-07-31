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
      return FindAll().OrderByDescending(x => x.AuthInfo_DataCreazione)
      .Skip(skip).Take(take).ToList();
    }

    /// <summary>
    /// Save new entity
    /// </summary>
    /// <param name="evento"></param>
    /// <param name="userName"></param>
    /// <param name="userId"></param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Save(Evento evento, string userName, string userId)
    {
      evento.Id = Guid.NewGuid();
      evento.AuthInfo_DataCreazione = evento.AuthInfo_DataUltimaModifica = DateTime.Now;
      evento.AuthInfo_CreatoDa = evento.AuthInfo_ModificatoDa = userName;
      evento.AuthInfo_UserId = userId;
      return base.Save(evento);
    }
  }
}
