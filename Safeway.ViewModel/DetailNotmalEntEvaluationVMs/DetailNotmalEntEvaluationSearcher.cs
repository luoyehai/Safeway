using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;
using Safeway.Model.Common;


namespace Safeway.ViewModel.DetailNotmalEntEvaluationVMs
{
    public partial class DetailNotmalEntEvaluationSearcher : BaseSearcher
    {
        [Display(Name = "文件/现场")]
        public EvaluationTypeEnum? EvaluateType { get; set; }
        public List<ComboSelectListItem> AllNormalEntEvaluations { get; set; }
        public Guid? NormalEntEvaluationId { get; set; }

        protected override void InitVM()
        {
            AllNormalEntEvaluations = DC.Set<NormalEntEvaluation>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComplianceStandard);
        }

    }
}
