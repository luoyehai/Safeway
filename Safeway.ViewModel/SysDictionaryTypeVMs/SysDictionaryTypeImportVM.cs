using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryTypeVMs
{
    public partial class SysDictionaryTypeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "字典编码")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<SysDictionaryType>(x => x.Code);
        [Display(Name = "字典名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<SysDictionaryType>(x => x.Name);
        [Display(Name = "父字典编码")]
        public ExcelPropety ParentCode_Excel = ExcelPropety.CreateProperty<SysDictionaryType>(x => x.ParentCode);

	    protected override void InitVM()
        {
        }

    }

    public class SysDictionaryTypeImportVM : BaseImportVM<SysDictionaryTypeTemplateVM, SysDictionaryType>
    {

    }

}
