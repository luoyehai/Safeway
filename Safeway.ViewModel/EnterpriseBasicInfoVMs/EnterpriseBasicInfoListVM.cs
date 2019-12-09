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
        public List<KeyValuePair> tradeTermList = new List<KeyValuePair>()
        {
             new KeyValuePair() { label ="出口",value="Export"},
             new KeyValuePair() { label ="内销",value="DomesticSales"}
        };
        public List<KeyValuePair> companyScaleList = new List<KeyValuePair>()
        {
             new KeyValuePair() { label ="规上",value="large"},
             new KeyValuePair() { label ="小型",value="small"},
             new KeyValuePair() { label ="微型",value="mini"}
        };
        public List<KeyValuePair> companyTypeList = new List<KeyValuePair>() { 

            new KeyValuePair() { label ="国有",value="stateOwned"},
            new KeyValuePair() { label ="民营",value="private"},
            new KeyValuePair() { label ="外资",value="foreignInvest"},
            new KeyValuePair() { label ="美国",value="usa"},
            new KeyValuePair() { label ="欧洲",value="eur"},
            new KeyValuePair() { label ="日本",value="jpn"},
            new KeyValuePair() { label ="其他",value="others"}

        } ;
        public List<KeyValuePair> industryList = new List<KeyValuePair>() {

            new KeyValuePair() { label ="矿山",value="Mine"},
            new KeyValuePair() { label ="道路运输",value="Transportation"},
            new KeyValuePair() { label ="危化",value="DangerChemistry"},
            new KeyValuePair() { label ="工贸",value="IndustryandTrade"},
            new KeyValuePair() { label ="冶金",value="metallurgy"},
            new KeyValuePair() { label ="有色",value="colored"},
            new KeyValuePair() { label ="机械",value="mechanical"},
            new KeyValuePair() { label ="建材",value="buildingMaterial"},
            new KeyValuePair() { label ="纺织",value="textile"},
            new KeyValuePair() { label ="轻工",value="lightIndustry"},
            new KeyValuePair() { label ="烟草",value="tobacoo"},
            new KeyValuePair() { label ="商贸",value="bizsTrade"}

        };
 
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
            var result = new List<EnterpriseBasicInfo_View>();
            var query = DC.Set<EnterpriseBasicInfo>()
                .CheckContain(Searcher.Street, x=> x.Street)
                .CheckContain(Searcher.Industry, x => x.Industry)
                .CheckContain(Searcher.CompanyType, x => x.CompanyType)
                .CheckContain(Searcher.CompanyScale, x => x.CompanyScale)
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
                    //GetEnumDescription((companyScaleList)Array.IndexOf(Enum.GetValues(x.CompanyScale.GetType()), x.CompanyScale)),
                    Industry = x.Industry,
                    NoofEmployees = x.NoofEmployees,
                    MainProducts = x.MainProducts,
                    TermsofTrade = x.TermsofTrade
                    //GetEnumDescription((tradeTermList)Array.IndexOf(Enum.GetValues(x.TermsofTrade.GetType()), x.TermsofTrade)),
                })
                .OrderBy(x => x.ID);
            return query;
            //var data = query.ToList();
            //for (int j= 0;j < data.Count();j++) 
            //{
            //    var temp = new EnterpriseBasicInfo_View();
            //    temp.ID = data[j].ID;
            //    temp.ComapanyName = data[j].ComapanyName;
            //    temp.Province = data[j].Province;
            //    temp.City = data[j].City;
            //    temp.District = data[j].District;
            //    temp.Street = data[j].Street;
            //    temp.CompanyType = data[j].CompanyType;
            //    temp.ForeignCountry = data[j].ForeignCountry;
            //    temp.LegalRepresentative = data[j].LegalRepresentative;
            //    temp.CompanyScale = data[j].CompanyScale;
            //    temp.Industry = data[j].Industry;
            //    temp.NoofEmployees = data[j].NoofEmployees;
            //    temp.MainProducts = data[j].MainProducts;
            //    temp.TermsofTrade = data[j].TermsofTrade;
            //    temp.CompanyType = data[j].CompanyType;
            //    temp.Industry = data[j].Industry;
            //    for (int i = 0; i < companyTypeList.Count; i++)
            //    {
            //        if (temp.CompanyType!= null && temp.CompanyType.Contains(companyTypeList[i].value))
            //        {
            //            temp.CompanyType= temp.CompanyType.Replace(companyTypeList[i].value, companyTypeList[i].label);
            //        }
            //    }
            //    for (int i = 0; i < industryList.Count; i++) 
            //    {
            //        if (temp.Industry != null && temp.Industry.Contains(industryList[i].value)) 
            //        {
            //            temp.Industry = temp.Industry.Replace(industryList[i].value, industryList[i].label);
            //        }
            //    }
            //    for (int i = 0; i < companyScaleList.Count; i++)
            //    {
            //        if (temp.CompanyScale != null && temp.CompanyScale.Equals(companyScaleList[i].value)) 
            //        {
            //            temp.CompanyScale = temp.CompanyScale.Replace(companyScaleList[i].value, companyScaleList[i].label);
            //        }
                
            //    }
            //    for (int i = 0; i < tradeTermList.Count; i++)
            //    {
            //        if (temp.TermsofTrade != null && temp.TermsofTrade.Equals(tradeTermList[i].value))
            //        {
            //            temp.TermsofTrade = temp.TermsofTrade.Replace(tradeTermList[i].value, tradeTermList[i].label);
            //        }

            //    }

            //    result.Add(temp);
            //}
            //return (IOrderedQueryable<EnterpriseBasicInfo_View>)result.AsQueryable<EnterpriseBasicInfo_View>();

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
