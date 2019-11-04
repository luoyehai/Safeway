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
    public class NormalEntEvaluation : BasePoco
    {
        #region GovStandard
        [Display(Name = "一级要素")]
        [StringLength(300)]
        public string LevelOneElement { get; set; }
        [Display(Name = "二级要素")]
        [StringLength(300)]
        public string LevelTwoElement { get; set; }
        [Display(Name = "基本规范要求")]
        [StringLength(500)]
        public string BasicRuleRequirement { get; set; }
        [Display(Name = "企业达标标准")]
        [StringLength(500)]
        public string ComplianceStandard { get; set; }
        [Display(Name = "标准分值")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal StandardScore { get; set; }
        [Display(Name = "评审描述")]
        public string EvaluationDescription { get; set; }
        [Display(Name = "实际分值")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ActualScore { get; set; }
        #endregion
        List<DetailNotmalEntEvaluation> DetailNotmalEntEvaluations { get; set; }
    }
}
