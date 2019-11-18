using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Safeway.Model.EnterpriseReview;
using Safeway.Model.Common;


namespace Safeway.ViewModel.EnterpriseReviewElementVMs
{
    public partial class EnterpriseReviewElementListVM : BasePagedListVM<EnterpriseReviewElement_View, EnterpriseReviewElementSearcher>
    {
        public List<TreeSelectListItem> ElementList = new List<TreeSelectListItem>();
        public EnterpriseReviewElementListVM()
        {
        }

        protected override void InitListVM()
        {
            base.InitListVM();
            DC.Set<EnterpriseReviewElement>().Where(x => x.Level == ElementLevelEnum.LevelOne && x.IsValid.Equals(true)).OrderBy(x => x.Order).ToList().ForEach(x =>
            {
                ElementList.Add(new TreeSelectListItem()
                {
                    Id = x.ID.ToString(),
                    Text = $"{x.Order}.{x.ElementName}",
                    Children = GenerateChildTreeSelectItems(x.ID.ToString())
                });
            });
        }

        public List<TreeSelectListItem> GenerateChildTreeSelectItems(string parentElementId)
        {
            var childTreeSelectList = new List<TreeSelectListItem>();
            var childElementList = DC.Set<EnterpriseReviewElement>().Where(e => e.ParentElementId == parentElementId && e.IsValid.Equals(true)).OrderBy(x => x.Order).ToList();
            if (childElementList.Count() > 0)
            {
                childElementList.ForEach(x =>
                {
                    var treeSelectListItem = new TreeSelectListItem()
                    {
                        Id = x.ID.ToString(),
                        Text = $"{x.Order}.{x.ElementName}"
                    };
                    if ((int)x.Level < 4)
                        treeSelectListItem.Children = GenerateChildTreeSelectItems(x.ID.ToString());
                    childTreeSelectList.Add(treeSelectListItem);
                });
            }
            return childTreeSelectList;
        }


        protected override List<GridAction> InitGridAction()
        {

            return new List<GridAction>
            {
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Create, "新建","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Edit, "修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Delete, "删除", "",dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Details, "详细","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.BatchEdit, "批量修改","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.BatchDelete, "批量删除","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.Import, "导入","", dialogWidth: 800),
                this.MakeStandardAction("EnterpriseReviewElement", GridActionStandardTypesEnum.ExportExcel, "导出",""),
            };
        }

        protected override IEnumerable<IGridColumn<EnterpriseReviewElement_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterpriseReviewElement_View>>{
                this.MakeGridHeader(x => x.Level, width: 100),
                this.MakeGridHeader(x => x.ElementName),
                this.MakeGridHeader(x => x.Order, width: 100),
                this.MakeGridHeader(x => x.TotalScore, width: 100),
                this.MakeGridHeader(x => x.EvaluationType, width: 100),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterpriseReviewElement_View> GetSearchQuery()
        {
            var query = DC.Set<EnterpriseReviewElement>()
                .CheckContain(Searcher.ElementName, x=>x.ElementName)
                .CheckEqual(Searcher.Level, x=>x.Level)
                .CheckEqual(Searcher.ParentElementId, x => x.ParentElementId)
                .Select(x => new EnterpriseReviewElement_View
                {
				    ID = x.ID,
                    ElementName = x.ElementName,
                    Level = x.Level,
                    Order = x.Order,
                    TotalScore = x.TotalScore,
                    EvaluationType = x.EvaluationType
                })
                .OrderBy(x => x.Order);
            return query;
        }
    }

    
    public class EnterpriseReviewElement_View : EnterpriseReviewElement{

    }
}
