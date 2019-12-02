using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Common;

namespace Safeway.ViewModel.MyTaskVMs
{
    public partial class MyTaskSearcher : BaseSearcher
    {
        [Display(Name = "项目名称")]
        public String ProjectId { get; set; }
        [Display(Name = "企业名称")]
        public String EnterpriseId { get; set; }
        [Display(Name = "开始时间")]
        public DateTime? EvaluationStartDate { get; set; }
        [Display(Name = "结束时间")]
        public DateTime? EvaluationEndDate { get; set; }

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
