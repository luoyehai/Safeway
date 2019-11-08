using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.SmallEntEvaluation;


namespace Safeway.ViewModel.SmallEntEvaluationBaseVMs
{
    public partial class SmallEntEvaluationBaseTemplateVM : BaseTemplateVM
    {
        [Display(Name = "评审单位")]
        public ExcelPropety EvluationEnt_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.EvluationEnt);
        [Display(Name = "评审开始时间")]
        public ExcelPropety EvaluationStartDate_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.EvaluationStartDate);
        [Display(Name = "评审结束时间")]
        public ExcelPropety EvaluationEndDate_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.EvaluationEndDate);
        [Display(Name = "评审组组长")]
        public ExcelPropety EvaluationLeader_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.EvaluationLeader);
        [Display(Name = "报告负责人 ")]
        public ExcelPropety ReportLeader_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.ReportLeader);
        [Display(Name = "评审组成员")]
        public ExcelPropety EvaluationTeamMember_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.EvaluationTeamMember);
        [Display(Name = "状态")]
        public ExcelPropety Status_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.Status);
        [Display(Name = "核查一级要素 1. 基础管理")]
        public ExcelPropety ModuleOne_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.ModuleOne);
        [Display(Name = "核查一级要素 2 、设备设施 3 、 生产现场")]
        public ExcelPropety ModuleTwo_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.ModuleTwo);
        [Display(Name = "核查负责评审一级要素 4 、 隐患排查与治理 5 、 职业卫生6 、 绩效评定与持续改进")]
        public ExcelPropety ModuleThree_Excel = ExcelPropety.CreateProperty<SmallEntEvaluationBase>(x => x.ModuleThree);

	    protected override void InitVM()
        {
        }

    }

    public class SmallEntEvaluationBaseImportVM : BaseImportVM<SmallEntEvaluationBaseTemplateVM, SmallEntEvaluationBase>
    {

    }

}
