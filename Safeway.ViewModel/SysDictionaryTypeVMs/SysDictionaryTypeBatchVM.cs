﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryTypeVMs
{
    public partial class SysDictionaryTypeBatchVM : BaseBatchVM<SysDictionaryType, SysDictionaryType_BatchEdit>
    {
        public SysDictionaryTypeBatchVM()
        {
            ListVM = new SysDictionaryTypeListVM();
            LinkedVM = new SysDictionaryType_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class SysDictionaryType_BatchEdit : BaseVM
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
