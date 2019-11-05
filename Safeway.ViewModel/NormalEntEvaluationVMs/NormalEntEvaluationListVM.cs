using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Evaluation;


namespace Safeway.ViewModel.NormalEntEvaluationVMs
{
    public partial class NormalEntEvaluationListVM : BasePagedListVM<NormalEntEvaluation_View, NormalEntEvaluationSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluation", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<NormalEntEvaluation_View>> InitGridHeader()
        {
            return new List<GridColumn<NormalEntEvaluation_View>>{
                this.MakeGridHeader(x => x.LevelOneElement),
                this.MakeGridHeader(x => x.LevelTwoElement),
                this.MakeGridHeader(x => x.LevelThreeElement),
                this.MakeGridHeader(x => x.ComplianceStandard),
                this.MakeGridHeader(x => x.BasicRuleRequirement),
                this.MakeGridHeader(x => x.StandardScore),
                this.MakeGridHeader(x => x.EvaluationDescription),
                this.MakeGridHeader(x => x.AssignTo),
                this.MakeGridHeader(x => x.ActualScore),
                this.MakeGridHeader(x => x.EvluationEnt_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<NormalEntEvaluation_View> GetSearchQuery()
        {
            var query = DC.Set<NormalEntEvaluation>()
                .CheckContain(Searcher.ComplianceStandard, x=>x.ComplianceStandard)
                .CheckContain(Searcher.BasicRuleRequirement, x=>x.BasicRuleRequirement)
                .CheckContain(Searcher.AssignTo, x=>x.AssignTo)
                .Select(x => new NormalEntEvaluation_View
                {
				    ID = x.ID,
                    LevelOneElement = x.LevelOneElement,
                    LevelTwoElement = x.LevelTwoElement,
                    LevelThreeElement = x.LevelThreeElement,
                    ComplianceStandard = x.ComplianceStandard,
                    BasicRuleRequirement = x.BasicRuleRequirement,
                    StandardScore = x.StandardScore,
                    EvaluationDescription = x.EvaluationDescription,
                    AssignTo = x.AssignTo,
                    ActualScore = x.ActualScore,
                    EvluationEnt_view = x.NormalEntEvaluationTemplate.EvluationEnt,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class NormalEntEvaluation_View : NormalEntEvaluation{
        [Display(Name = "评审单位")]
        public String EvluationEnt_view { get; set; }

    }
}
