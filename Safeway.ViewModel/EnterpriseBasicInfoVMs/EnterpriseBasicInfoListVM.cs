using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseBasicInfoVMs
{
    public partial class EnterpriseBasicInfoListVM : BasePagedListVM<EnterpriseBasicInfo_View, EnterpriseBasicInfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 1000, dialogHeight:800),
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 1000, dialogHeight:800),
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 1000, dialogHeight:800),
                //this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                //this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriseBasicInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriseBasicInfo_View>>{
                this.MakeGridHeader(x => x.ComapanyName, width: 200),
                //this.MakeGridHeader(x => x.Province),
                //this.MakeGridHeader(x => x.City),
                //this.MakeGridHeader(x => x.District),
                this.MakeGridHeader(x => x.Street),
                this.MakeGridHeader(x => x.CompanyType, width: 80),
                //this.MakeGridHeader(x => x.ForeignCountry, width: 100),
                this.MakeGridHeader(x => x.LegalRepresentative, width: 100),
                this.MakeGridHeader(x => x.CompanyScale, width: 80),
                this.MakeGridHeader(x => x.Industry),
                this.MakeGridHeader(x => x.NoofEmployees, width: 80),
                this.MakeGridHeader(x => x.MainProducts, width: 80),
                this.MakeGridHeader(x => x.TermsofTrade),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriseBasicInfo_View> GetSearchQuery()
        {
            var query = DC.Set<EnterpriseBasicInfo>()
                .CheckContain(Searcher.Province, x=> x.Province)
                .CheckContain(Searcher.City, x=> x.City)
                .CheckContain(Searcher.District, x=> x.District)
                .CheckEqual(Searcher.EnterpriseBasicId, x => x.ID)
                .Select(x => new EnterpriseBasicInfo_View
                {
				    ID = x.ID,
                    ComapanyName = x.ComapanyName,
                    Province = x.Province,
                    City = x.City,
                    District = x.District,
                    Street = x.Street,
                    CompanyType = x.CompanyType,
                    ForeignCountry = x.ForeignCountry,
                    LegalRepresentative = x.LegalRepresentative,
                    CompanyScale = x.CompanyScale,
                    Industry = x.Industry,
                    NoofEmployees = x.NoofEmployees,
                    MainProducts = x.MainProducts,
                    TermsofTrade = x.TermsofTrade,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class EnterpriseBasicInfo_View : EnterpriseBasicInfo{

    }
}
