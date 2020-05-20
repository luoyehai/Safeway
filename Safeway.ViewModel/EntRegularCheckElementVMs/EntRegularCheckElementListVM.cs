using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.EnterpriseReview;


namespace Safeway.ViewModel.EntRegularCheckElementVMs
{
    public partial class EntRegularCheckElementListVM : BasePagedListVM<EntRegularCheckElement_View, EntRegularCheckElementSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("EntRegularCheckElement", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EntRegularCheckElement_View>> InitGridHeader()
        {
            return new List<GridColumn<EntRegularCheckElement_View>>{
                this.MakeGridHeader(x => x.ElementName),
                this.MakeGridHeader(x => x.CheckContent),
                this.MakeGridHeader(x => x.CheckPoint),
                this.MakeGridHeader(x => x.Regulations),
                this.MakeGridHeader(x => x.Order),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EntRegularCheckElement_View> GetSearchQuery()
        {
            var query = DC.Set<EntRegularCheckElement>()
                .CheckContain(Searcher.ElementName, x=>x.ElementName)
                .CheckContain(Searcher.CheckContent, x=>x.CheckContent)
                .CheckContain(Searcher.CheckPoint, x=>x.CheckPoint)
                .CheckContain(Searcher.Regulations, x=>x.Regulations)
                .Select(x => new EntRegularCheckElement_View
                {
				    ID = x.ID,
                    ElementName = x.ElementName,
                    CheckContent = x.CheckContent,
                    CheckPoint = x.CheckPoint,
                    Regulations = x.Regulations,
                    Order = x.Order,
                })
                .OrderBy(x => x.Order);
            return query;
        }

    }

    public class EntRegularCheckElement_View : EntRegularCheckElement{

    }
}
