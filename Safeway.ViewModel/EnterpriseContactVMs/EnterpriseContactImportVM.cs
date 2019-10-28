using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseContactVMs
{
    public partial class EnterpriseContactTemplateVM : BaseTemplateVM
    {
        [Display(Name = "部门")]
        public ExcelPropety Dept_Excel = ExcelPropety.CreateProperty<EnterpriseContact>(x => x.Dept);
        [Display(Name = "职位")]
        public ExcelPropety Position_Excel = ExcelPropety.CreateProperty<EnterpriseContact>(x => x.Position);
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<EnterpriseContact>(x => x.Name);
        [Display(Name = "座机")]
        public ExcelPropety Tele_Excel = ExcelPropety.CreateProperty<EnterpriseContact>(x => x.Tele);
        public ExcelPropety SchoolName_Excel = ExcelPropety.CreateProperty<EnterpriseContact>(x => x.SchoolName);
        [Display(Name = "手机")]
        public ExcelPropety MobilePhone_Excel = ExcelPropety.CreateProperty<EnterpriseContact>(x => x.MobilePhone);
        [Display(Name = "邮箱")]
        public ExcelPropety Email_Excel = ExcelPropety.CreateProperty<EnterpriseContact>(x => x.Email);

	    protected override void InitVM()
        {
        }

    }

    public class EnterpriseContactImportVM : BaseImportVM<EnterpriseContactTemplateVM, EnterpriseContact>
    {

    }

}
