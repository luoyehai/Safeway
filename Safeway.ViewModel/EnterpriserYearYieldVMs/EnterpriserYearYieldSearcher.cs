using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriserYearYieldVMs
{
    public partial class EnterpriserYearYieldSearcher : BaseSearcher
    {
        [Display(Name = "财年")]
        public String FiscalYear { get; set; }
        public List<ComboSelectListItem> AllEnterpriseBasicInfos { get; set; }
        public Guid? EnterpriseBasicInfoId { get; set; }

        protected override void InitVM()
        {
            AllEnterpriseBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }
}
