using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.BasicEntEvaluation;
using Safeway.Model.Common;


namespace Safeway.ViewModel.BasicEntEvaluationBaseVMs
{
    public partial class BasicEntEvaluationBaseTemplateVM : BaseTemplateVM
    {
        [Display(Name = "项目ID")]
        public ExcelPropety ProjectId_Excel = ExcelPropety.CreateProperty<BasicEntEvaluationBase>(x => x.ProjectId);
        [Display(Name = "企业名称")]
        public ExcelPropety EnterpriseId_Excel = ExcelPropety.CreateProperty<BasicEntEvaluationBase>(x => x.EnterpriseId);
        [Display(Name = "评审单位")]
        public ExcelPropety EvluationEnt_Excel = ExcelPropety.CreateProperty<BasicEntEvaluationBase>(x => x.EvluationEnt);
        [Display(Name = "开始时间")]
        public ExcelPropety EvaluationStartDate_Excel = ExcelPropety.CreateProperty<BasicEntEvaluationBase>(x => x.EvaluationStartDate);
        [Display(Name = "结束时间")]
        public ExcelPropety EvaluationEndDate_Excel = ExcelPropety.CreateProperty<BasicEntEvaluationBase>(x => x.EvaluationEndDate);
        [Display(Name = "检查人员")]
        public ExcelPropety Evaluator_Excel = ExcelPropety.CreateProperty<BasicEntEvaluationBase>(x => x.Evaluator);
        [Display(Name = "状态")]
        public ExcelPropety Status_Excel = ExcelPropety.CreateProperty<BasicEntEvaluationBase>(x => x.Status);

	    protected override void InitVM()
        {
        }

    }

    public class BasicEntEvaluationBaseImportVM : BaseImportVM<BasicEntEvaluationBaseTemplateVM, BasicEntEvaluationBase>
    {

    }

}
