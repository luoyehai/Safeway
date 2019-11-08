using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Evaluation;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.NormalEntEvaluationTemplateVMs
{
    public partial class NormalEntEvaluationTemplateListVM : BasePagedListVM<NormalEntEvaluationTemplate_View, NormalEntEvaluationTemplateSearcher>
    {

        public NormalEntEvaluationTemplateListVM()
        {

        }
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("NormalEntEvaluationTemplate", GridActionStandardTypesEnum.ExportExcel, "导出",""),
                this.MakeAction("NormalEntEvaluation","Index","开始评分","评分页面", GridActionParameterTypesEnum.NoId,"").SetShowDialog(true).SetIsRedirect(true).SetShowInRow(true),
            };
        }

        protected override IEnumerable<IGridColumn<NormalEntEvaluationTemplate_View>> InitGridHeader()
        {
            return new List<GridColumn<NormalEntEvaluationTemplate_View>>{
                this.MakeGridHeader(x => x.EvluationEnt),
                this.MakeGridHeader(x => x.EvaluationStartDate),
                this.MakeGridHeader(x => x.EvaluationEndDate),
                this.MakeGridHeader(x => x.EvaluationLeader),
                this.MakeGridHeader(x => x.EvaluationTeamMember),
                this.MakeGridHeader(x => x.ModuleOne),
                this.MakeGridHeader(x => x.ModuleTwo),
                this.MakeGridHeader(x => x.ModuleThree),
                this.MakeGridHeader(x => x.ComapanyName_view),
                this.MakeGridHeaderAction(width: 300),

            };
        }

        public override IOrderedQueryable<NormalEntEvaluationTemplate_View> GetSearchQuery()
        {
            var query = DC.Set<NormalEntEvaluationTemplate>()
                .CheckContain(Searcher.EvluationEnt, x=>x.EvluationEnt)
                .CheckEqual(Searcher.EvaluationStartDate, x=>x.EvaluationStartDate)
                .CheckEqual(Searcher.EvaluationEndDate, x=>x.EvaluationEndDate)
                .CheckContain(Searcher.EvaluationLeader, x=>x.EvaluationLeader)
                .CheckEqual(Searcher.EnterpriseId, x=>x.EnterpriseId)
                .Select(x => new NormalEntEvaluationTemplate_View
                {
				    ID = x.ID,
                    EvluationEnt = x.EvluationEnt,
                    EvaluationStartDate = x.EvaluationStartDate,
                    EvaluationEndDate = x.EvaluationEndDate,
                    EvaluationLeader = x.EvaluationLeader,
                    EvaluationTeamMember = x.EvaluationTeamMember,
                    ModuleOne = x.ModuleOne,
                    ModuleTwo = x.ModuleTwo,
                    ModuleThree = x.ModuleThree,
                    ComapanyName_view = x.EnterpriseBasicInfo.ComapanyName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class NormalEntEvaluationTemplate_View : NormalEntEvaluationTemplate{
        [Display(Name = "公司名称")]
        public String ComapanyName_view { get; set; }

    }
}
