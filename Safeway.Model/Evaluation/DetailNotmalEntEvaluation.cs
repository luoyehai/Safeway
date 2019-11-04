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
   public class DetailNotmalEntEvaluation : BasePoco
    {
        #region ComStandard
        [Display(Name = "文件/现场")]
        public EvaluationTypeEnum? EvaluateType { get; set; }
        [Display(Name = "选择")]
        public EvaluationSelectionEnum? EvaluationSelection { get; set; }
        [Display(Name = "扣分参考")]
        public int DeductionReference { get; set; }
        [Display(Name = "扣分")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Deduction { get; set; }
        [Display(Name = "扣分描述参考")]
        [StringLength(500)]
        public string DeductionDescription { get; set; }

        
        #endregion

        public Guid NormalEntEvaluationId { get; set; }
        public NormalEntEvaluation NormalEntEvaluation { get; set; }
    }
}
