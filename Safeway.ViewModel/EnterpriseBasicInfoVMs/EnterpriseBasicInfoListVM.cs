using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Enterprise;
using System.ComponentModel;
using System.Reflection;


namespace Safeway.ViewModel.EnterpriseBasicInfoVMs
{
    public class KeyValuePair
    {
        public string label { get; set; }

        public string value { get; set; }
    }
    public partial class EnterpriseBasicInfoListVM : BasePagedListVM<EnterpriseBasicInfo_View, EnterpriseBasicInfoSearcher>
    {

        public List<ComboSelectListItem> CompanyScaleList { get; set; }

        public List<ComboSelectListItem> CompanyTypeList { get; set; }

        public List<ComboSelectListItem> TradeMethodList { get; set; }

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 1400, dialogHeight:800),
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 1400, dialogHeight:800),
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 1400, dialogHeight:800),
                //this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                //this.MakeStandardAction("EnterpriseBasicInfo", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriseBasicInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriseBasicInfo_View>>{
                this.MakeGridHeader(x => x.ComapanyName, width: 260),
                //this.MakeGridHeader(x => x.Province),
                //this.MakeGridHeader(x => x.City),
                //this.MakeGridHeader(x => x.District),
                this.MakeGridHeader(x => x.Street, width: 160),
                this.MakeGridHeader(x => x.CompanyType, width: 100),
                //this.MakeGridHeader(x => x.ForeignCountry, width: 100),
                this.MakeGridHeader(x => x.LegalRepresentative, width: 100),
                this.MakeGridHeader(x => x.CompanyScale, width: 100),
                this.MakeGridHeader(x => x.Industry),
                this.MakeGridHeader(x => x.NoofEmployees, width: 100),
                this.MakeGridHeader(x => x.MainProducts, width: 100),
                this.MakeGridHeader(x => x.TermsofTrade),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriseBasicInfo_View> GetSearchQuery()
        {
            var result = new List<EnterpriseBasicInfo_View>();
            var query = DC.Set<EnterpriseBasicInfo>()
                .CheckContain(Searcher.Street, x=> x.Street)
                .CheckContain(Searcher.Industry, x => x.Industry)
                .CheckContain(Searcher.CompanyType, x => x.CompanyType)
                .CheckContain(Searcher.CompanyScale, x => x.CompanyScale)
                .CheckContain(Searcher.TermsofTrade, x => x.TermsofTrade)
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
                    TermsofTrade = x.TermsofTrade
                })
                .OrderBy(x => x.ID);
            return query;

        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }

    public class EnterpriseBasicInfo_View : EnterpriseBasicInfo{

    }
}
