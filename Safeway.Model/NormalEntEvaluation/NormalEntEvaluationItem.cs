﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;
using Safeway.Model.EnterpriseReview;

namespace Safeway.Model.NormalEntEvaluation
{
    public class NormalEntEvaluationItem:BasePoco
    {
        [Display(Name = "一级要素")]
        [StringLength(300)]
        public string LevelOneElement { get; set; }

        [Display(Name = "二级要素")]
        [StringLength(300)]
        public string LevelTwoElement { get; set; }

        [Display(Name = "三级要素")]
        [StringLength(300)]
        public string LevelThreeElement { get; set; }

        [Display(Name = "四级要素ID")]
        public Guid LevelFourID { get; set; }

        [Display(Name = "四级要素")]
        [StringLength(500)]
        public string ComplianceStandard { get; set; }

        [Display(Name = "基本规范要求")]
        [StringLength(500)]
        public string BasicRuleRequirement { get; set; }

        [Display(Name = "标准分值")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal StandardScore { get; set; }

        [Display(Name = "评审描述")]
        public string EvaluationDescription { get; set; }

        [Display(Name = "分配给")]
        [StringLength(200)]
        public string AssignTo { get; set; }

        [Display(Name = "不符合")]
        public bool UnMatched { get; set; }

        [Display(Name = "不涉及")]
        public bool UnInvolved { get; set; }

        [Display(Name = "实际分值")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ActualScore { get; set; }

        [Display(Name = "要素类型")]
        public EvaluationTypeEnum? EvaluationType { get; set; }

        public string NormalEntEvaluationBaseId { get; set; }
    }
}
