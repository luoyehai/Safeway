using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Common;

namespace Safeway.Model.Enterprise
{

    public class EnterpriseBusinessinfo : BasePoco
    {
        [Display(Name = "安全服务类型")]
        public SafetyServiceTypeEnum? SafetyServiceType { get; set; }

        [Display(Name = "其他")]
        public string OtherSafetyServiceType { get; set; }

        [Display(Name = "证书等级")]
        [StringLength(50)]
        public string CertificateLevel { get; set; }

        [Display(Name = "到期时间")]
        [StringLength(50)]
        public string ExpireDate { get; set; }

        [Display(Name = "原服务公司")]
        [StringLength(50)]
        public string OriginalServiceCom { get; set; }

        [Display(Name = "描述")]
        [StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "企业名称")]
        public Guid EnterpriseBasicInfoId { get; set; }
    }
}
