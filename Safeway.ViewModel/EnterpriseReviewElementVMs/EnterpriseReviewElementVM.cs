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

        private List<TreeSelectListItem> GenerateTreeSelect()
        {
            var rootTreeSelectListItem = new TreeSelectListItem()
            {
                Id = "SmallEnt",
                Text = "企业安全生产标准化小微评审",
                Children = null
            };

            var treeSelectList = new List<TreeSelectListItem>();

            var elementList = DC.Set<EnterpriseReviewElement>().Where(x => x.IsValid.Equals(true)).ToList();
            elementList.ForEach(x =>
            {
                treeSelectList.Add(BuildTreeSelectListItem(x));
            });
            return treeSelectList;
        }

        public List<EnterpriseReviewElement> GetChildReivewElements(string parentElementId)
        {
            var elementList = DC.Set<EnterpriseReviewElement>().Where(e => e.ParentElementId == parentElementId).ToList();
            return elementList;
        }

        public TreeSelectListItem BuildTreeSelectListItem(EnterpriseReviewElement reviewElementItem)
        {
            var treeSelectListItem = new TreeSelectListItem()
            {
                Id = reviewElementItem.ID.ToString(),
                ParentId = reviewElementItem.ParentElementId.ToString(),
                Text = reviewElementItem.ElementName
            };
            var childTreeSelectList = new List<TreeSelectListItem>();
                var childElementList = GetChildReivewElements(reviewElementItem.ID.ToString());
                if (childElementList.Count() > 0)
                {
                    childElementList.ForEach(x =>
                    {
                        childTreeSelectList.Add(new TreeSelectListItem()
                        {
                            Id = x.ID.ToString(),
                            ParentId = x.ParentElementId.ToString(),
                            Text = x.ElementName
                        });
                    });
                    treeSelectListItem.Children = childTreeSelectList;
                }
            
            return treeSelectListItem;
        }

        public List<TreeSelectListItem> BuildTreeSelectList(List<EnterpriseReviewElement> reviewElementList)
        {
            var treeSelectList = new List<TreeSelectListItem>();
            reviewElementList.ForEach(e =>
            {
                var treeSelectListItem =
                    new TreeSelectListItem()
                    {
                        Id = e.ID.ToString(),
                        ParentId = e.ParentElementId.ToString(),
                        Text = e.ElementName
                    };
                var childTreeSelectList = new List<TreeSelectListItem>();
                var childElementList = GetChildReivewElements(e.ID.ToString());
                if(childElementList.Count() > 0)
                {
                    childElementList.ForEach(x =>
                    {
                        childTreeSelectList.Add(new TreeSelectListItem()
                        {
                            Id = x.ID.ToString(),
                            ParentId = x.ParentElementId.ToString(),
                            Text = x.ElementName
                        });
                    });
                    treeSelectListItem.Children = childTreeSelectList;
                }
            });
            return treeSelectList;
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
