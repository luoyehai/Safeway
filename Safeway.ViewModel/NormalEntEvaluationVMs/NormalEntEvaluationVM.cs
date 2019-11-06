using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.NormalEntEvaluationVMs
{
    public partial class NormalEntEvaluationVM : BaseCRUDVM<NormalEntEvaluation>
    {
        public List<ComboSelectListItem> AllNormalEntEvaluationTemplates { get; set; }

        public NormalEntEvaluationVM()
        {
            SetInclude(x => x.NormalEntEvaluationTemplate);
        }

        protected override void InitVM()
        {
            AllNormalEntEvaluationTemplates = DC.Set<NormalEntEvaluationTemplate>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.EvluationEnt);
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
