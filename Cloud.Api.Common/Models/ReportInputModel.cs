using System.Linq;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Api.Common.Models
{
    public class ReportInputModel : SAPRESSC.Core.Persistence.Models.IEntityInputModel<Persistence.Entities.Report, int>
    {
        public ReportInputModel()
        {
            Cases = new System.Collections.Generic.List<CaseInputModel>();
        }

        public int Id { get; set; }

        public System.DateTime At { get; set; }

        public int RiskyContactCount { get; set; }

        public int TestCount { get; set; }

        public System.Collections.Generic.List<CaseInputModel> Cases { get; set; }

        public int DeadCaseCount { get; set; }

        public CaseDisplayModel[] DeadCases { get; set; }

        public int EvacuateCaseCount { get; set; }

        public CaseDisplayModel[] EvacuateCases { get; set; }

        public int GraveCaseCount { get; set; }

        public CaseDisplayModel[] GraveCases { get; set; }

        public int CriticCaseCount { get; set; }

        public CaseDisplayModel[] CriticCases { get; set; }

        public int RecoveredCaseCount { get; set; }

        public CaseDisplayModel[] RecoveredCases { get; set; }

        public string Notes { get; set; }

        public Persistence.Entities.Report Export()
        {
            var entity = new Persistence.Entities.Report
            {
                Id = Id
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Report entity)
        {
            Id = entity.Id;
            At = entity.At;
            RiskyContactCount = entity.RiskyContactCount;
            TestCount = entity.TestCount;
            Cases = entity.Cases.Select(e =>
            {
                var model = new CaseInputModel();

                model.Import(e);

                return model;
            }).ToList();
            DeadCaseCount = entity.DeadCaseCount;
            EvacuateCaseCount = entity.EvacuateCaseCount;
            GraveCaseCount = entity.GraveCaseCount;
            CriticCaseCount = entity.CriticCaseCount;
            RecoveredCaseCount = entity.RecoveredCaseCount;
            DeadCases = entity.DeadCaseBridges.Select(bridge =>
            {
                var model = new CaseDisplayModel();

                model.Import(bridge.Case);

                return model;
            }).ToArray();
            EvacuateCases = entity.EvacuateCaseBridges.Select(bridge =>
            {
                var model = new CaseDisplayModel();

                model.Import(bridge.Case);

                return model;
            }).ToArray();
            GraveCases = entity.EvacuateCaseBridges.Select(bridge =>
            {
                var model = new CaseDisplayModel();

                model.Import(bridge.Case);

                return model;
            }).ToArray();
            CriticCases = entity.CriticCaseBridges.Select(bridge =>
            {
                var model = new CaseDisplayModel();

                model.Import(bridge.Case);

                return model;
            }).ToArray();
            RecoveredCases = entity.RecoveredCaseBridges.Select(bridge =>
            {
                var model = new CaseDisplayModel();

                model.Import(bridge.Case);

                return model;
            }).ToArray();
        }

        public void Mergue(Persistence.Entities.Report entity)
        {
            entity.At = At;
            entity.Cases = Cases.Select(model =>
            {
                var result = model.Export();

                result.ReportId = Id;

                return result;
            }).ToList();
            entity.RiskyContactCount = RiskyContactCount;
            entity.TestCount = TestCount;
            entity.Notes = Notes;
            entity.CriticCaseCount = CriticCaseCount;
            entity.DeadCaseCount = DeadCaseCount;
            entity.EvacuateCaseCount = EvacuateCaseCount;
            entity.GraveCaseCount = GraveCaseCount;
            entity.RecoveredCaseCount = RecoveredCaseCount;

            if (CriticCases != null)
            {
                entity.CriticCaseBridges = CriticCases.Select(model => new Persistence.Entities.ReportCriticCaseBridge
                {
                    ReportId = Id,
                    CaseId = model.Id
                }).ToList();
            }

            if (DeadCases != null)
            {
                entity.DeadCaseBridges = DeadCases.Select(model => new Persistence.Entities.ReportDeadCaseBridge
                {
                    ReportId = Id,
                    CaseId = model.Id
                }).ToList();
            }

            if (EvacuateCases != null)
            {
                entity.EvacuateCaseBridges = EvacuateCases.Select(model => new Persistence.Entities.ReportEvacuateCaseBridge
                {
                    ReportId = Id,
                    CaseId = model.Id
                }).ToList();
            }

            if (GraveCases != null)
            {
                entity.GraveCaseBridges = CriticCases.Select(model => new Persistence.Entities.ReportGraveCaseBridge
                {
                    ReportId = Id,
                    CaseId = model.Id
                }).ToList();
            }

            if (RecoveredCases != null)
            {
                entity.RecoveredCaseBridges = CriticCases.Select(model => new Persistence.Entities.ReportRecoveredCaseBridge
                {
                    ReportId = Id,
                    CaseId = model.Id
                }).ToList();
            }
        }
    }
}
