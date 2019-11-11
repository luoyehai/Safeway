using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseFinanceInfoVMs
{
    public partial class EnterpriseFinanceInfoVM : BaseCRUDVM<EnterpriseFinanceInfo>
    {
        public List<ComboSelectListItem> AllBasicInfos { get; set; }

        public EnterpriseFinanceInfoVM()
        {
            //SetInclude(x => x.BasicInfo);
        }

        protected override void InitVM()
        {
            AllBasicInfos = DC.Set<EnterpriseBasicInfo>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ComapanyName);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }
       

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
