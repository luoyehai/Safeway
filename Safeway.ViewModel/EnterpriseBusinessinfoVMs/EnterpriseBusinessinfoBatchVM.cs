using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseBusinessinfoVMs
{
    public partial class EnterpriseBusinessinfoBatchVM : BaseBatchVM<EnterpriseBusinessinfo, EnterpriseBusinessinfo_BatchEdit>
    {
        public EnterpriseBusinessinfoBatchVM()
        {
            ListVM = new EnterpriseBusinessinfoListVM();
            LinkedVM = new EnterpriseBusinessinfo_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EnterpriseBusinessinfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
