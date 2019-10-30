using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewLevel2ElementVMs
{
    public partial class ReviewLevel2ElementTemplateVM : BaseTemplateVM
    {
        [Display(Name = "要素名称")]
        public ExcelPropety ElementName_Excel = ExcelPropety.CreateProperty<ReviewLevel2Element>(x => x.ElementName);
        [Display(Name = "基本规范要求")]
        public ExcelPropety ElementStandard_Excel = ExcelPropety.CreateProperty<ReviewLevel2Element>(x => x.ElementStandard);
        [Display(Name = "要素序号")]
        public ExcelPropety Order_Excel = ExcelPropety.CreateProperty<ReviewLevel2Element>(x => x.Order);
        [Display(Name = "总分")]
        public ExcelPropety TotalScore_Excel = ExcelPropety.CreateProperty<ReviewLevel2Element>(x => x.TotalScore);
        public ExcelPropety ReviewBasicElement_Excel = ExcelPropety.CreateProperty<ReviewLevel2Element>(x => x.BasicElementId);

	    protected override void InitVM()
        {
            ReviewBasicElement_Excel.DataType = ColumnDataType.ComboBox;
            ReviewBasicElement_Excel.ListItems = DC.Set<ReviewBasicElement>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ElementName);
        }

    }

    public class ReviewLevel2ElementImportVM : BaseImportVM<ReviewLevel2ElementTemplateVM, ReviewLevel2Element>
    {

    }

}
