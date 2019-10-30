using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.ReviewTemp
{
    public enum ReviewTempTypeEnum
    {
        [Display(Name = "企业安全生产标准化小微评审")]
        SmallEntReview,
        [Display(Name = "企业安全诊断")]
        SafeDiagnose,
        [Display(Name = "企业安全检查")]
        SafeInspection,
        [Display(Name = "企业生产标准化三级评审")]
        LevelThreeReview
    }

    public class ReviewTempBasic : BasePoco
    {
        [Display(Name = "评审模板类型")]
        public ReviewTempTypeEnum? ReviewTempType { get; set; }

        [Display(Name = "要素名称")]
        [Required]
        [StringLength(100)]
        public string ElementName { get; set; }

        [Display(Name = "要素描述")]
        [StringLength(200)]
        public string ElementDesc { get; set; }

        [Display(Name = "要素序号")]
        public int Order { get; set; }

        [Display(Name = "总分")]
        public int TotalScore { get; set; }
    }
}
