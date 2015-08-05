using System;
using System.Collections.Generic;
using System.Linq;
using TangOrganizer.DAL.Interfaces;
using TangOrganizer.Model.Models;

namespace TangOrganizer.Service
{
  public class AttivitaService : BaseService<Attivita>
  {
    public AttivitaService(IRepository<Attivita> baseRepository)
      : base(baseRepository)
    {
    }

    /// <summary>
    /// Save new entity
    /// </summary>
    /// <param name="attivita"></param>
    /// <param name="userName"></param>
    /// <param name="userId"></param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Save(Attivita attivita, string userName, string userId)
    {
      return base.Save(attivita);
    }
  }
}
