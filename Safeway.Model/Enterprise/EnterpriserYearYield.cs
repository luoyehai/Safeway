using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Common;

namespace Safeway.Model.Enterprise
{
    public class EnterpriserYearYield : BasePoco
    {
        [Display(Name = "财年")]
        public DateTime FiscalYear { get; set; }

        [Display(Name = "年收益")]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal YearYieldValue { get; set; }

        [Display(Name = "创建时间")]
        public DateTime Created { get; set; }

        [Display(Name = "企业名称")]
        public Guid EnterpriseBasicInfoId { get; set; }
       // public EnterpriseBasicInfo EnterpriseBasicInfo { get; set; }
    }
}
