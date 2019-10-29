using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriserYearYieldVMs
{
    public partial class EnterpriserYearYieldTemplateVM : BaseTemplateVM
    {
        [Display(Name = "财年")]
        public ExcelPropety FiscalYear_Excel = ExcelPropety.CreateProperty<EnterpriserYearYield>(x => x.FiscalYear);
        [Display(Name = "年收益")]
        public ExcelPropety YearYieldValue_Excel = ExcelPropety.CreateProperty<EnterpriserYearYield>(x => x.YearYieldValue);
        [Display(Name = "创建时间")]
        public ExcelPropety Created_Excel = ExcelPropety.CreateProperty<EnterpriserYearYield>(x => x.Created);
        public ExcelPropety EnterpriseBasicInfo_Excel = ExcelPropety.CreateProperty<EnterpriserYearYield>(x => x.EnterpriseBasicInfoId);

	    protected override void InitVM()
        {
            EnterpriseBasicInfo_Excel.DataType = ColumnDataType.ComboBox;
            EnterpriseBasicInfo_Excel.ListItems = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }

    public class EnterpriserYearYieldImportVM : BaseImportVM<EnterpriserYearYieldTemplateVM, EnterpriserYearYield>
    {

    }

}
