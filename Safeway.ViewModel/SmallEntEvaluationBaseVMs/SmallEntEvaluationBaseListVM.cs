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
    public partial class SmallEntEvaluationBaseListVM : BasePagedListVM<SmallEntEvaluationBase_View, SmallEntEvaluationBaseSearcher>
    {

        public List<ComboSelectListItem> AllEnterprise { get; set; }

        public List<ComboSelectListItem> AllProject { get; set; }

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeAction("SmallEntEvaluationBase", "ViewReport", "评审", "评审",  GridActionParameterTypesEnum.SingleId).SetIsRedirect(true).SetShowDialog(false).SetMax(true).SetShowInRow(true).SetHideOnToolBar(true),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.ExportExcel, "导出","")
                //this.MakeAction("SmallEntEvaluationItem","ViewReport","查看报告","查看报告", GridActionParameterTypesEnum.SingleId).SetMax(true)
            };
        }

        protected override IEnumerable<IGridColumn<SmallEntEvaluationBase_View>> InitGridHeader()
        {
            return new List<GridColumn<SmallEntEvaluationBase_View>>{
                this.MakeGridHeader(x => x.EnterpriseName, width: 150),
                this.MakeGridHeader(x => x.Street),
                this.MakeGridHeader(x => x.Industry),
                this.MakeGridHeader(x => x.Scale),
                this.MakeGridHeader(x => x.EvaluateStartDateStr),
                this.MakeGridHeader(x => x.EvaluateEndDateStr),
                this.MakeGridHeader(x => x.EvaluationLeader),
                this.MakeGridHeader(x => x.ReportLeader),
                this.MakeGridHeader(x => x.Status).SetFormat(ReportStatusFormat),
                this.MakeGridHeader(x => x.Score, width: 120),
                this.MakeGridHeader(x => x.EvaluationResult).SetFormat(EvaluationResultFormat),
                this.MakeGridHeader(x => x.Progress).SetFormat(ProgressFormat),
                //this.MakeGridHeader(x => x.ModuleOne),
                //this.MakeGridHeader(x => x.ModuleTwo),
                //this.MakeGridHeader(x => x.ModuleThree),
                this.MakeGridHeader(x => x.ReportFileId).SetFormat(ReportFileIdFormat),
                this.MakeGridHeaderAction(width: 220)
            };
        }

        public List<ColumnFormatInfo> EvaluationResultFormat(SmallEntEvaluationBase_View entity, object val)
        {
            var result = string.Empty;
            var bgColor = "green";
            // todo:小微评审合格标准：小型75分，微型60分
            if (entity.Status == EvaluationStatus.Completed || entity.Status == EvaluationStatus.ReportCompleted)
            {
                decimal numberScore = 0;
                decimal.TryParse(entity.Score, out numberScore);
                if ((entity.Scale == "小型" && numberScore >= 75) || (entity.Scale == "微型" && numberScore >= 60))
                {
                    result = "合格";
                }
                else
                {
                    result = "不合格";
                    bgColor = "red";
                }
            }
            var format = new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeHtml(html: $"<span class='layui-badge layui-bg-{bgColor}'>{ result }</span>")
            };
            if (string.IsNullOrEmpty(result))
            {
                format = new List<ColumnFormatInfo>
                {
                    ColumnFormatInfo.MakeHtml(html: "<span></span>")
                };
            }
            return format;
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
                .Join(DC.Set<EnterpriseBasicInfo>(), e => e.EnterpriseId, ent => ent.ID.ToString(), (se, eb) => new { se = se, eb = eb})
                .CheckContain(Searcher.ProjectId, x => x.se.ProjectId)
                .CheckContain(Searcher.EnterpriseId, x=>x.se.EnterpriseId)
                .CheckEqual(Searcher.EvaluationStartDate, x=>x.se.EvaluationStartDate)
                .CheckEqual(Searcher.EvaluationEndDate, x=>x.se.EvaluationEndDate)
                .CheckContain(Searcher.EvaluationLeader, x=>x.se.EvaluationLeader)
                .CheckContain(Searcher.ReportLeader, x=>x.se.ReportLeader)
                .CheckContain(Searcher.Street, x => x.eb.Street)
                .CheckContain(Searcher.Industry, x => x.eb.Industry)
                .CheckEqual(Searcher.Status, x=>x.se.Status)
                .CheckEqual(Searcher.IsValid, x =>x.se.IsValid.Equals(true))
                .Select(x => new SmallEntEvaluationBase_View
                {
				    ID = x.se.ID,
                    EnterpriseId = x.se.EnterpriseId,
                    EnterpriseName = x.eb.ComapanyName,
                    Street = x.eb.Street,
                    Industry = x.eb.Industry,
                    Scale = x.eb.CompanyScale,
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
                    EvaluationResult = x.se.Score,
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

        [Display(Name = "属地")]
        public string Street { get; set; }

        [Display(Name = "行业")]
        public string Industry { get; set; }

        public string EvaluationProgress { get; set; }

        [Display(Name = "评审结果")]
        public string EvaluationResult { get; set; }

        [Display(Name = "规模")]
        public string Scale { get; set; }
    }
}
