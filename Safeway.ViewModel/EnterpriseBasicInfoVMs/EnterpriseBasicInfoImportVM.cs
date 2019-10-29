using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseBasicInfoVMs
{
    public partial class EnterpriseBasicInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "公司名称")]
        public ExcelPropety ComapanyName_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.ComapanyName);
        [Display(Name = "省份")]
        public ExcelPropety Province_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.Province);
        [Display(Name = "市")]
        public ExcelPropety City_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.City);
        [Display(Name = "区")]
        public ExcelPropety District_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.District);
        [Display(Name = "街道")]
        public ExcelPropety Street_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.Street);
        [Display(Name = "企业类型")]
        public ExcelPropety CompanyType_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.CompanyType);
        [Display(Name = "企业所属国家")]
        public ExcelPropety ForeignCountry_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.ForeignCountry);
        [Display(Name = "法定代表人")]
        public ExcelPropety LegalRepresentative_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.LegalRepresentative);
        [Display(Name = "企业规模")]
        public ExcelPropety CompanyScale_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.CompanyScale);
        [Display(Name = "行业")]
        public ExcelPropety Industry_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.Industry);
        [Display(Name = "公司人数")]
        public ExcelPropety NoofEmployees_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.NoofEmployees);
        [Display(Name = "主要产品")]
        public ExcelPropety MainProducts_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.MainProducts);
        [Display(Name = "贸易方式")]
        public ExcelPropety TermsofTrade_Excel = ExcelPropety.CreateProperty<EnterpriseBasicInfo>(x => x.TermsofTrade);

	    protected override void InitVM()
        {
        }

    }

    public class EnterpriseBasicInfoImportVM : BaseImportVM<EnterpriseBasicInfoTemplateVM, EnterpriseBasicInfo>
    {

    }

}
