using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryItemVMs
{
    public partial class SysDictionaryItemListVM : BasePagedListVM<SysDictionaryItem_View, SysDictionaryItemSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryItem", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<SysDictionaryItem_View>> InitGridHeader()
        {
            return new List<GridColumn<SysDictionaryItem_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Value),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeader(x => x.Sort),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SysDictionaryItem_View> GetSearchQuery()
        {
            var query = DC.Set<SysDictionaryItem>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.Value, x=>x.Value)
                .CheckContain(Searcher.Remark, x=>x.Remark)
                .Select(x => new SysDictionaryItem_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                    Value = x.Value,
                    Remark = x.Remark,
                    Sort = x.Sort,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SysDictionaryItem_View : SysDictionaryItem{

    }
}
