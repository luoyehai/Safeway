using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseFinanceInfoVMs
{
    public partial class EnterpriseFinanceInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "统一社会信用代码")]
        public ExcelPropety UnifiedSocialCreditCode_Excel = ExcelPropety.CreateProperty<EnterpriseFinanceInfo>(x => x.UnifiedSocialCreditCode);
        [Display(Name = "单位地址")]
        public ExcelPropety Company_Address_Excel = ExcelPropety.CreateProperty<EnterpriseFinanceInfo>(x => x.Company_Address);
        [Display(Name = "电话号码")]
        public ExcelPropety Tele_Number_Excel = ExcelPropety.CreateProperty<EnterpriseFinanceInfo>(x => x.Tele_Number);
        [Display(Name = "开户银行")]
        public ExcelPropety Bank_Excel = ExcelPropety.CreateProperty<EnterpriseFinanceInfo>(x => x.Bank);
        [Display(Name = "银行账户")]
        public ExcelPropety Account_Excel = ExcelPropety.CreateProperty<EnterpriseFinanceInfo>(x => x.Account);
        [Display(Name = "发票接收人")]
        public ExcelPropety CustomerReceiptReceiver_Excel = ExcelPropety.CreateProperty<EnterpriseFinanceInfo>(x => x.CustomerReceiptReceiver);
        public ExcelPropety BasicInfo_Excel = ExcelPropety.CreateProperty<EnterpriseFinanceInfo>(x => x.EnterpriseBasicId);

	    protected override void InitVM()
        {
            BasicInfo_Excel.DataType = ColumnDataType.ComboBox;
            BasicInfo_Excel.ListItems = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }

    public class EnterpriseFinanceInfoImportVM : BaseImportVM<EnterpriseFinanceInfoTemplateVM, EnterpriseFinanceInfo>
    {

    }

}
