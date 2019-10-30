using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewLevel2ElementVMs
{
    public partial class ReviewLevel2ElementListVM : BasePagedListVM<ReviewLevel2Element_View, ReviewLevel2ElementSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("ReviewLevel2Element", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<ReviewLevel2Element_View>> InitGridHeader()
        {
            return new List<GridColumn<ReviewLevel2Element_View>>{
                this.MakeGridHeader(x => x.ElementName),
                this.MakeGridHeader(x => x.ElementStandard),
                this.MakeGridHeader(x => x.Order),
                this.MakeGridHeader(x => x.TotalScore),
                this.MakeGridHeader(x => x.ElementName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ReviewLevel2Element_View> GetSearchQuery()
        {
            var query = DC.Set<ReviewLevel2Element>()
                .CheckContain(Searcher.ElementName, x=>x.ElementName)
                .CheckContain(Searcher.ElementStandard, x=>x.ElementStandard)
                .CheckEqual(Searcher.BasicElementId, x=>x.BasicElementId)
                .Select(x => new ReviewLevel2Element_View
                {
				    ID = x.ID,
                    ElementName = x.ElementName,
                    ElementStandard = x.ElementStandard,
                    Order = x.Order,
                    TotalScore = x.TotalScore,
                    ElementName_view = x.ReviewBasicElement.ElementName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ReviewLevel2Element_View : ReviewLevel2Element{
        [Display(Name = "要素名称")]
        public String ElementName_view { get; set; }

    }
}
