using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;

namespace Safeway.Model.SmallEntEvaluation
{
    public class SmallEntEvaluationBase : PersistPoco
    {
        [Display(Name = "企业名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid EnterpriseId { get; set; }

        [Display(Name = "评审单位")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(300)]
        public string EvluationEnt { get; set; }

        [Display(Name = "评审开始时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime EvaluationStartDate { get; set; }

        [Display(Name = "评审结束时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime EvaluationEndDate { get; set; }

        [Display(Name = "评审组组长")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string EvaluationLeader { get; set; }

        [Display(Name = "报告负责人 ")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ReportLeader { get; set; }

        [Display(Name = "评审组成员")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(500)]
        public string EvaluationTeamMember { get; set; }

        [Display(Name = "状态")]
        public int Status { get; set; }

        [Display(Name = "负责人")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ModuleOne { get; set; }

        [Display(Name = "负责人")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ModuleTwo { get; set; }

        [Display(Name = "负责人")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ModuleThree { get; set; }
    }
}
