using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace Safeway.Model.Enterprise
{
    public class EnterpriseContact : BasePoco
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Enterprise_Contact_Id { get; set; }

        //[ForeignKey("ID")]
        //public EnterpriseBasicInfo BasicInfo { get; set; } = new EnterpriseBasicInfo();
        [Display(Name = "部门")]
        [StringLength(50)]
        public string Dept { get; set; }
        [Display(Name = "职位")]
        [StringLength(50)]
        public string Position { get; set; }
        [Display(Name = "姓名")]
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "座机")]
        [StringLength(30)]
        public string Tele { get; set; }
        [Display(Name = "手机")]
        [StringLength(30)]
        public string MobilePhone { get; set; }
        [Display(Name = "邮箱")]
        [StringLength(30)]
        public string Email { get; set; }

        [Display(Name = "企业名称")]
        public Guid  EnterpriseBasicInfoId { get; set; }
        public EnterpriseBasicInfo EnterpriseBasicInfo { get; set; }
    }
}
