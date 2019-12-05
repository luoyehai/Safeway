using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.System
{
    public class SysDictionaryItem : PersistPoco
    {

        [Display(Name = "字典代码")]
        public string Code { get; set; }

        [Display(Name = "字典项名称")]
        public string Name { get; set; }

        [Display(Name = "字典项值")]
        public string Value { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        [Display(Name = "顺序")]
        public int Sort { get; set; }
    }
}
