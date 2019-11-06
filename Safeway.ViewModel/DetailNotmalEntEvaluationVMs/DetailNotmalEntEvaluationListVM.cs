using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Evaluation;
using Safeway.Model.Common;


namespace Safeway.ViewModel.DetailNotmalEntEvaluationVMs
{
    public partial class DetailNotmalEntEvaluationListVM : BasePagedListVM<DetailNotmalEntEvaluation_View, DetailNotmalEntEvaluationSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("DetailNotmalEntEvaluation", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<DetailNotmalEntEvaluation_View>> InitGridHeader()
        {
            return new List<GridColumn<DetailNotmalEntEvaluation_View>>{
                this.MakeGridHeader(x => x.EvaluateType),
                this.MakeGridHeader(x => x.EvaluationSelection),
                this.MakeGridHeader(x => x.DeductionReference),
                this.MakeGridHeader(x => x.Deduction),
                this.MakeGridHeader(x => x.DeductionDescription),
                this.MakeGridHeader(x => x.ComplianceStandard_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<DetailNotmalEntEvaluation_View> GetSearchQuery()
        {
            var query = DC.Set<DetailNotmalEntEvaluation>()
                .CheckEqual(Searcher.EvaluateType, x=>x.EvaluateType)
                .CheckEqual(Searcher.NormalEntEvaluationId, x=>x.NormalEntEvaluationId)
                .Select(x => new DetailNotmalEntEvaluation_View
                {
				    ID = x.ID,
                    EvaluateType = x.EvaluateType,
                    EvaluationSelection = x.EvaluationSelection,
                    DeductionReference = x.DeductionReference,
                    Deduction = x.Deduction,
                    DeductionDescription = x.DeductionDescription,
                    ComplianceStandard_view = x.NormalEntEvaluation.ComplianceStandard,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class DetailNotmalEntEvaluation_View : DetailNotmalEntEvaluation{
        [Display(Name = "四级要素")]
        public String ComplianceStandard_view { get; set; }

    }
}
