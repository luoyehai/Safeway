using Safeway.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.Project
{
    public class ProjectBasicInfo : PersistPoco
    {
        [Display(Name = "项目名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [Display(Name = "项目描述")]
        [StringLength(500)]
        public string ProjectDescription { get; set; }

        [Display(Name = "项目类型")]
        public ProjectTypeEnum? ProjectType { get; set; }

        [Display(Name = "项目负责人")]
        public string ProjectOnwer { get; set; }

        [Display(Name = "项目成员")]
        public int ProjectMember { get; set; }

        [Display(Name = "项目开始时间")]
        public DateTime? ProjectStartDate { get; set; }

        [Display(Name = "项目开始时间")]
        public DateTime? ProjectEndDate { get; set; }

        public int ProjectStatus { get; set; }
    }
}
