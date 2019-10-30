using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewBasicElementVMs
{
    public partial class ReviewBasicElementListVM : BasePagedListVM<ReviewBasicElement_View, ReviewBasicElementSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("ReviewBasicElement", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<ReviewBasicElement_View>> InitGridHeader()
        {
            return new List<GridColumn<ReviewBasicElement_View>>{
                this.MakeGridHeader(x => x.ReviewTempType),
                this.MakeGridHeader(x => x.ElementName),
                this.MakeGridHeader(x => x.ElementDesc),
                this.MakeGridHeader(x => x.Order),
                this.MakeGridHeader(x => x.TotalScore),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ReviewBasicElement_View> GetSearchQuery()
        {
            var query = DC.Set<ReviewBasicElement>()
                .CheckEqual(Searcher.ReviewTempType, x=>x.ReviewTempType)
                .CheckContain(Searcher.ElementName, x=>x.ElementName)
                .CheckContain(Searcher.ElementDesc, x=>x.ElementDesc)
                .Select(x => new ReviewBasicElement_View
                {
				    ID = x.ID,
                    ReviewTempType = x.ReviewTempType,
                    ElementName = x.ElementName,
                    ElementDesc = x.ElementDesc,
                    Order = x.Order,
                    TotalScore = x.TotalScore,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ReviewBasicElement_View : ReviewBasicElement{

    }
}
