using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;

namespace Safeway.Model.Evaluation
{
    public class NormalEntEvaluationTemplate : BasePoco
    {

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

        [Display(Name = "评审组成员")]
        [StringLength(500)]
        public string EvaluationTeamMember { get; set; }

        [Display(Name = "模块一")]
        [StringLength(200)]
        public string ModuleOne { get; set; }

        [Display(Name = "模块二")]
        [StringLength(200)]
        public string ModuleTwo { get; set; }

        [Display(Name = "模块三")]
        [StringLength(200)]
        public string ModuleThree { get; set; }

        public List<NormalEntEvaluation> NormalEntEvaluations { get; set; }

        public Guid EnterpriseId { get; set; }
        public EnterpriseBasicInfo EnterpriseBasicInfo { get; set; }

    }
}
