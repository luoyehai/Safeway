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
                this.MakeAction("SmallEntEvaluationBase","ViewReport", "查看报告", "查看报告",  GridActionParameterTypesEnum.SingleId).SetIsRedirect(true).SetShowDialog(false).SetMax(true).SetShowInRow(true).SetHideOnToolBar(true),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                //this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                //this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.ExportExcel, "导出","")
                //this.MakeAction("SmallEntEvaluationItem","ViewReport","查看报告","查看报告", GridActionParameterTypesEnum.SingleId).SetMax(true)
            };
        }

        protected override IEnumerable<IGridColumn<SmallEntEvaluationBase_View>> InitGridHeader()
        {
            return new List<GridColumn<SmallEntEvaluationBase_View>>{
                this.MakeGridHeader(x => x.EnterpriseId),
                this.MakeGridHeader(x => x.EvaluateStartDateStr),
                this.MakeGridHeader(x => x.EvaluateEndDateStr),
                this.MakeGridHeader(x => x.EvaluationLeader),
                this.MakeGridHeader(x => x.ReportLeader),
                //this.MakeGridHeader(x => x.EvaluationTeamMember),
                this.MakeGridHeader(x => x.Status),
                this.MakeGridHeader(x => x.ModuleOne),
                this.MakeGridHeader(x => x.ModuleTwo),
                this.MakeGridHeader(x => x.ModuleThree),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SmallEntEvaluationBase_View> GetSearchQuery()
        {
            var query = DC.Set<SmallEntEvaluationBase>()
                .CheckContain(Searcher.ProjectId, x => x.ProjectId)
                .CheckContain(Searcher.EnterpriseId, x=>x.EnterpriseId)
                .CheckEqual(Searcher.EvaluationStartDate, x=>x.EvaluationStartDate)
                .CheckEqual(Searcher.EvaluationEndDate, x=>x.EvaluationEndDate)
                .CheckContain(Searcher.EvaluationLeader, x=>x.EvaluationLeader)
                .CheckContain(Searcher.ReportLeader, x=>x.ReportLeader)
                .CheckEqual(Searcher.Status, x=>x.Status)
                .CheckEqual(Searcher.IsValid, x =>x.IsValid.Equals(true))
                .Select(x => new SmallEntEvaluationBase_View
                {
				    ID = x.ID,
                    EnterpriseId = x.EnterpriseId,
                    EvaluationStartDate = x.EvaluationStartDate,
                    EvaluateStartDateStr = x.EvaluationStartDate.ToShortDateFormatString(),
                    EvaluationEndDate = x.EvaluationEndDate,
                    EvaluateEndDateStr = x.EvaluationEndDate.ToShortDateFormatString(),
                    EvaluationLeader = x.EvaluationLeader,
                    ReportLeader = x.ReportLeader,
                    EvaluationTeamMember = x.EvaluationTeamMember,
                    Status = x.Status,
                    ModuleOne = x.ModuleOne,
                    ModuleTwo = x.ModuleTwo,
                    ModuleThree = x.ModuleThree,
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

        public string EnterpriseName { get; set; }
    }
}
