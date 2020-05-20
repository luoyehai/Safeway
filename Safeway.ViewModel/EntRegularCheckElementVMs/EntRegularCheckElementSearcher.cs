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
    public partial class EntRegularCheckElementSearcher : BaseSearcher
    {
        [Display(Name = "要素名称")]
        public String ElementName { get; set; }
        [Display(Name = "检查内容")]
        public String CheckContent { get; set; }
        [Display(Name = "检查重点")]
        public String CheckPoint { get; set; }
        [Display(Name = "法规依据")]
        public String Regulations { get; set; }

        protected override void InitVM()
        {
        }

    }
}
