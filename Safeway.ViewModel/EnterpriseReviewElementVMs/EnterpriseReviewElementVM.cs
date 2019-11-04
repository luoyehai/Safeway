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
        public List<ComboSelectListItem> ParentElementList { get; set; }

        public List<TreeSelectListItem> TreeElementList;

        public EnterpriseReviewElementVM()
        {
            //var query = DC.Set<EnterpriseReviewElement>().Where(x => x.Category == Entity.Category && x.Level == Entity.Level);
            //ParentElementList = new List<ComboSelectListItem>();
            //foreach (var ele in query)
            //{
            //    ParentElementList.Add(
            //        new ComboSelectListItem()
            //        {
            //            Text = ele.ElementName,
            //            Value = ele.ID.ToString()
            //        });
            //}
        }

        private void GenerateElementTree()
        {
            var rootTreeSelectListItem = new TreeSelectListItem()
            {
                Id = "SmallEnt",
                Text = "企业安全生产标准化小微评审",
                Children = null
            };

            var childTreeSelectListItem = new List<TreeSelectListItem>();
            var elementList = DC.Set<EnterpriseReviewElement>().Where(x => x.Level == ElementLevelEnum.LevelOne && x.Category == ReviewTypeEnum.SmallEnterpriseReivew).ToList();
            elementList.ForEach(x =>
            {
                // add level one element
                childTreeSelectListItem.Add(new TreeSelectListItem()
                {
                    Id = x.ID.ToString(),
                    ParentId = rootTreeSelectListItem.Id,
                    Text = x.ElementName,
                    //Children = DC.Set<EnterpriseReviewElement>().Where(m => m.ParentElementId == x.ID).ToList()
                }); ;
            });  
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

        public IQueryable<EnterpriseReviewElement> GetEnterpriseReviewElements(ReviewTypeEnum reviewCategory)
        {
            return DC.Set<EnterpriseReviewElement>().Where(x => x.Category == reviewCategory);
        }
    }
}
