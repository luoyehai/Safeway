using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.DetailNotmalEntEvaluationVMs
{
    public partial class DetailNotmalEntEvaluationVM : BaseCRUDVM<DetailNotmalEntEvaluation>
    {
        public List<ComboSelectListItem> AllNormalEntEvaluations { get; set; }

        public DetailNotmalEntEvaluationVM()
        {
            SetInclude(x => x.NormalEntEvaluation);
        }

        protected override void InitVM()
        {
            AllNormalEntEvaluations = DC.Set<NormalEntEvaluation>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComplianceStandard);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
