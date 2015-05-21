namespace SmartEvents.Model.BaseModels
{
  public class BaseSearch
  {
    public BaseSearch()
    {
      CurrentPage = 1;
      PageSize = 10;
      ItemsByPage = 10;
    }

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalResults { get; set; }
    public int ItemsByPage { get; set; }
  }
}