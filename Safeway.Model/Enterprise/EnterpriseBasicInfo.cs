using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.Common;
using Safeway.Model.Evaluation;
namespace Safeway.Model.Enterprise
{
    public class EnterpriseBasicInfo : BasePoco
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid EnterpriseId { get; set; }
        [Display(Name = "公司名称")]
        [StringLength(300)]
        public string ComapanyName { get; set; }
        [Display(Name = "省份")]
        [StringLength(50)]
        public string Province { get; set; }
        [Display(Name = "市")]
        [StringLength(50)]
        public string City { get; set; }
        [Display(Name = "区")]
        [StringLength(200)]
        public string District { get; set; }
        [Display(Name = "街道")]
        [StringLength(300)]
        public string Street { get; set; }
        [Display(Name = "企业类型")]
        [StringLength(30)]
        public string CompanyType { get; set; }
        [Display(Name = "企业所属国家")]
        [StringLength(100)]
        public string ForeignCountry { get; set; }
        [Display(Name = "法定代表人")]
        [StringLength(100)]
        public string LegalRepresentative { get; set; }
        [Display(Name = "企业规模")]
        public CompanyScaleEnum? CompanyScale { get; set; }
        [Display(Name = "行业")]
        [StringLength(100)]
        public string Industry { get; set; }
        [Display(Name = "公司人数")]
        [StringLength(100)]
        public string NoofEmployees { get; set; }
        [Display(Name = "主要产品")]
        [StringLength(100)]
        public string MainProducts { get; set; }
        [Display(Name = "贸易方式")]
        public TermsofTradeEnum? TermsofTrade { get; set; }

        [Display(Name = "财务信息")]
        public EnterpriseFinanceInfo FinanceInfo { get; set; }

        [Display(Name = "商务信息")]
        public EnterpriseBusinessinfo EnterpriseBusinessinfo { get; set; }

        [Display(Name = "联系人信息")]
        public List<EnterpriseContact> EnterpriseContacts { get; set; }

        [Display(Name = "年收益")]
        public List<EnterpriserYearYield> EnterpriserYearYields { get; set; }

        //public NormalEntEvaluationTemplate NormalEntEvaluationTemplate { get; set; }

    }
}
