using System.Linq;
using System.Web.Mvc;
using SmartEvents.Web.Models;
using IndexViewModel = SmartEvents.Web.Models.Bond.IndexViewModel;

namespace SmartEvents.Web.Controllers
{
  public class BondController : BaseController
  {
    private readonly BondBll _bondBll;
    private readonly FactoryBll _factoryBll;
    private readonly ProductLineBll _productLineBll;
    private readonly BondStatusBll _bondStatusBll;
    private readonly MarketSegmentBll _marketSegmentBll;
    private readonly ReasonTypeBll _reasonTypeBll;
    private readonly User1Bll _userBll;

    public BondController(BondBll bondBll, FactoryBll factoryBll, ProductLineBll productLineBll,
      BondStatusBll bondStatusBll, ReasonTypeBll reasonTypeBll, MarketSegmentBll marketSegmentBll,
      User1Bll userBll)
    {
      _bondBll = bondBll;
      _factoryBll = factoryBll;
      _productLineBll = productLineBll;
      _bondStatusBll = bondStatusBll;
      _reasonTypeBll = reasonTypeBll;
      _marketSegmentBll = marketSegmentBll;
      _userBll = userBll;
    }

    public ActionResult Index()
    {
      // Gets the last 10 Bond created
      var bondResults = _bondBll.FindAll().OrderByDescending(x => x.Created).Take(10);

      // Prepare search view model
      var searchViewModel = new IndexViewModel
      {
        Results = bondResults,
        Factories = _factoryBll.FindAll(),
        ProductLines = _productLineBll.FindAll(),
        BondStatus = _bondStatusBll.FindAll(),
        MarketSegments = _marketSegmentBll.FindAll(),
        ReasonTypes = _reasonTypeBll.FindAll(),
        Users = _userBll.FindAll()
      };
      return View(searchViewModel);
    }

    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Details(int? id)
    {
      if (!id.HasValue) return View();
      var bond = _bondBll.FindById(id);
      return bond == null ? View() : View(bond);
    }

    [HttpPost]
    // Disable cache for http.get requests 
    //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
    public ActionResult Search(BondSearchFilters filters)
    {
      var bondResults = _bondBll.FindAll(filters);

      var skipResultNumber = (filters.CurrentPage - 1) * filters.PageSize;
      var searchResults = new SearchResults
      {
        TotalResults = bondResults.Count(),
        Results = bondResults.OrderByDescending(x => x.Created).Skip(skipResultNumber).Take(filters.PageSize).ToList(),
        PageSize = filters.PageSize,
        CurrentPage = filters.CurrentPage,
        ItemsByPage = filters.PageSize
      };

      return GetJson(searchResults);
    }

  }
}