using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;


namespace Safeway.ViewModel.EnterpriseBusinessinfoVMs
{
    public partial class EnterpriseBusinessinfoSearcher : BaseSearcher
    {
        [Display(Name = "安全服务类型")]
        public string SafetyServiceType { get; set; }
        [Display(Name = "其他")]
        public String OtherSafetyServiceType { get; set; }
        [Display(Name = "证书等级")]
        public String CertificateLevel { get; set; }
        [Display(Name = "到期时间")]
        public DateTime ExpireDate { get; set; }
        [Display(Name = "原服务公司")]
        public String OriginalServiceCom { get; set; }
        [Display(Name = "描述")]
        public String Description { get; set; }

        protected override void InitVM()
        {
        }

    }
}
