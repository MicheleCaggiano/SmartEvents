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
        public System.Guid EventoId { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
