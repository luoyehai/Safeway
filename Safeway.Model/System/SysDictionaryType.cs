using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.System
{
    public class SysDictionaryType : PersistPoco
    {
        [Display(Name = "字典编码")]
        public string Code { get; set; }

        [Display(Name = "字典名称")]
        public string Name { get; set; }

        [Display(Name = "父字典编码")]
        public string ParentCode { get; set; }
    }
}
