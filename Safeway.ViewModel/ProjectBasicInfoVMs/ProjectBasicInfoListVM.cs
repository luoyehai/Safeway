using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Project;
using Safeway.Model.Common;
using Safeway.Model.Enterprise;
using Safeway.ViewModel.CommonClass;

namespace Safeway.ViewModel.ProjectBasicInfoVMs
{
    public partial class ProjectBasicInfoListVM : BasePagedListVM<ProjectBasicInfo_View, ProjectBasicInfoSearcher>
    {
        protected override void InitListVM()
        {
            base.InitListVM();
        }

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.Create, "新建","").SetMax(true),
                this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.Edit, "修改","").SetMax(true),
                this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                //this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                //this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                //this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                //this.MakeStandardAction("ProjectBasicInfo", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<ProjectBasicInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<ProjectBasicInfo_View>>{
                this.MakeGridHeader(x => x.ProjectName).SetFormat(ProjectNameFormat),
                //this.MakeGridHeader(x => x.ProjectDescription),
                this.MakeGridHeader(x => x.ProjectType),
                this.MakeGridHeader(x => x.ProjectOnwer),
                //this.MakeGridHeader(x => x.ProjectMember),
                this.MakeGridHeader(x => x.ProjectStartDateStr),
                this.MakeGridHeader(x => x.ProjectEndDateStr),
                this.MakeGridHeader(x => x.ProjectStatus),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        private List<ColumnFormatInfo> ProjectNameFormat(ProjectBasicInfo_View entity, object val)
        {
            var url = $"SmallEntEvaluationBase/ProjectDetail/{entity.ID}";
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDialogButton(ButtonTypesEnum.Button , url , entity.ProjectName, width: 1920, height: 900, maxed:true)
            };
        }

        public override IOrderedQueryable<ProjectBasicInfo_View> GetSearchQuery()
        {
            var query = DC.Set<ProjectBasicInfo>()
                .CheckContain(Searcher.ProjectName, x=>x.ProjectName)
                .CheckContain(Searcher.ProjectDescription, x=>x.ProjectDescription)
                .CheckEqual(Searcher.ProjectType, x=>x.ProjectType)
                .CheckContain(Searcher.ProjectOnwer, x=>x.ProjectOnwer)
                .CheckEqual(Searcher.ProjectMember, x=>x.ProjectMember)
                .CheckEqual(Searcher.ProjectStartDate, x=>x.ProjectStartDate)
                .CheckEqual(Searcher.ProjectEndDate, x=>x.ProjectEndDate)
                .CheckEqual(Searcher.ProjectStatus, x=>x.ProjectStatus)
                .Select(x => new ProjectBasicInfo_View
                {
				    ID = x.ID,
                    ProjectName = x.ProjectName,
                    ProjectDescription = x.ProjectDescription,
                    ProjectType = x.ProjectType,
                    ProjectOnwer = x.ProjectOnwer,
                    ProjectMember = x.ProjectMember,
                    ProjectStartDateStr = ((DateTime)x.ProjectStartDate).ToShortDateFormatString(),
                    ProjectEndDateStr = ((DateTime)x.ProjectEndDate).ToShortDateFormatString(),
                    ProjectStatus = x.ProjectStatus,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ProjectBasicInfo_View : ProjectBasicInfo{
        [Display(Name = "开始时间")]
        public string ProjectStartDateStr { get; set; }

        [Display(Name = "结束时间")]
        public string ProjectEndDateStr { get; set; }
    }
}
