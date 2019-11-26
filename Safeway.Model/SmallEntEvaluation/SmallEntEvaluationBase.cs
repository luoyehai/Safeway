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
        //[Required(ErrorMessage = "{0}是必填项")]
        public DateTime EvaluationStartDate { get; set; }

        [Display(Name = "结束时间")]
        //[Required(ErrorMessage = "{0}是必填项")]
        public DateTime EvaluationEndDate { get; set; }

        [Display(Name = "评审组组长")]
        //[Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string EvaluationLeader { get; set; }

        [Display(Name = "报告负责人 ")]
        //[Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ReportLeader { get; set; }

        [Display(Name = "评审组成员")]
        //[Required(ErrorMessage = "{0}是必填项")]
        [StringLength(500)]
        public string EvaluationTeamMember { get; set; }

        [Display(Name = "状态")]
        public EvaluationStatus? Status { get; set; }

        [Display(Name = "负责人")]
        //[Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ModuleOne { get; set; }

        [Display(Name = "负责人")]
        //[Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ModuleTwo { get; set; }

        [Display(Name = "负责人")]
        //[Required(ErrorMessage = "{0}是必填项")]
        [StringLength(200)]
        public string ModuleThree { get; set; }

        [Display(Name = "得分")]
        public string Score { get; set; }

        [Display(Name = "评审报告文件")]
        public Guid? ReportFileId { get; set; }
    }
}
