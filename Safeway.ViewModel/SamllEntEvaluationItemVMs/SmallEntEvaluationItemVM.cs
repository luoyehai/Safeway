using Safeway.Model.SmallEntEvaluation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WalkingTec.Mvvm.Core;
using Safeway.Model.EnterpriseReview;

namespace Safeway.ViewModel.SamllEntEvaluationItemVMs
{
    public partial class SmallEntEvaluationItemVM : BaseVM
    {
        public SmallEntEvaluationItemVM()
        {
        }

        public IList<SmallEntEvaluationItemView> GetEvaluationItems(string baseId)
        {
            var evaluationViewItem = new SmallEntEvaluationItemView();
            var evaluationViewItems = new List<SmallEntEvaluationItemView>();
            var evaluationItems = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId.Equals(baseId)).ToList();
            evaluationItems.ForEach(item =>
            {
                var unMatchedItems = DC.Set<EnterpriseReviewElement>().Where(i => i.ParentElementId.Equals(item.LevelFourID)).ToList();
                evaluationViewItem.UnMatchedItems = unMatchedItems;
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
                evaluationViewItem.EvaluationType = item.EvaluationType;
                evaluationViewItem.SmallEntEvaluationBaseId = item.SmallEntEvaluationBaseId;
            });
            return evaluationViewItems;
        }
    }

    public class SmallEntEvaluationItemView: SmallEntEvaluationItem
    {
        public IList<EnterpriseReviewElement> UnMatchedItems { get; set; }
        public IList<SmallEntEvaluationUnMatchedItem> EvaluatedUnMatchedItems { get; set; }
    }

}
