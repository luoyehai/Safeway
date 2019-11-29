using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;


namespace Safeway.ViewModel.EnterpriseBusinessinfoVMs
{
    public partial class EnterpriseBusinessinfoListVM : BasePagedListVM<EnterpriseBusinessinfo_View, EnterpriseBusinessinfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBusinessinfo", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriseBusinessinfo_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriseBusinessinfo_View>>{
                this.MakeGridHeader(x => x.SafetyServiceType),
                this.MakeGridHeader(x => x.OtherSafetyServiceType),
                this.MakeGridHeader(x => x.CertificateLevel),
                this.MakeGridHeader(x => x.ExpireDate),
                this.MakeGridHeader(x => x.OriginalServiceCom),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriseBusinessinfo_View> GetSearchQuery()
        {
            var query = DC.Set<EnterpriseBusinessinfo>()
                .CheckContain(Searcher.SafetyServiceType, x=>x.SafetyServiceType)
                .CheckEqual(Searcher.ExpireDate, x => x.ExpireDate)
                .CheckContain(Searcher.OtherSafetyServiceType, x=>x.OtherSafetyServiceType)
                .CheckContain(Searcher.CertificateLevel, x=>x.CertificateLevel)
                .CheckContain(Searcher.OriginalServiceCom, x=>x.OriginalServiceCom)
                .CheckContain(Searcher.Description, x=>x.Description)
                .Select(x => new EnterpriseBusinessinfo_View
                {
				    ID = x.ID,
                    SafetyServiceType = x.SafetyServiceType,
                    OtherSafetyServiceType = x.OtherSafetyServiceType,
                    CertificateLevel = x.CertificateLevel,
                    ExpireDate = x.ExpireDate,
                    OriginalServiceCom = x.OriginalServiceCom,
                    Description = x.Description,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class EnterpriseBusinessinfo_View : EnterpriseBusinessinfo{

    }
}
