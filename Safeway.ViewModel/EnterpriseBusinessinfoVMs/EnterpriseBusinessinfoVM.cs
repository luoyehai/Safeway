using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.Enterprise;


namespace Safeway.ViewModel.EnterpriseBusinessinfoVMs
{
    public partial class EnterpriseBusinessinfoVM : BaseCRUDVM<EnterpriseBusinessinfo>
    {

        public EnterpriseBusinessinfoVM()
        {
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }
        public void DoAdd(EnterpriseBusinessinfo bussinessinfo)
        {
            DC.Set<EnterpriseBusinessinfo>().Add(bussinessinfo);
            DC.SaveChanges();
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
