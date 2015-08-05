using System;
using System.Collections.Generic;

namespace TangOrganizer.Model.Models
{
    public partial class Evento
    {
        public Evento()
        {
            this.Attivitas = new List<Attivita>();
            this.Pacchettoes = new List<Pacchetto>();
        }

        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Nullable<System.DateTime> DataInizio { get; set; }
        public Nullable<System.DateTime> DataFine { get; set; }
        public string Luogo { get; set; }
        public Nullable<bool> Cancellato { get; set; }
        public Nullable<System.DateTime> BaseInfo_DataCreazione { get; set; }
        public string BaseInfo_CreatoDa { get; set; }
        public Nullable<System.DateTime> BaseInfo_DataUltimaModifica { get; set; }
        public string BaseInfo_ModificatoDa { get; set; }
        public virtual ICollection<Attivita> Attivitas { get; set; }
        public virtual ICollection<Pacchetto> Pacchettoes { get; set; }
    }
}
