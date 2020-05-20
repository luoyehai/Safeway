using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;

namespace Safeway.Model.EnterpriseReview
{
    public class EntRegularCheckElement : PersistPoco
    {
        [Display(Name = "要素名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(500, ErrorMessage = "{0}最多输入{1}个字符")]
        public string ElementName { get; set; }

        [Display(Name = "检查内容")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(1000, ErrorMessage = "{0}最多输入{1}个字符")]
        public string CheckContent { get; set; }

        [Display(Name = "检查重点")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(500, ErrorMessage = "{0}最多输入{1}个字符")]
        public string CheckPoint { get; set; }

        [Display(Name = "法规依据")]
        [StringLength(500, ErrorMessage = "{0}最多输入{1}个字符")]
        public string Regulations { get; set; }

        [Display(Name = "排序")]
        public int Order { get; set; }
    }
}
