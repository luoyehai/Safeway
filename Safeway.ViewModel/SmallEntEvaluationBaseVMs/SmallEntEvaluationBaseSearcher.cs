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
    public partial class SmallEntEvaluationBaseSearcher : BaseSearcher
    {
        [Display(Name = "评审单位")]
        public String EvluationEnt { get; set; }
        [Display(Name = "评审开始时间")]
        public DateTime? EvaluationStartDate { get; set; }
        [Display(Name = "评审结束时间")]
        public DateTime? EvaluationEndDate { get; set; }
        [Display(Name = "评审组组长")]
        public String EvaluationLeader { get; set; }
        [Display(Name = "报告负责人 ")]
        public String ReportLeader { get; set; }
        [Display(Name = "状态")]
        public Int32? Status { get; set; }

        protected override void InitVM()
        {
        }

    }
}
