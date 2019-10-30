using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewBasicElementVMs
{
    public partial class ReviewBasicElementBatchVM : BaseBatchVM<ReviewBasicElement, ReviewBasicElement_BatchEdit>
    {
        public ReviewBasicElementBatchVM()
        {
            ListVM = new ReviewBasicElementListVM();
            LinkedVM = new ReviewBasicElement_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class ReviewBasicElement_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
