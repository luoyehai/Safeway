using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.BasicEntEvaluation;
using Safeway.Model.Common;


namespace Safeway.ViewModel.BasicEntEvaluationBaseVMs
{
    public partial class BasicEntEvaluationBaseListVM : BasePagedListVM<BasicEntEvaluationBase_View, BasicEntEvaluationBaseSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("BasicEntEvaluationBase", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<BasicEntEvaluationBase_View>> InitGridHeader()
        {
            return new List<GridColumn<BasicEntEvaluationBase_View>>{
                this.MakeGridHeader(x => x.ProjectId),
                this.MakeGridHeader(x => x.EnterpriseId),
                this.MakeGridHeader(x => x.EvluationEnt),
                this.MakeGridHeader(x => x.EvaluationStartDate),
                this.MakeGridHeader(x => x.EvaluationEndDate),
                this.MakeGridHeader(x => x.Evaluator),
                this.MakeGridHeader(x => x.Status),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<BasicEntEvaluationBase_View> GetSearchQuery()
        {
            var query = DC.Set<BasicEntEvaluationBase>()
                .CheckContain(Searcher.ProjectId, x=>x.ProjectId)
                .CheckContain(Searcher.EnterpriseId, x=>x.EnterpriseId)
                .CheckContain(Searcher.EvluationEnt, x=>x.EvluationEnt)
                .CheckEqual(Searcher.EvaluationStartDate, x=>x.EvaluationStartDate)
                .CheckEqual(Searcher.EvaluationEndDate, x=>x.EvaluationEndDate)
                .CheckContain(Searcher.Evaluator, x=>x.Evaluator)
                .CheckEqual(Searcher.Status, x=>x.Status)
                .Select(x => new BasicEntEvaluationBase_View
                {
				    ID = x.ID,
                    ProjectId = x.ProjectId,
                    EnterpriseId = x.EnterpriseId,
                    EvluationEnt = x.EvluationEnt,
                    EvaluationStartDate = x.EvaluationStartDate,
                    EvaluationEndDate = x.EvaluationEndDate,
                    Evaluator = x.Evaluator,
                    Status = x.Status,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class BasicEntEvaluationBase_View : BasicEntEvaluationBase{

    }
}
