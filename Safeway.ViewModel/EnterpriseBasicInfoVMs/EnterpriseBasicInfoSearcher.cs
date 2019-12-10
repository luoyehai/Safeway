using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseBasicInfoVMs
{
    public partial class EnterpriseBasicInfoSearcher : BaseSearcher
    {
        [Display(Name = "街道")]
        [StringLength(300)]
        public string Street { get; set; }
        [Display(Name = "企业类型")]
        [StringLength(30)]
        public string CompanyType { get; set; }
        [Display(Name = "企业规模")]
        [StringLength(150)]
        public string CompanyScale { get; set; }

        [Display(Name = "行业")]
        [StringLength(100)]
        public string Industry { get; set; }
        [Display(Name = "企业名称")]
        public Guid? EnterpriseBasicId { get; set; }
        public List<ComboSelectListItem> AllBasicInfos { get; set; }
        protected override void InitVM()
        {

            AllBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }
}
