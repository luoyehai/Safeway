using Safeway.Model.SmallEntEvaluation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WalkingTec.Mvvm.Core;
using Safeway.Model.EnterpriseReview;

namespace Safeway.ViewModel.SamllEntEvaluationItemVMs
{
    public partial class SmallEntEvaluationItemVM : BaseCRUDVM<SmallEntEvaluationItem>
    {
        public SmallEntEvaluationItemVM()
        {
        }

        protected override void InitVM()
        {
            base.InitVM();
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

        public IList<SmallEntEvaluationItemView> GetEvaluationItems(string baseId,string tabName)
        {
            
            var evaluationViewItems = new List<SmallEntEvaluationItemView>();
            var evaluationItems = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId.Equals(baseId) && x.LevelOneElement.Equals(tabName)).ToList();
            evaluationItems.ForEach(item =>
            {
                var unMatchedItems = DC.Set<EnterpriseReviewElement>().Where(i => i.ParentElementId.Equals(item.LevelFourID.ToString()) && i.IsValid.Equals(true)).OrderBy(i => i.Order).ToList();
                unMatchedItems.ForEach(x => x.IsValid = false);
                var evaluationViewItem = new SmallEntEvaluationItemView();
                evaluationViewItem.UnMatchedItems = unMatchedItems;
                evaluationViewItem.EvaluatedUnMatchedItems = new List<SmallEntEvaluationUnMatchedItem>();
                evaluationViewItem.ID = item.ID;
                evaluationViewItem.LevelOneElement = item.LevelOneElement;
                evaluationViewItem.LevelTwoElement = item.LevelTwoElement;
                evaluationViewItem.LevelThreeElement = item.LevelThreeElement;
                evaluationViewItem.LevelFourID = item.LevelFourID;
                evaluationViewItem.ComplianceStandard = item.ComplianceStandard;
                evaluationViewItem.BasicRuleRequirement = item.BasicRuleRequirement;
                evaluationViewItem.StandardScore = item.StandardScore;
                evaluationViewItem.EvaluationDescription = item.EvaluationDescription;
                evaluationViewItem.AssignTo = item.AssignTo;
                evaluationViewItem.UnMatched = item.UnMatched;
                evaluationViewItem.UnInvolved = item.UnInvolved;
                evaluationViewItem.ActualScore = item.ActualScore;
                evaluationViewItem.DeductScore = 0;
                evaluationViewItem.EvaluationType = item.EvaluationType;
                evaluationViewItem.UnMatchedItemDescription = string.Empty;
                evaluationViewItem.SmallEntEvaluationBaseId = item.SmallEntEvaluationBaseId;
                evaluationViewItems.Add(evaluationViewItem);
            });
            return evaluationViewItems;
        }

        public bool SaveEvaluationItems(List<SmallEntEvaluationItemView> evaluationViewItems)
        {
            if (evaluationViewItems.Count() == 0)
                return false;
            var evaluationItems = DC.Set<SmallEntEvaluationItem>()
                .Where(x => x.LevelOneElement.Equals(evaluationViewItems[0].LevelOneElement) && x.SmallEntEvaluationBaseId.Equals(evaluationViewItems[0].SmallEntEvaluationBaseId)).ToList();

            evaluationViewItems.ForEach(item =>
            {
                var evaluationItem = evaluationItems.Where(x => x.ID.Equals(item.ID)).FirstOrDefault();
                //evaluationItem.ID = item.ID;
                evaluationItem.LevelOneElement = item.LevelOneElement;
                evaluationItem.LevelTwoElement = item.LevelTwoElement;
                evaluationItem.LevelThreeElement = item.LevelThreeElement;
                evaluationItem.LevelFourID = item.LevelFourID;
                evaluationItem.ComplianceStandard = item.ComplianceStandard;
                evaluationItem.BasicRuleRequirement = item.BasicRuleRequirement;
                evaluationItem.StandardScore = item.StandardScore;
                evaluationItem.EvaluationDescription = item.EvaluationDescription;
                evaluationItem.AssignTo = item.AssignTo;
                evaluationItem.UnMatched = item.UnMatched;
                evaluationItem.UnInvolved = item.UnInvolved;
                evaluationItem.ActualScore = item.ActualScore;
                evaluationItem.EvaluationType = item.EvaluationType;
                evaluationItem.SmallEntEvaluationBaseId = item.SmallEntEvaluationBaseId;
                evaluationItem.UpdateTime = DateTime.Now;
                DC.Set<SmallEntEvaluationItem>().Update(evaluationItem);
                DC.SaveChanges();
            });
            return true;
        }
    }

    public class SmallEntEvaluationItemView: SmallEntEvaluationItem
    {
        public string UnMatchedItemDescription { get; set; }
        public decimal DeductScore { get; set; }
        public IList<EnterpriseReviewElement> UnMatchedItems { get; set; }
        public IList<SmallEntEvaluationUnMatchedItem> EvaluatedUnMatchedItems { get; set; }
    }

}
