using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseContactVMs
{
    public partial class EnterpriseContactBatchVM : BaseBatchVM<EnterpriseContact, EnterpriseContact_BatchEdit>
    {
        public EnterpriseContactBatchVM()
        {
            ListVM = new EnterpriseContactListVM();
            LinkedVM = new EnterpriseContact_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EnterpriseContact_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
