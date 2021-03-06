﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.System;


namespace Safeway.ViewModel.SysDictionaryItemVMs
{
    public partial class SysDictionaryItemBatchVM : BaseBatchVM<SysDictionaryItem, SysDictionaryItem_BatchEdit>
    {
        public SysDictionaryItemBatchVM()
        {
            ListVM = new SysDictionaryItemListVM();
            LinkedVM = new SysDictionaryItem_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class SysDictionaryItem_BatchEdit : BaseVM
    {
        [Display(Name = "字典代码")]
        public String Code { get; set; }
        [Display(Name = "字典项名称")]
        public String Name { get; set; }
        [Display(Name = "字典项值")]
        public String Value { get; set; }
        [Display(Name = "备注")]
        public String Remark { get; set; }
        [Display(Name = "顺序")]
        public Int32? Sort { get; set; }
        [Display(Name = "子代码")]
        public String ChildrenCode { get; set; }

        protected override void InitVM()
        {
        }

    }

}
