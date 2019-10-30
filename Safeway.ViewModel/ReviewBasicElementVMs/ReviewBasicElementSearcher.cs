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
    public partial class ReviewBasicElementSearcher : BaseSearcher
    {
        [Display(Name = "评审模板类型")]
        public ReviewTempTypeEnum? ReviewTempType { get; set; }
        [Display(Name = "要素名称")]
        public String ElementName { get; set; }
        [Display(Name = "要素描述")]
        public String ElementDesc { get; set; }

        protected override void InitVM()
        {
        }

    }
}
