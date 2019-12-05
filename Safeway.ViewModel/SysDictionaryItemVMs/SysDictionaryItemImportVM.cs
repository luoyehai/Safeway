using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryItemVMs
{
    public partial class SysDictionaryItemTemplateVM : BaseTemplateVM
    {
        [Display(Name = "字典代码")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<SysDictionaryItem>(x => x.Code);
        [Display(Name = "字典项名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<SysDictionaryItem>(x => x.Name);
        [Display(Name = "字典项值")]
        public ExcelPropety Value_Excel = ExcelPropety.CreateProperty<SysDictionaryItem>(x => x.Value);
        [Display(Name = "备注")]
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<SysDictionaryItem>(x => x.Remark);
        [Display(Name = "顺序")]
        public ExcelPropety Sort_Excel = ExcelPropety.CreateProperty<SysDictionaryItem>(x => x.Sort);

	    protected override void InitVM()
        {
        }

    }

    public class SysDictionaryItemImportVM : BaseImportVM<SysDictionaryItemTemplateVM, SysDictionaryItem>
    {

    }

}
