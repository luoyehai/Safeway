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
        public Guid EnterpriseId { get; set; }
       // public EnterpriseBasicInfo EnterpriseBasicInfo { get; set; }

        [Display(Name = "评审单位")]
        [StringLength(300)]
        public string EvluationEnt { get; set; }

        [Display(Name = "评审开始时间")]
        public DateTime EvaluationStartDate { get; set; }

        [Display(Name = "评审结束时间")]
        public DateTime EvaluationEndDate { get; set; }

        [Display(Name = "评审组组长")]
        [StringLength(200)]
        public string EvaluationLeader { get; set; }

        [Display(Name = "报告负责人 ")]
        [StringLength(200)]
        public string ReportLeader { get; set; }

        [Display(Name = "评审组成员")]
        [StringLength(500)]
        public string EvaluationTeamMember { get; set; }

        [Display(Name = "状态")]
        public int Status { get; set; }

        [Display(Name = "核查一级要素 <br/>1. 基础管理")]
        [StringLength(200)]
        public string ModuleOne { get; set; }

        [Display(Name = "核查一级要素 <br/>2 、设备设施 <br/>3 、 生产现场")]
        [StringLength(200)]
        public string ModuleTwo { get; set; }

        [Display(Name = "核查一级要素 <br/>4 、 隐患排查与治理 <br/>5 、 职业卫生<br/>6 、 绩效评定与持续改进")]
        [StringLength(200)]
        public string ModuleThree { get; set; }
    }
}
