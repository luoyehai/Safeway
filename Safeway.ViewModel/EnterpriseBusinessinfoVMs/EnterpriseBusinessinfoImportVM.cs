using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;


namespace Safeway.ViewModel.EnterpriseBusinessinfoVMs
{
    public partial class EnterpriseBusinessinfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "安全服务类型")]
        public ExcelPropety SafetyServiceType_Excel = ExcelPropety.CreateProperty<EnterpriseBusinessinfo>(x => x.SafetyServiceType);
        [Display(Name = "其他")]
        public ExcelPropety OtherSafetyServiceType_Excel = ExcelPropety.CreateProperty<EnterpriseBusinessinfo>(x => x.OtherSafetyServiceType);
        [Display(Name = "证书等级")]
        public ExcelPropety CertificateLevel_Excel = ExcelPropety.CreateProperty<EnterpriseBusinessinfo>(x => x.CertificateLevel);
        [Display(Name = "到期时间")]
        public ExcelPropety ExpireDate_Excel = ExcelPropety.CreateProperty<EnterpriseBusinessinfo>(x => x.ExpireDate);
        [Display(Name = "原服务公司")]
        public ExcelPropety OriginalServiceCom_Excel = ExcelPropety.CreateProperty<EnterpriseBusinessinfo>(x => x.OriginalServiceCom);
        [Display(Name = "描述")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<EnterpriseBusinessinfo>(x => x.Description);

	    protected override void InitVM()
        {
        }

    }

    public class EnterpriseBusinessinfoImportVM : BaseImportVM<EnterpriseBusinessinfoTemplateVM, EnterpriseBusinessinfo>
    {

    }

}
