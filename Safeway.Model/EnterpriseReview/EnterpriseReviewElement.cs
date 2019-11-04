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
    public class EnterpriseReviewElement : PersistPoco
    {
        [Display(Name = "要素名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(500, ErrorMessage = "{0}最多输入{1}个字符")]
        public string ElementName { get; set; }

        [Display(Name = "要素类别")]
        public ReviewTypeEnum Category { get; set; }

        [Display(Name = "级别")]
        [Required(ErrorMessage = "{0}是必填项")]
        public ElementLevelEnum Level { get; set; }

        [Display(Name = "排序")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int Order { get; set; }

        [Display(Name = "总分")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int TotalScore { get; set; }

        [Display(Name = "上级要素ID")]
        public Guid ParentElementId { get; set; }

    }
}
