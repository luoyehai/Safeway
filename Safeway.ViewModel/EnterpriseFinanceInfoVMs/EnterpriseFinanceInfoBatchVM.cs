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
    public partial class EnterpriseFinanceInfoBatchVM : BaseBatchVM<EnterpriseFinanceInfo, EnterpriseFinanceInfo_BatchEdit>
    {
        public EnterpriseFinanceInfoBatchVM()
        {
            ListVM = new EnterpriseFinanceInfoListVM();
            LinkedVM = new EnterpriseFinanceInfo_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EnterpriseFinanceInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
