using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;

namespace Safeway.Model.BasicEntEvaluation
{
    public class BasicEntEvaluationBase : PersistPoco
    {
        [Display(Name = "项目ID")]
        public string ProjectId { get; set; }

        [Display(Name = "企业名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string EnterpriseId { get; set; }

        [Display(Name = "评审单位")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(300)]
        public string EvluationEnt { get; set; }

        [Display(Name = "开始时间")]
        public DateTime EvaluationStartDate { get; set; }

        [Display(Name = "结束时间")]
        public DateTime EvaluationEndDate { get; set; }

        [Display(Name = "检查人员")]
        [StringLength(200)]
        public string Evaluator { get; set; }

        [Display(Name = "状态")]
        public EvaluationStatus? Status { get; set; }

        [Display(Name = "检查报告文件")]
        public Guid? ReportFileId { get; set; }
    }
}
