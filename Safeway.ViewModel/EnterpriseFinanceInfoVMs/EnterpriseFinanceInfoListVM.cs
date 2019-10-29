using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseFinanceInfoVMs
{
    public partial class EnterpriseFinanceInfoListVM : BasePagedListVM<EnterpriseFinanceInfo_View, EnterpriseFinanceInfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseFinanceInfo", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriseFinanceInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriseFinanceInfo_View>>{
                this.MakeGridHeader(x => x.UnifiedSocialCreditCode),
                this.MakeGridHeader(x => x.Company_Address),
                this.MakeGridHeader(x => x.Tele_Number),
                this.MakeGridHeader(x => x.Bank),
                this.MakeGridHeader(x => x.Account),
                this.MakeGridHeader(x => x.CustomerReceiptReceiver),
                this.MakeGridHeader(x => x.ComapanyName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriseFinanceInfo_View> GetSearchQuery()
        {
            var query = DC.Set<EnterpriseFinanceInfo>()
                .CheckContain(Searcher.UnifiedSocialCreditCode, x=>x.UnifiedSocialCreditCode)
                .CheckContain(Searcher.CustomerReceiptReceiver, x=>x.CustomerReceiptReceiver)
                .CheckEqual(Searcher.EnterpriseBasicId, x=>x.EnterpriseBasicId)
                .Select(x => new EnterpriseFinanceInfo_View
                {
				    ID = x.ID,
                    UnifiedSocialCreditCode = x.UnifiedSocialCreditCode,
                    Company_Address = x.Company_Address,
                    Tele_Number = x.Tele_Number,
                    Bank = x.Bank,
                    Account = x.Account,
                    CustomerReceiptReceiver = x.CustomerReceiptReceiver,
                    ComapanyName_view = x.BasicInfo.ComapanyName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class EnterpriseFinanceInfo_View : EnterpriseFinanceInfo{
        [Display(Name = "公司名称")]
        public String ComapanyName_view { get; set; }

    }
}
