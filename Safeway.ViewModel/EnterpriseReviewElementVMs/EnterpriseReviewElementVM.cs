using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.EnterpriseReview;
using Safeway.Model.Common;

namespace Safeway.ViewModel.EnterpriseReviewElementVMs
{
    public partial class EnterpriseReviewElementVM : BaseCRUDVM<EnterpriseReviewElement>
    {
        
        public EnterpriseReviewElementVM()
        {
        }

        protected override void InitVM()
        {
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

        public List<EnterpriseReviewElement> GetParentElementList(int level)
        {
            if ((ElementLevelEnum)level == ElementLevelEnum.LevelOne)
                return null;
            return DC.Set<EnterpriseReviewElement>().Where(x => x.Level == (ElementLevelEnum)(level - 1)).ToList();
        }
    }
}
