using SmartEvents.Model.BaseModels;

namespace SmartEvents.Web.Models
{
  public class SearchResults : BaseSearch
  {
    public object Results { get; set; }
    public bool HasErrors { get; set; }
    public string Message { get; set; }
  }
}
