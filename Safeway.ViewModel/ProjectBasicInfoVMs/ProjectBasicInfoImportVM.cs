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
    public partial class ProjectBasicInfoTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class ProjectBasicInfoImportVM : BaseImportVM<ProjectBasicInfoTemplateVM, ProjectBasicInfo>
    {

    }

}
