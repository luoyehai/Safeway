using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.NormalEntEvaluationVMs
{
    public partial class NormalEntEvaluationTemplateVM : BaseTemplateVM
    {
        [Display(Name = "一级要素")]
        public ExcelPropety LevelOneElement_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.LevelOneElement);
        [Display(Name = "二级要素")]
        public ExcelPropety LevelTwoElement_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.LevelTwoElement);
        [Display(Name = "三级要素")]
        public ExcelPropety LevelThreeElement_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.LevelThreeElement);
        [Display(Name = "四级要素")]
        public ExcelPropety ComplianceStandard_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.ComplianceStandard);
        [Display(Name = "基本规范要求")]
        public ExcelPropety BasicRuleRequirement_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.BasicRuleRequirement);
        [Display(Name = "标准分值")]
        public ExcelPropety StandardScore_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.StandardScore);
        [Display(Name = "评审描述")]
        public ExcelPropety EvaluationDescription_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.EvaluationDescription);
        [Display(Name = "分配给")]
        public ExcelPropety AssignTo_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.AssignTo);
        [Display(Name = "实际分值")]
        public ExcelPropety ActualScore_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.ActualScore);
        public ExcelPropety NormalEntEvaluationTemplate_Excel = ExcelPropety.CreateProperty<NormalEntEvaluation>(x => x.NormalEntEvaTempId);

	    protected override void InitVM()
        {
            NormalEntEvaluationTemplate_Excel.DataType = ColumnDataType.ComboBox;
            NormalEntEvaluationTemplate_Excel.ListItems = DC.Set<NormalEntEvaluationTemplate>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.EvluationEnt);
        }

    }

    public class NormalEntEvaluationImportVM : BaseImportVM<NormalEntEvaluationTemplateVM, NormalEntEvaluation>
    {

    }

}
