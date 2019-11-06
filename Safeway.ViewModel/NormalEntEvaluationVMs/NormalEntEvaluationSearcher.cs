using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.NormalEntEvaluationVMs
{
    public partial class NormalEntEvaluationSearcher : BaseSearcher
    {
        [Display(Name = "四级要素")]
        public String ComplianceStandard { get; set; }
        [Display(Name = "基本规范要求")]
        public String BasicRuleRequirement { get; set; }
        [Display(Name = "分配给")]
        public String AssignTo { get; set; }

        protected override void InitVM()
        {
        }

    }
}
