using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.EnterpriseReview;
using Safeway.Model.Common;


namespace Safeway.ViewModel.EnterpriseReviewElementVMs
{
    public partial class EnterpriseReviewElementApiTemplateVM : BaseTemplateVM
    {
        [Display(Name = "要素名称")]
        public ExcelPropety ElementName_Excel = ExcelPropety.CreateProperty<EnterpriseReviewElement>(x => x.ElementName);
        [Display(Name = "级别")]
        public ExcelPropety Level_Excel = ExcelPropety.CreateProperty<EnterpriseReviewElement>(x => x.Level);
        [Display(Name = "排序")]
        public ExcelPropety Order_Excel = ExcelPropety.CreateProperty<EnterpriseReviewElement>(x => x.Order);
        [Display(Name = "总分")]
        public ExcelPropety TotalScore_Excel = ExcelPropety.CreateProperty<EnterpriseReviewElement>(x => x.TotalScore);
        [Display(Name = "上级要素")]
        public ExcelPropety ParentElementId_Excel = ExcelPropety.CreateProperty<EnterpriseReviewElement>(x => x.ParentElementId);

	    protected override void InitVM()
        {
        }

    }

    public class EnterpriseReviewElementApiImportVM : BaseImportVM<EnterpriseReviewElementApiTemplateVM, EnterpriseReviewElement>
    {

    }

}
