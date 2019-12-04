using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryTypeVMs
{
    public partial class SysDictionaryTypeSearcher : BaseSearcher
    {
        [Display(Name = "字典编码")]
        public String Code { get; set; }
        [Display(Name = "字典名称")]
        public String Name { get; set; }

        protected override void InitVM()
        {
        }

    }
}
