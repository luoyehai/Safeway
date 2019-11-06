using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.EnterpriseReview;
using Safeway.Model.Common;


namespace Safeway.ViewModel.EnterpriseReviewElementVMs
{
    public partial class EnterpriseReviewElementApiListVM : BasePagedListVM<EnterpriseReviewElementApi_View, EnterpriseReviewElementApiSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriseReviewElementApi_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriseReviewElementApi_View>>{
                this.MakeGridHeader(x => x.ElementName),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeader(x => x.Order),
                this.MakeGridHeader(x => x.TotalScore),
                this.MakeGridHeader(x => x.ParentElementId),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriseReviewElementApi_View> GetSearchQuery()
        {
            var query = DC.Set<EnterpriseReviewElement>()
                .CheckContain(Searcher.ElementName, x=>x.ElementName)
                .CheckEqual(Searcher.Level, x=>x.Level)
                .CheckContain(Searcher.ParentElementId, x=>x.ParentElementId)
                .Select(x => new EnterpriseReviewElementApi_View
                {
				    ID = x.ID,
                    ElementName = x.ElementName,
                    Level = x.Level,
                    Order = x.Order,
                    TotalScore = x.TotalScore,
                    ParentElementId = x.ParentElementId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class EnterpriseReviewElementApi_View : EnterpriseReviewElement{

    }
}
