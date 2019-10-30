using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewLevel2ElementVMs
{
    public partial class ReviewLevel2ElementBatchVM : BaseBatchVM<ReviewLevel2Element, ReviewLevel2Element_BatchEdit>
    {
        public ReviewLevel2ElementBatchVM()
        {
            ListVM = new ReviewLevel2ElementListVM();
            LinkedVM = new ReviewLevel2Element_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class ReviewLevel2Element_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
