using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;
using Safeway.Model.ReviewTemp;

namespace Safeway.Model.SamllEntReviewTemp
{

    public enum ElementTypeEnum
    {
        [Display(Name = "文件")]
        File,
        [Display(Name = "现场")]
        Site
    }

    public class ReviewLevel3Element: PersistPoco
    {
        [Display(Name = "企业达标标准")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(300)]
        public string EntStandard { get; set; }

        [Display(Name = "要素类型")]
        [Required(ErrorMessage = "{0}是必填项")]
        public ElementTypeEnum ElementType { get; set; }

        [Display(Name = "标准分值")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int StandardScore { get; set; }

        [Display(Name = "评分方式")]
        [StringLength(300)]
        public string ReviewMode { get; set; }

        [Display(Name = "要素序号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Order { get; set; }

        [Display(Name = "总分")]
        public int GroupScore { get; set; }

        [Display(Name = "二级要素")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid Level2ElementId { get; set; }

        [Display(Name = "二级要素")]
        public ReviewLevel2Element ReviewLevel2Elements { get; set; }
    }
}
