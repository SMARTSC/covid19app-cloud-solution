namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class ReportDisplayModel : SAPRESSC.Core.Persistence.Models.IEntityDisplayModel<Persistence.Entities.Report, int>
    {
        public int Id { get; set; }

        public System.DateTime At { get; set; }

        public void Import(Persistence.Entities.Report entity)
        {
            Id = entity.Id;
            At = entity.At;
        }
    }
}
