using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.Common
{
    public enum TermsofTradeEnum
    {
        [Display(Name = "出口")]
        Export,
        [Display(Name = "内销")]
        DomesticSales
    }
    public enum CompanyScaleEnum
    {
        [Display(Name = "规上")]
        Large,
        [Display(Name = "小微")]
        Small
    }
    public enum SafetyServiceTypeEnum 
    {
        [Display(Name = "安全生产标准化")]
        SafetyProductionStandard,
        [Display(Name = "双重预防机智")]
        DoublePreventionMechanism,
        [Display(Name = "安全应急预案")]
        SafetyEmergencyPlan,
        [Display(Name = "安全现状评价")]
        SageEvaluation,
        [Display(Name = "就业卫生现状评价")]
        EmploymentHealthEva,
        [Display(Name = "定期安全服务")]
        RegularSafetyService,
        [Display(Name = "环境应急预案")]
        EnvEmergencyPlan,
        [Display(Name = "其他")]
        Others
    }
    public class CommonEnums
    {
    }
}
