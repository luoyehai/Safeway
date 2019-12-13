using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryTypeVMs
{
    public partial class SysDictionaryTypeListVM : BasePagedListVM<SysDictionaryType_View, SysDictionaryTypeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("SysDictionaryType", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<SysDictionaryType_View>> InitGridHeader()
        {
            return new List<GridColumn<SysDictionaryType_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.ParentCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SysDictionaryType_View> GetSearchQuery()
        {
            var query = DC.Set<SysDictionaryType>()
                .CheckContain(Searcher.Code, x => x.Code)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckContain(Searcher.ParentCode, x => x.ParentCode)
                .Select(x => new SysDictionaryType_View
                {
                    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                    ParentCode = x.ParentCode,
                })
                .OrderBy(x => x.Code);
            return query;
        }

    }

    public class SysDictionaryType_View : SysDictionaryType{

    }
}
