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
        [Display(Name = "省")]
        public string Province { get; set; }
        public List<ComboSelectListItem> AllProvinces { get; set; }
        [Display(Name = "市")]
        public string City { get; set; }
        public List<ComboSelectListItem> AllCities { get; set; }
        [Display(Name = "区")]
        public string District { get; set; }
        public List<ComboSelectListItem> AllDistricts { get; set; }
        [Display(Name = "企业名称")]
        public Guid? EnterpriseBasicId { get; set; }
        public List<ComboSelectListItem> AllBasicInfos { get; set; }
        protected override void InitVM()
        {
            AllProvinces =DC.Set<EnterpriseBasicInfo>().GroupBy(y => y.Province).Select(y => new ComboSelectListItem { Text = y.First().Province, Value = y.First().Province }).ToList();
            AllCities = DC.Set<EnterpriseBasicInfo>().GroupBy(y => y.City).Select(y =>new ComboSelectListItem { Text=y.First().City,Value=y.First().City}).ToList();
            AllDistricts = DC.Set<EnterpriseBasicInfo>().GroupBy(y => y.District).Select(y => new ComboSelectListItem { Text = y.First().District, Value = y.First().District }).ToList();
            AllBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

    }
}
