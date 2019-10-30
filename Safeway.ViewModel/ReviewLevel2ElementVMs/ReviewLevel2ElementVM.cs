using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewLevel2ElementVMs
{
    public partial class ReviewLevel2ElementVM : BaseCRUDVM<ReviewLevel2Element>
    {
        public List<ComboSelectListItem> AllReviewBasicElements { get; set; }

        public ReviewLevel2ElementVM()
        {
            SetInclude(x => x.ReviewBasicElement);
        }

        protected override void InitVM()
        {
            AllReviewBasicElements = DC.Set<ReviewBasicElement>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ElementName);
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
