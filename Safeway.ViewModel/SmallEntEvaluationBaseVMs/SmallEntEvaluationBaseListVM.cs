using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.SmallEntEvaluation;
using Safeway.ViewModel.CommonClass;
using Safeway.Model.Enterprise;

namespace Safeway.ViewModel.SmallEntEvaluationBaseVMs
{
    public partial class SmallEntEvaluationBaseListVM : BasePagedListVM<SmallEntEvaluationBase_View, SmallEntEvaluationBaseSearcher>
    {

        public List<ComboSelectListItem> AllEnterprise { get; set; }

        public List<ComboSelectListItem> AllProject { get; set; }

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeAction("SmallEntEvaluationBase", "ViewReport", "评审报告", "评审报告",  GridActionParameterTypesEnum.SingleId).SetIsRedirect(true).SetShowDialog(false).SetMax(true).SetShowInRow(true).SetHideOnToolBar(true),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.ExportExcel, "导出","")
                //this.MakeAction("SmallEntEvaluationItem","ViewReport","查看报告","查看报告", GridActionParameterTypesEnum.SingleId).SetMax(true)
            };
        }

        protected override IEnumerable<IGridColumn<SmallEntEvaluationBase_View>> InitGridHeader()
        {
            return new List<GridColumn<SmallEntEvaluationBase_View>>{
                this.MakeGridHeader(x => x.EnterpriseName),
                this.MakeGridHeader(x => x.EvaluateStartDateStr),
                this.MakeGridHeader(x => x.EvaluateEndDateStr),
                this.MakeGridHeader(x => x.EvaluationLeader),
                this.MakeGridHeader(x => x.ReportLeader),
                this.MakeGridHeader(x => x.Status).SetFormat(ReportStatusFormat),
                this.MakeGridHeader(x => x.Score),
                this.MakeGridHeader(x => x.Progress).SetFormat(ProgressFormat),
                this.MakeGridHeader(x => x.ModuleOne),
                this.MakeGridHeader(x => x.ModuleTwo),
                this.MakeGridHeader(x => x.ModuleThree),
                this.MakeGridHeader(x => x.ReportFileId).SetFormat(ReportFileIdFormat),
                this.MakeGridHeaderAction(width: 300)
            };
        }

        private List<ColumnFormatInfo> ReportFileIdFormat(SmallEntEvaluationBase_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.ReportFileId)
            };
        }

        private List<ColumnFormatInfo> ReportStatusFormat(SmallEntEvaluationBase_View entity, object val)
        {
            var bgColor = "blue";
            if (entity.Status == Model.Common.EvaluationStatus.NotStarted)
                bgColor = "orange";
            if (entity.Status == Model.Common.EvaluationStatus.ReportCompleted)
                bgColor = "green";
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeHtml(html: $"<span class='layui-badge layui-bg-{bgColor}'>{ entity.Status.GetDescription() }</span>")
            };
        }

        private List<ColumnFormatInfo> ProgressFormat(SmallEntEvaluationBase_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeHtml($"<div class='layui-progress'><div class='layui-progress-bar' lay-percent='70%'></div></div>")
            };
        }

        public override IOrderedQueryable<SmallEntEvaluationBase_View> GetSearchQuery()
        {
            var query = DC.Set<SmallEntEvaluationBase>()
                .Join(DC.Set<EnterpriseBasicInfo>(), e => e.EnterpriseId, ent => ent.ID.ToString(), (se, eb) => new { se = se, eb = eb})
                .CheckContain(Searcher.ProjectId, x => x.se.ProjectId)
                .CheckContain(Searcher.EnterpriseId, x=>x.se.EnterpriseId)
                .CheckEqual(Searcher.EvaluationStartDate, x=>x.se.EvaluationStartDate)
                .CheckEqual(Searcher.EvaluationEndDate, x=>x.se.EvaluationEndDate)
                .CheckContain(Searcher.EvaluationLeader, x=>x.se.EvaluationLeader)
                .CheckContain(Searcher.ReportLeader, x=>x.se.ReportLeader)
                .CheckEqual(Searcher.Status, x=>x.se.Status)
                .CheckEqual(Searcher.IsValid, x =>x.se.IsValid.Equals(true))
                .Select(x => new SmallEntEvaluationBase_View
                {
				    ID = x.se.ID,
                    EnterpriseId = x.se.EnterpriseId,
                    EnterpriseName = x.eb.ComapanyName,
                    EvaluationStartDate = x.se.EvaluationStartDate,
                    EvaluateStartDateStr = x.se.EvaluationStartDate.ToShortDateFormatString(),
                    EvaluationEndDate = x.se.EvaluationEndDate,
                    EvaluateEndDateStr = x.se.EvaluationEndDate.ToShortDateFormatString(),
                    EvaluationLeader = x.se.EvaluationLeader,
                    ReportLeader = x.se.ReportLeader,
                    ReportFileId = x.se.ReportFileId,
                    EvaluationTeamMember = x.se.EvaluationTeamMember,
                    Status = x.se.Status,
                    Score = x.se.Score,
                    Progress = x.se.Progress,
                    ModuleOne = x.se.ModuleOne,
                    ModuleTwo = x.se.ModuleTwo,
                    ModuleThree = x.se.ModuleThree,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SmallEntEvaluationBase_View : SmallEntEvaluationBase{

        [Display(Name = "开始时间")]
        public string EvaluateStartDateStr { get; set; }

        [Display(Name = "结束时间")]
        public string EvaluateEndDateStr { get; set; }

        public string ProjectName { get; set; }

        [Display(Name = "企业名称")]
        public string EnterpriseName { get; set; }

        public string EvalationProgress { get; set; }
    }
}
