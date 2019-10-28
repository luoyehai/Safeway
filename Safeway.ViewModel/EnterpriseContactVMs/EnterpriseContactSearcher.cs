using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseContactVMs
{
    public partial class EnterpriseContactSearcher : BaseSearcher
    {
        [Display(Name = "部门")]
        public String Dept { get; set; }
        [Display(Name = "职位")]
        public String Position { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "座机")]
        public String Tele { get; set; }
        public String SchoolName { get; set; }
        [Display(Name = "手机")]
        public String MobilePhone { get; set; }
        [Display(Name = "邮箱")]
        public String Email { get; set; }

        protected override void InitVM()
        {
        }

    }
}
