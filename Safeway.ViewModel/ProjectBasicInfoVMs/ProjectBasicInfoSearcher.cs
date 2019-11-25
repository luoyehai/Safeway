using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Project;
using Safeway.Model.Common;


namespace Safeway.ViewModel.ProjectBasicInfoVMs
{
    public partial class ProjectBasicInfoSearcher : BaseSearcher
    {
        [Display(Name = "项目名称")]
        public String ProjectName { get; set; }
        [Display(Name = "项目描述")]
        public String ProjectDescription { get; set; }
        [Display(Name = "项目类型")]
        public ProjectTypeEnum? ProjectType { get; set; }
        [Display(Name = "项目负责人")]
        public String ProjectOnwer { get; set; }
        [Display(Name = "项目成员")]
        public String ProjectMember { get; set; }
        [Display(Name = "项目开始时间")]
        public DateTime? ProjectStartDate { get; set; }
        [Display(Name = "项目结束时间")]
        public DateTime? ProjectEndDate { get; set; }
        [Display(Name = "项目状态")]
        public ProjectStatusEnum? ProjectStatus { get; set; }

        protected override void InitVM()
        {
        }

    }
}
