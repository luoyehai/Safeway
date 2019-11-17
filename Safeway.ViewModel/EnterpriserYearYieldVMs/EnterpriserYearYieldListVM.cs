using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriserYearYieldVMs
{
    public partial class EnterpriserYearYieldListVM : BasePagedListVM<EnterpriserYearYield_View, EnterpriserYearYieldSearcher>
    {
        public Guid basicInfoID { get; set; }
        public EnterpriserYearYieldListVM(string id) 
        {
            basicInfoID = new Guid(id);
            // EntityList = EntityList.Where(x => x.EnterpriseBasicInfoId == new Guid(id)).ToList();
        }
        public EnterpriserYearYieldListVM()
        {

        }
        protected override void InitVM()
        {

        }
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriserYearYield", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriserYearYield_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriserYearYield_View>>{
                this.MakeGridHeader(x => x.FiscalYear),
                this.MakeGridHeader(x => x.YearYieldValue),
                this.MakeGridHeader(x => x.Created),
                this.MakeGridHeader(x => x.ComapanyName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriserYearYield_View> GetSearchQuery()
        {
            if (basicInfoID != null && !string.IsNullOrEmpty(basicInfoID.ToString()))
            {
                var queryfilter = DC.Set<EnterpriserYearYield>()
                    //.CheckEqual(Searcher.FiscalYear, x => x.FiscalYear)
                    .CheckEqual(Searcher.Created, x => x.Created)
                    .CheckEqual(Searcher.EnterpriseBasicInfoId, x => x.EnterpriseBasicInfoId)
                    .Select(x => new EnterpriserYearYield_View
                    {
                        ID = x.ID,
                        FiscalYear = x.FiscalYear,
                        YearYieldValue = x.YearYieldValue,
                        Created = x.Created,
                        ComapanyName_view = DC.Set<EnterpriseBasicInfo>().Where(y => y.ID == x.EnterpriseBasicInfoId).Select(y => y.ComapanyName).FirstOrDefault()
                    })
                    .Where(x => x.EnterpriseBasicInfoId==basicInfoID)
                    .OrderBy(x => x.ID);
                return queryfilter;
            }
            var query = DC.Set<EnterpriserYearYield>()
                //.CheckEqual(Searcher.FiscalYear, x=>x.FiscalYear)
                .CheckEqual(Searcher.Created, x=>x.Created)
                .CheckEqual(Searcher.EnterpriseBasicInfoId, x => x.EnterpriseBasicInfoId)
                .Select(x => new EnterpriserYearYield_View
                {
				    ID = x.ID,
                    FiscalYear = x.FiscalYear,
                    YearYieldValue = x.YearYieldValue,
                    Created = x.Created,
                    ComapanyName_view = DC.Set<EnterpriseBasicInfo>().Where(y=> y.ID == x.EnterpriseBasicInfoId).Select(y=> y.ComapanyName).FirstOrDefault()
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class EnterpriserYearYield_View : EnterpriserYearYield{
        [Display(Name = "公司名称")]
        public String ComapanyName_view { get; set; }
    }
}
