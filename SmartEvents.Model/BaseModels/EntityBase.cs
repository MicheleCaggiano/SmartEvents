namespace TangOrganizer.Model.BaseModels
{
  public class EntityBase
  {
    public System.DateTime AuthInfo_DataCreazione { get; set; }
    public string AuthInfo_CreatoDa { get; set; }
    public System.DateTime AuthInfo_DataUltimaModifica { get; set; }
    public string AuthInfo_ModificatoDa { get; set; }
    public string AuthInfo_UserId { get; set; }
  }
}
