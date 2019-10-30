using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.ReviewTemp;


namespace Safeway.ViewModel.ReviewLevel2ElementVMs
{
    public partial class ReviewLevel2ElementSearcher : BaseSearcher
    {
        [Display(Name = "要素名称")]
        public String ElementName { get; set; }
        [Display(Name = "基本规范要求")]
        public String ElementStandard { get; set; }
        public List<ComboSelectListItem> AllReviewBasicElements { get; set; }

        [Display(Name = "一级要素")]
        public Guid? BasicElementId { get; set; }

        protected override void InitVM()
        {
            AllReviewBasicElements = DC.Set<ReviewBasicElement>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.ElementName);
        }

    }
}
