using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Project;
using Safeway.Model.Enterprise;
using Safeway.Model.SmallEntEvaluation;

namespace Safeway.ViewModel.ProjectBasicInfoVMs
{
    public partial class ProjectBasicInfoVM : BaseCRUDVM<ProjectBasicInfo>
    {

        [Display(Name = "企业列表")]
        public List<ComboSelectListItem> EnterpriseList { get; set; }

        public string[] SelectedEnterpriseIds { get; set; }

        public ProjectBasicInfoVM()
        {
        }

        protected override void InitVM()
        {
            this.EnterpriseList = GetEnterpriseList();
        }

        public List<ComboSelectListItem> GetEnterpriseList()
        {
            var items = DC.Set<EnterpriseBasicInfo>().OrderBy(x => x.ComapanyName);
            return items.Select(x => new ComboSelectListItem()
            {
                Text = x.ComapanyName,
                Value = x.ID.ToString(),
                Disabled = false,
                Selected = false
            }).ToList();
        }

        public async Task AddEnterpriseToProject()
        {
            var items = new List<SmallEntEvaluationBase>();
            Array.ForEach(SelectedEnterpriseIds, x => {
                items.Add(new SmallEntEvaluationBase()
                {
                    ProjectId = Entity.ID.ToString(),
                    EnterpriseId = x,
                    Status = Model.Common.EvaluationStatus.NotStarted,
                    EvluationEnt = "SafeWay",
                    IsValid = true
                });
            });
            await DC.Set<SmallEntEvaluationBase>().AddRangeAsync(items);
            await DC.SaveChangesAsync();
        }

        public override void DoAdd()
        {           
            base.DoAdd();
            // add small evaluation items
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
