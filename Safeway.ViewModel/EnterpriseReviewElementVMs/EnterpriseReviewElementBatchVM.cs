using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.EnterpriseReview;


namespace Safeway.ViewModel.EnterpriseReviewElementVMs
{
    public partial class EnterpriseReviewElementBatchVM : BaseBatchVM<EnterpriseReviewElement, EnterpriseReviewElement_BatchEdit>
    {
        public EnterpriseReviewElementBatchVM()
        {
            ListVM = new EnterpriseReviewElementListVM();
            LinkedVM = new EnterpriseReviewElement_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EnterpriseReviewElement_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
