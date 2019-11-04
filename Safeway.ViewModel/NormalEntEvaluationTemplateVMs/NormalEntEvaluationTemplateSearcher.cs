using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Evaluation;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.NormalEntEvaluationTemplateVMs
{
    public partial class NormalEntEvaluationTemplateSearcher : BaseSearcher
    {
        [Display(Name = "评审单位")]
        public String EvluationEnt { get; set; }
        [Display(Name = "评审开始时间")]
        public DateTime? EvaluationStartDate { get; set; }
        [Display(Name = "评审结束时间")]
        public DateTime? EvaluationEndDate { get; set; }
        [Display(Name = "评审组组长")]
        public String EvaluationLeader { get; set; }
        public List<ComboSelectListItem> AllEnterpriseBasicInfos { get; set; }
        public Guid? EnterpriseId { get; set; }

        protected override void InitVM()
        {
            AllEnterpriseBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }
}
