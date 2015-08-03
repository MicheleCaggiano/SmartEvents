using System.Collections.Generic;
using TangOrganizer.Model.Models;

namespace TangOrganizer.Dashboard.Models
{
  public class EventoViewModel
  {
    public Evento Evento { get; set; }
    public IEnumerable<Attivita> Milonghe { get; set; }
    public IEnumerable<Attivita> Lezioni { get; set; }
  }
}