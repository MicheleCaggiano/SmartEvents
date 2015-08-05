namespace TangOrganizer.Model.BaseModels
{
  public class EntityBase
  {
    public System.DateTime BaseInfo_DataCreazione { get; set; }
    public string BaseInfo_CreatoDa { get; set; }
    public System.DateTime BaseInfo_DataUltimaModifica { get; set; }
    public string BaseInfo_ModificatoDa { get; set; }
    public string BaseInfo_UserId { get; set; }
  }
}
