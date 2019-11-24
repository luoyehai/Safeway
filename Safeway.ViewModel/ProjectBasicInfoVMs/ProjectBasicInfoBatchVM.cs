using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Project;


namespace Safeway.ViewModel.ProjectBasicInfoVMs
{
    public partial class ProjectBasicInfoBatchVM : BaseBatchVM<ProjectBasicInfo, ProjectBasicInfo_BatchEdit>
    {
        public ProjectBasicInfoBatchVM()
        {
            ListVM = new ProjectBasicInfoListVM();
            LinkedVM = new ProjectBasicInfo_BatchEdit();
        }

    }

	/// <summary>
    /// 批量编辑字段类
    /// </summary>
    public class ProjectBasicInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
