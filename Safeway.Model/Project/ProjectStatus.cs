using Safeway.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.Project
{
    public class ProjectStatus : BasePoco
    {
        public ProjectTypeEnum? ProjectType { get; set; }

        public string Status { get; set; }

        public string ProjectId { get; set; }
    }
}
