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
using Safeway.Model.Common;

namespace Safeway.ViewModel.SmallEntEvaluationBaseVMs
{
    public partial class SmallEntEvaluationBaseListViewVM : BasePagedListVM<SmallEntEvaluationBase_View, SmallEntEvaluationBaseSearcher>
    {

        public List<ComboSelectListItem> AllEnterprise { get; set; }

        public List<ComboSelectListItem> AllProject { get; set; }

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeAction("SmallEntEvaluationBase", "ViewReport", "查看报告", "查看报告",  GridActionParameterTypesEnum.SingleId).SetIsRedirect(true).SetShowDialog(false).SetMax(true).SetShowInRow(true).SetHideOnToolBar(true),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.ExportExcel, "导出","")
            };
        }

        protected override IEnumerable<IGridColumn<SmallEntEvaluationBase_View>> InitGridHeader()
        {
            return new List<GridColumn<SmallEntEvaluationBase_View>>{
                this.MakeGridHeader(x => x.EnterpriseName, width: 180),
                this.MakeGridHeader(x => x.Street, width: 150),
                this.MakeGridHeader(x => x.Industry, width: 80),
                this.MakeGridHeader(x => x.EvaluateStartDateStr, width: 120),
                this.MakeGridHeader(x => x.EvaluateEndDateStr, width: 120),
                this.MakeGridHeader(x => x.EvaluationLeader, width: 100),
                this.MakeGridHeader(x => x.ReportLeader, width: 100),
                this.MakeGridHeader(x => x.Status, width: 120).SetFormat(ReportStatusFormat),
                this.MakeGridHeader(x => x.Score, width: 80),
                //this.MakeGridHeader(x => x.EvaluationResult, width: 80),
                this.MakeGridHeader(x => x.Progress, width: 100).SetFormat(ProgressFormat),
                this.MakeGridHeader(x => x.ModuleOne, width: 80),
                this.MakeGridHeader(x => x.ModuleTwo, width: 80),
                this.MakeGridHeader(x => x.ModuleThree, width: 80),
                this.MakeGridHeader(x => x.ReportFileId, width: 120).SetFormat(ReportFileIdFormat),
                this.MakeGridHeaderAction()
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
            decimal progress = 0;
            decimal.TryParse(entity.Progress, out progress);
            var bgColor = "blue";
            if (progress < 60)
                bgColor = "red";
            if (progress > 99)
                bgColor = "green";
            var showPercent = progress == 0 ? "" : "lay-showPercent='yes'";
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeHtml(html: $"<div class='layui-progress' style='margin-top:10px' {showPercent}><div class='layui-progress-bar layui-bg-{bgColor}' lay-percent='{entity.Progress}%'></div></div>")
            };
        }

        public override IOrderedQueryable<SmallEntEvaluationBase_View> GetSearchQuery()
        {
            var query = DC.Set<SmallEntEvaluationBase>()
                .Join(DC.Set<EnterpriseBasicInfo>(), e => e.EnterpriseId, ent => ent.ID.ToString(), (se, eb) => new { se = se, eb = eb })
                .CheckContain(Searcher.ProjectId, x => x.se.ProjectId)
                .CheckContain(Searcher.EnterpriseId, x => x.se.EnterpriseId)
                .CheckEqual(Searcher.EvaluationStartDate, x => x.se.EvaluationStartDate)
                .CheckEqual(Searcher.EvaluationEndDate, x => x.se.EvaluationEndDate)
                .CheckContain(Searcher.EvaluationLeader, x => x.se.EvaluationLeader)
                .CheckContain(Searcher.ReportLeader, x => x.se.ReportLeader)
                .CheckContain(Searcher.Street, x => x.eb.Street)
                .CheckContain(Searcher.Industry, x => x.eb.Industry)
                .CheckEqual(Searcher.Status, x => x.se.Status)
                .CheckEqual(Searcher.IsValid, x => x.se.IsValid.Equals(true))
                .Select(x => new SmallEntEvaluationBase_View
                {
                    ID = x.se.ID,
                    EnterpriseId = x.se.EnterpriseId,
                    EnterpriseName = x.eb.ComapanyName,
                    Street = x.eb.Street,
                    Industry = x.eb.Industry,
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
                    EvaluationResult = x.eb.CompanyScale,
                    Progress = x.se.Progress,
                    ModuleOne = x.se.ModuleOne,
                    ModuleTwo = x.se.ModuleTwo,
                    ModuleThree = x.se.ModuleThree,
                })
                .OrderBy(x => x.ID);
            return query;
        }

        public string GetEvaluationResult(string scale, EvaluationStatus? status, string score)
        {
            // todo:小微评审合格标准：小型75分，微型60分
            if (status == EvaluationStatus.Completed || status == EvaluationStatus.ReportCompleted)
            {
                decimal numberScore = 0;
                decimal.TryParse(score, out numberScore);
                if ((scale == "小型" && numberScore >= 75) || (score == "微型" && numberScore >= 60))
                    return "合格";
                return "不合格";
            }
            return string.Empty;
        }
    }
}
