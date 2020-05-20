using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.EnterpriseReview;


namespace Safeway.ViewModel.EntRegularCheckElementVMs
{
    public partial class EntRegularCheckElementBatchVM : BaseBatchVM<EntRegularCheckElement, EntRegularCheckElement_BatchEdit>
    {
        public EntRegularCheckElementBatchVM()
        {
            ListVM = new EntRegularCheckElementListVM();
            LinkedVM = new EntRegularCheckElement_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EntRegularCheckElement_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
