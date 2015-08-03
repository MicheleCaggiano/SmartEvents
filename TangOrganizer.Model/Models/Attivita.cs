using System;
using System.Collections.Generic;

namespace TangOrganizer.Model.Models
{
    public partial class Attivita
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Nullable<System.DateTime> DataInizio { get; set; }
        public Nullable<System.DateTime> DataFine { get; set; }
        public string Luogo { get; set; }
        public int LimiteIscrizioni { get; set; }
        public bool Cancellato { get; set; }
        public System.DateTime AuthInfo_DataCreazione { get; set; }
        public string AuthInfo_CreatoDa { get; set; }
        public System.DateTime AuthInfo_DataUltimaModifica { get; set; }
        public string AuthInfo_ModificatoDa { get; set; }
        public string AuthInfo_UserId { get; set; }
        public System.Guid EventoId { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
