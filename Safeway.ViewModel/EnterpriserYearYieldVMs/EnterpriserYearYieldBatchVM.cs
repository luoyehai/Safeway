using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriserYearYieldVMs
{
    public partial class EnterpriserYearYieldBatchVM : BaseBatchVM<EnterpriserYearYield, EnterpriserYearYield_BatchEdit>
    {
        public EnterpriserYearYieldBatchVM()
        {
            ListVM = new EnterpriserYearYieldListVM();
            LinkedVM = new EnterpriserYearYield_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EnterpriserYearYield_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
