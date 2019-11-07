using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.Common
{
    public enum EvaluationSelectionEnum
    {
        [Display(Name = "符合")]
        Compliant,
        [Display(Name = "不符合")]
        Imcompliant,
        [Display(Name = "不涉及")]
        NotInvolve
    }

    public enum ReviewTypeEnum
    {
        [Display(Name = "企业安全生产标准化小微评审")]
        SmallEnterpriseReivew,
        [Display(Name = "企业生产标准化三级评审")]
        EnterpriseLevel3Review
    }

    public enum ElementLevelEnum
    {
        [Display(Name = "一级")]
        LevelOne = 1,
        [Display(Name = "二级")]
        LevelTwo = 2,
        [Display(Name = "三级")]
        LevelThree = 3,
        [Display(Name = "四级")]
        LevelFour = 4,
        [Display(Name = "五级-不符合项")]
        LevelFive = 5,
    }

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
    public enum EvaluationTypeEnum
    {
        [Display(Name = "文件")]
        File,
        [Display(Name = "现场")]
        Scene
    }
    public class CommonEnums
    {
    }
}
