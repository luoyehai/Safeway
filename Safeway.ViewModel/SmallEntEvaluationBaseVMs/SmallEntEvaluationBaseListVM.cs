using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.SmallEntEvaluation;


namespace Safeway.ViewModel.SmallEntEvaluationBaseVMs
{
    public partial class SmallEntEvaluationBaseListVM : BasePagedListVM<SmallEntEvaluationBase_View, SmallEntEvaluationBaseSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("SmallEntEvaluationBase", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<SmallEntEvaluationBase_View>> InitGridHeader()
        {
            return new List<GridColumn<SmallEntEvaluationBase_View>>{
                this.MakeGridHeader(x => x.EvluationEnt),
                this.MakeGridHeader(x => x.EvaluationStartDate),
                this.MakeGridHeader(x => x.EvaluationEndDate),
                this.MakeGridHeader(x => x.EvaluationLeader),
                this.MakeGridHeader(x => x.ReportLeader),
                this.MakeGridHeader(x => x.EvaluationTeamMember),
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
                .CheckContain(Searcher.EvluationEnt, x=>x.EvluationEnt)
                .CheckEqual(Searcher.EvaluationStartDate, x=>x.EvaluationStartDate)
                .CheckEqual(Searcher.EvaluationEndDate, x=>x.EvaluationEndDate)
                .CheckContain(Searcher.EvaluationLeader, x=>x.EvaluationLeader)
                .CheckContain(Searcher.ReportLeader, x=>x.ReportLeader)
                .CheckEqual(Searcher.Status, x=>x.Status)
                .Select(x => new SmallEntEvaluationBase_View
                {
				    ID = x.ID,
                    EvluationEnt = x.EvluationEnt,
                    EvaluationStartDate = x.EvaluationStartDate,
                    EvaluationEndDate = x.EvaluationEndDate,
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

    }
}
