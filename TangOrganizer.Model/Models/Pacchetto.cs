using System;
using System.Collections.Generic;

namespace TangOrganizer.Model.Models
{
    public partial class Pacchetto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Nullable<decimal> Prezzo { get; set; }
        public Nullable<System.DateTime> BaseInfo_DataCreazione { get; set; }
        public string BaseInfo_CreatoDa { get; set; }
        public Nullable<System.DateTime> BaseInfo_DataUltimaModifica { get; set; }
        public string BaseInfo_ModificatoDa { get; set; }
        public System.Guid EventoId { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
