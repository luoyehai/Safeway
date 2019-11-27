using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.SmallEntEvaluation;
using Safeway.Model.Common;

namespace Safeway.ViewModel.SmallEntEvaluationBaseVMs
{
    public partial class SmallEntEvaluationBaseSearcher : BaseSearcher
    {
        [Display(Name = "项目名称")]
        public String ProjectId { get; set; }
        [Display(Name = "企业名称")]
        public String EnterpriseId { get; set; }
        [Display(Name = "开始时间")]
        public DateTime? EvaluationStartDate { get; set; }
        [Display(Name = "结束时间")]
        public DateTime? EvaluationEndDate { get; set; }
        [Display(Name = "评审组组长")]
        public String EvaluationLeader { get; set; }
        [Display(Name = "报告负责人 ")]
        public String ReportLeader { get; set; }
        [Display(Name = "状态")]
        public EvaluationStatus? Status { get; set; }

        [Display(Name = "属地")]
        public string Street { get; set; }

        [Display(Name = "行业")]
        public string Industry { get; set; }

        protected override void InitVM()
        {
        }

    }
}
