using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.EnterpriseReview;


namespace Safeway.ViewModel.EntRegularCheckElementVMs
{
    public partial class EntRegularCheckElementTemplateVM : BaseTemplateVM
    {
        [Display(Name = "要素名称")]
        public ExcelPropety ElementName_Excel = ExcelPropety.CreateProperty<EntRegularCheckElement>(x => x.ElementName);
        [Display(Name = "检查内容")]
        public ExcelPropety CheckContent_Excel = ExcelPropety.CreateProperty<EntRegularCheckElement>(x => x.CheckContent);
        [Display(Name = "检查重点")]
        public ExcelPropety CheckPoint_Excel = ExcelPropety.CreateProperty<EntRegularCheckElement>(x => x.CheckPoint);
        [Display(Name = "法规依据")]
        public ExcelPropety Regulations_Excel = ExcelPropety.CreateProperty<EntRegularCheckElement>(x => x.Regulations);
        [Display(Name = "排序")]
        public ExcelPropety Order_Excel = ExcelPropety.CreateProperty<EntRegularCheckElement>(x => x.Order);

	    protected override void InitVM()
        {
        }

    }

    public class EntRegularCheckElementImportVM : BaseImportVM<EntRegularCheckElementTemplateVM, EntRegularCheckElement>
    {

    }

}
