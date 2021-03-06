﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Project;
using Safeway.Model.Enterprise;
using Safeway.Model.SmallEntEvaluation;
using Safeway.Model.BasicEntEvaluation;

namespace Safeway.ViewModel.ProjectBasicInfoVMs
{
    public partial class ProjectBasicInfoVM : BaseCRUDVM<ProjectBasicInfo>
    {
        public List<ComboSelectListItem> EnterpriseList { get; set; }
        public List<ComboSelectListItem> StaffList { get; set; }

        [Display(Name = "企业列表")]
        public string[] SelectedEnterpriseIds { get; set; }

        public ProjectBasicInfoVM()
        {
        }

        protected override void InitVM()
        {
            this.EnterpriseList = GetEnterpriseList();
           // this.StaffList = GetStaff();
        }

        public string[] GetSelectedEnterpriseIds(string id)
        {
            var items = DC.Set<SmallEntEvaluationBase>().Where(x => x.ProjectId.Equals(id)).ToList();
            var selectedEnterpriseIds = new List<string>();
            items.ForEach(x =>
            {
                selectedEnterpriseIds.Add(x.EnterpriseId);
            });
            return selectedEnterpriseIds.ToArray();
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
        public List<ComboSelectListItem> GetStaff()
        {
            var staffList = DC.Set<FrameworkUserBase>().OrderBy(x => x.Name).Where(x => x.IsValid==true);
            return staffList.Select(x => new ComboSelectListItem()
            {
                Text = x.Name,
                Value = x.Name.ToString(),
                Disabled = false,
                Selected = false
            }).ToList();
        }

        public async Task AddToSmallEntEvaluationProject()
        {
            // 小微评审
            var items = new List<SmallEntEvaluationBase>();
            Array.ForEach(SelectedEnterpriseIds, x => {
                items.Add(new SmallEntEvaluationBase()
                {
                    ProjectId = Entity.ID.ToString(),
                    EnterpriseId = x,
                    EvaluationStartDate = Entity.ProjectStartDate == null ? DateTime.Now : (DateTime)Entity.ProjectStartDate,
                    EvaluationEndDate = Entity.ProjectEndDate == null ? DateTime.Now : (DateTime)Entity.ProjectEndDate,
                    Status = Model.Common.EvaluationStatus.NotStarted,
                    EvluationEnt = "SafeWay",
                    IsValid = true
                });
            });
            await DC.Set<SmallEntEvaluationBase>().AddRangeAsync(items);
            await DC.SaveChangesAsync();
        }

        public async Task AddToRegularEntReviewProject()
        {
            var items = new List<BasicEntEvaluationBase>();
            Array.ForEach(SelectedEnterpriseIds, x =>
            {
                items.Add(new BasicEntEvaluationBase()
                {
                    ProjectId = Entity.ID.ToString(),
                    EnterpriseId = x,
                    EvluationEnt = "SafeWay",
                    EvaluationStartDate = Entity.ProjectStartDate == null ? DateTime.Now : (DateTime)Entity.ProjectStartDate,
                    EvaluationEndDate = Entity.ProjectEndDate == null ? DateTime.Now : (DateTime)Entity.ProjectEndDate,
                    Status = Model.Common.EvaluationStatus.NotStarted
                });
            });
            await DC.Set<BasicEntEvaluationBase>().AddRangeAsync(items);
            await DC.SaveChangesAsync();
        }

        public async Task UpdateEnterpriseToProject(string id)
        {
            // delete existed small enterprise evaluation items
            var deleteItems = DC.Set<SmallEntEvaluationBase>().Where(x => x.ProjectId.Equals(id)).ToList();
            deleteItems.ForEach(x =>
            {
                DC.DeleteEntity<SmallEntEvaluationBase>(x);
            });
            await DC.SaveChangesAsync();

            // add new enterprise
            var items = new List<SmallEntEvaluationBase>();
            Array.ForEach(SelectedEnterpriseIds, x => {
                items.Add(new SmallEntEvaluationBase()
                {
                    ProjectId = Entity.ID.ToString(),
                    EnterpriseId = x,
                    EvaluationStartDate = Entity.ProjectStartDate == null ? DateTime.Now : (DateTime)Entity.ProjectStartDate,
                    EvaluationEndDate = Entity.ProjectEndDate == null ? DateTime.Now : (DateTime)Entity.ProjectEndDate,
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
