using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;

namespace Safeway.Model.ReviewTemp
{
    public class ReviewLevel2Element : PersistPoco
    {
        [Display(Name = "要素名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(100)]
        public string ElementName { get; set; }

        [Display(Name = "基本规范要求")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(500)]
        public string ElementStandard { get; set; }

        [Display(Name = "要素序号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Order { get; set; }

        [Display(Name = "总分")]
        public int TotalScore { get; set; }

        [Display(Name = "一级要素")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid BasicElementId { get; set; }

        [Display(Name = "一级要素")]
        public ReviewBasicElement ReviewBasicElement { get; set; }
    }
}
