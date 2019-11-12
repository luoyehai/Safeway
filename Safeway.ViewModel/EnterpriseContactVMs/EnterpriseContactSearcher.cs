using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseContactVMs
{
    public partial class EnterpriseContactSearcher : BaseSearcher
    {
        [Display(Name = "部门")]
        public String Dept { get; set; }
        public List<ComboSelectListItem> AllEnterpriseBasicInfos { get; set; }

        [Display(Name = "企业名称")]
        public Guid? EnterpriseBasicInfoId { get; set; }

        protected override void InitVM()
        {
            AllEnterpriseBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }
}
