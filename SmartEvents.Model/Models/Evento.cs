using System;
using System.Collections.Generic;

namespace SmartEvents.Model.Models
{
  public partial class Evento
  {
    public System.Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descrizione { get; set; }
    public bool Cancellato { get; set; }
    public System.DateTime DataInizio { get; set; }
    public System.DateTime DataFine { get; set; }
    public string Luogo { get; set; }
    public System.DateTime AuthInfo_DataCreazione { get; set; }
    public string AuthInfo_CreatoDa { get; set; }
    public System.DateTime AuthInfo_DataUltimaModifica { get; set; }
    public string AuthInfo_ModificatoDa { get; set; }
    public string AuthInfo_UserId { get; set; }
  }
}
