using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseBasicInfoVMs
{
    public partial class EnterpriseBasicInfoBatchVM : BaseBatchVM<EnterpriseBasicInfo, EnterpriseBasicInfo_BatchEdit>
    {
        public EnterpriseBasicInfoBatchVM()
        {
            ListVM = new EnterpriseBasicInfoListVM();
            LinkedVM = new EnterpriseBasicInfo_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EnterpriseBasicInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
