using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Safeway.Model.BasicEntEvaluation
{
    public class BasicEntEvaluationItem : BasePoco
    {
        public string CheckElementName { get; set; }

        public string CheckContent { get; set; }

        public string CheckPoint { get; set; }

        [Display(Name = "不涉及")]
        public bool UnInvolved { get; set; }

        public string Regulation { get; set; }

        public string RetificationComments { get; set; }

        public string CurrentState { get; set; }
    }
}
