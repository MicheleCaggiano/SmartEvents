using System;
using System.Collections.Generic;
using System.Linq;
using TangOrganizer.DAL.Interfaces;
using TangOrganizer.Model.Models;

namespace TangOrganizer.Service
{
  public class PacchettoService : BaseService<Pacchetto>
  {
    public PacchettoService(IRepository<Pacchetto> baseRepository)
      : base(baseRepository)
    {
    }

    /// <summary>
    /// Save new entity
    /// </summary>
    /// <param name="pacchetto"></param>
    /// <param name="userName"></param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Save(Pacchetto pacchetto, string userName)
    {
      pacchetto.BaseInfo_CreatoDa = pacchetto.BaseInfo_ModificatoDa = userName;
      pacchetto.BaseInfo_DataCreazione = pacchetto.BaseInfo_DataUltimaModifica = DateTime.Now;
      return base.Save(pacchetto);
    }

    /// <summary>
    /// Update pacchetto
    /// </summary>
    /// <param name="pacchetto"></param>
    /// <param name="userName"></param>
    /// <returns>True if no errors occurs, False otherwise</returns>
    public bool Update(Pacchetto pacchetto, string userName)
    {
      pacchetto.BaseInfo_ModificatoDa = userName;
      pacchetto.BaseInfo_DataUltimaModifica = DateTime.Now;
      return base.Save(pacchetto);
    }
  }
}
