using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseFinanceInfoVMs
{
    public partial class EnterpriseFinanceInfoSearcher : BaseSearcher
    {
        [Display(Name = "统一社会信用代码")]
        public String UnifiedSocialCreditCode { get; set; }
        [Display(Name = "发票接收人")]
        public String CustomerReceiptReceiver { get; set; }
        public List<ComboSelectListItem> AllBasicInfos { get; set; }
        public Guid? EnterpriseBasicId { get; set; }

        protected override void InitVM()
        {
            AllBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }
}
