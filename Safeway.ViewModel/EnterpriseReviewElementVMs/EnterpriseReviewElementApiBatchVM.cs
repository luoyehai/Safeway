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
    public partial class EnterpriseReviewElementApiBatchVM : BaseBatchVM<EnterpriseReviewElement, EnterpriseReviewElementApi_BatchEdit>
    {
        public EnterpriseReviewElementApiBatchVM()
        {
            ListVM = new EnterpriseReviewElementApiListVM();
            LinkedVM = new EnterpriseReviewElementApi_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class EnterpriseReviewElementApi_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
