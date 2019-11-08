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
    public class SmallEntEvaluationUnMatchedItem : BasePoco
    {
        [Display(Name = "四级要素Id")]
        public string SmallEntEvaluationItemId { get; set; }

        [Display(Name = "不符合项描述参考")]
        [StringLength(500)]
        public string UnMatchedItemReferDescription { get; set; }

        [Display(Name = "不符合项描述")]
        [StringLength(500)]
        public string UnMatchedItemDescription { get; set; }

        [Display(Name = "扣分参考")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal DeductionReference { get; set; }

        [Display(Name = "扣分")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Deduction { get; set; }

        public string SmallEntEvaluationBaseId { get; set; }
    }
}
