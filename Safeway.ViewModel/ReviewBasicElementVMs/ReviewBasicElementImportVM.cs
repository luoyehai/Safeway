using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewBasicElementVMs
{
    public partial class ReviewBasicElementTemplateVM : BaseTemplateVM
    {
        [Display(Name = "评审模板类型")]
        public ExcelPropety ReviewTempType_Excel = ExcelPropety.CreateProperty<ReviewBasicElement>(x => x.ReviewTempType);
        [Display(Name = "要素名称")]
        public ExcelPropety ElementName_Excel = ExcelPropety.CreateProperty<ReviewBasicElement>(x => x.ElementName);
        [Display(Name = "要素描述")]
        public ExcelPropety ElementDesc_Excel = ExcelPropety.CreateProperty<ReviewBasicElement>(x => x.ElementDesc);
        [Display(Name = "要素序号")]
        public ExcelPropety Order_Excel = ExcelPropety.CreateProperty<ReviewBasicElement>(x => x.Order);
        [Display(Name = "总分")]
        public ExcelPropety TotalScore_Excel = ExcelPropety.CreateProperty<ReviewBasicElement>(x => x.TotalScore);

	    protected override void InitVM()
        {
        }

    }

    public class ReviewBasicElementImportVM : BaseImportVM<ReviewBasicElementTemplateVM, ReviewBasicElement>
    {

    }

}
