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
    public partial class BasicEntEvaluationBaseSearcher : BaseSearcher
    {
        [Display(Name = "项目ID")]
        public String ProjectId { get; set; }
        [Display(Name = "企业名称")]
        public String EnterpriseId { get; set; }
        [Display(Name = "评审单位")]
        public String EvluationEnt { get; set; }
        [Display(Name = "开始时间")]
        public DateTime? EvaluationStartDate { get; set; }
        [Display(Name = "结束时间")]
        public DateTime? EvaluationEndDate { get; set; }
        [Display(Name = "检查人员")]
        public String Evaluator { get; set; }
        [Display(Name = "状态")]
        public EvaluationStatus? Status { get; set; }

        protected override void InitVM()
        {
        }

    }
}
