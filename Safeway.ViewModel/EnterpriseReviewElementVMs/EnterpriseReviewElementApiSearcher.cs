using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.EnterpriseReview;
using Safeway.Model.Common;


namespace Safeway.ViewModel.EnterpriseReviewElementVMs
{
    public partial class EnterpriseReviewElementApiSearcher : BaseSearcher
    {
        [Display(Name = "要素名称")]
        public String ElementName { get; set; }
        [Display(Name = "级别")]
        public ElementLevelEnum? Level { get; set; }
        [Display(Name = "上级要素")]
        public String ParentElementId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
