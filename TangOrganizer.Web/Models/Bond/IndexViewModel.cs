using System.Linq;

namespace SmartEvents.Web.Models.Bond
{
  public class IndexViewModel
  {
    public IndexViewModel()
    {
      BondBaseSearch = new BondSearchFilters();
    }

    public BondSearchFilters BondBaseSearch { get; set; }
    public IQueryable<Model.BondSystemEntities.Bond> Results { get; set; }
    public IQueryable<Factory> Factories { get; set; }
    public IQueryable<ProductLine> ProductLines { get; set; }
    public IQueryable<OriginalEquipment> OriginalEquipments { get; set; }
    public IQueryable<MarketSegment> MarketSegments { get; set; }
    public IQueryable<ReasonType> ReasonTypes { get; set; }
    public IQueryable<BondStatus> BondStatus { get; set; }
    public IQueryable<User1> Users { get; set; }
  }
}