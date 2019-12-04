using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryItemVMs
{
    public partial class SysDictionaryItemSearcher : BaseSearcher
    {
        [Display(Name = "字典代码")]
        public string Code { get; set; }
        [Display(Name = "字典项名称")]
        public String Name { get; set; }
        [Display(Name = "字典项值")]
        public String Value { get; set; }
        [Display(Name = "备注")]
        public String Remark { get; set; }

        protected override void InitVM()
        {
        }

    }
}
