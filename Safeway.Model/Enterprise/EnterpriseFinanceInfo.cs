using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.Enterprise
{
    public class EnterpriseFinanceInfo : BasePoco
    {
        [Display(Name = "统一社会信用代码")]
        [StringLength(50)]
        public string UnifiedSocialCreditCode { get; set; }

        [Display(Name = "单位地址")]
        [StringLength(50)]
        public string Company_Address { get; set; }

        [Display(Name = "电话号码")]
        [StringLength(50)]
        public string Tele_Number { get; set; }

        [Display(Name = "开户银行")]
        [StringLength(50)]
        public string Bank { get; set; }

        [Display(Name = "银行账户")]
        [StringLength(50)]
        public string Account { get; set; }

        [Display(Name = "发票接收人")]
        [StringLength(50)]
        public string CustomerReceiptReceiver { get; set; }

        [Display(Name = "企业名称")]
        public Guid EnterpriseBasicId { get; set; }
        //public EnterpriseBasicInfo BasicInfo { get; set; }
    }
}
