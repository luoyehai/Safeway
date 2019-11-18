using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.Model.SmallEntEvaluation;
using Safeway.Model.EnterpriseReview;
using Safeway.Model.Common;
using Safeway.ViewModel.CommonClass;


namespace Safeway.ViewModel.SmallEntEvaluationBaseVMs
{
    public partial class SmallEntEvaluationBaseVM : BaseCRUDVM<SmallEntEvaluationBase>
    {

        public SmallEntEvaluationBaseVM()
        {
        }

        protected override void InitVM()
        {
            base.InitVM();
        }
        //Add all the relative elements into item table-Linq
        public void InsertElements(string baseId) 
        {
            var evaluationitemlist = new List<SmallEntEvaluationItem>();
           // var evaluationUnmatchedList = new List<SmallEntEvaluationUnMatchedItem>();
            //put EnterpriseReview item into small Ent Evaluation item
            //Get data from enterprise review element
             var orderdata = DC.Set<EnterpriseReviewElement>().Where(x => x.IsValid.Equals(true)).OrderBy(x => x.Level).OrderBy(x => x.Order);
            var data = orderdata.Where(x => x.Level== ElementLevelEnum.LevelFour).ToList();
            foreach (var obj in data) 
            {
                SmallEntEvaluationItem temp = new SmallEntEvaluationItem();
                temp.LevelFourID = obj.ID;
                temp.ComplianceStandard = obj.ElementName;
                temp.LevelFourOrder = obj.Order;
                //temp.LevelThreeElement = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == obj.ParentElementId).Select(x=> x.ElementName).FirstOrDefault();
                //temp.LevelThreeOrder = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == obj.ParentElementId).Select(x => x.Order).FirstOrDefault();
                temp.LevelThreeElement = orderdata.Where(x => x.ID.ToString() == obj.ParentElementId & x.Level==ElementLevelEnum.LevelThree).Select(x => x.ElementName).FirstOrDefault();
                temp.LevelThreeOrder = orderdata.Where(x => x.ID.ToString() == obj.ParentElementId & x.Level == ElementLevelEnum.LevelThree).Select(x => x.Order).FirstOrDefault();
                temp.CreateTime = DateTime.Now;
                temp.CreateTime = DateTime.Now;
                temp.ScoringMethod = obj.ScoringMethod;
                temp.StandardScore = obj.TotalScore;
                temp.DeductScore = 0;
                temp.ActualScore = obj.TotalScore;
                temp.SmallEntEvaluationBaseId = baseId;
                evaluationitemlist.Add(temp);

                ////Add temp Unmatched items
                //SmallEntEvaluationUnMatchedItem unmatchedtemp = new SmallEntEvaluationUnMatchedItem();
                //unmatchedtemp.SmallEntEvaluationBaseId = baseId;
                //unmatchedtemp.SmallEntEvaluationItemId = temp.ID.ToString();
                //unmatchedtemp.CreateTime = DateTime.Now;
                //evaluationUnmatchedList.Add(unmatchedtemp);
            }
            foreach (var o in evaluationitemlist) 
            { 
                var levelTwoId= DC.Set<EnterpriseReviewElement>().Where(x => x.ElementName == o.LevelThreeElement & x.Level == ElementLevelEnum.LevelThree).Select(x => x.ParentElementId).FirstOrDefault();
                o.LevelTwoElement = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelTwoId & x.Level == ElementLevelEnum.LevelTwo).Select(x => x.ElementName).FirstOrDefault();
                o.LevelTwoOrder = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelTwoId & x.Level == ElementLevelEnum.LevelTwo).Select(x => x.Order).FirstOrDefault();

                var levelOneId = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelTwoId & x.Level == ElementLevelEnum.LevelTwo).Select(x => x.ParentElementId).FirstOrDefault();
                o.LevelOneElement = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelOneId & x.Level == ElementLevelEnum.LevelOne).Select(x => x.ElementName).FirstOrDefault();
                o.LevelOneOrder = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelOneId & x.Level == ElementLevelEnum.LevelOne).Select(x => x.Order).FirstOrDefault();

            }

            //Insert into SmallEntEvaluationItem
            DC.Set<SmallEntEvaluationItem>().AddRange(evaluationitemlist);
            //Insert into SmallEntEvaluation Unmatched Item
           // DC.Set<SmallEntEvaluationUnMatchedItem>().AddRange(evaluationUnmatchedList);

            DC.SaveChanges();

            //return query;

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
        public List<ViewFormatClass> SearchUser(string keyword)
        {
            var query = DC.Set<FrameworkUserBase>()
                  .Where(x => x.Name.Contains(keyword)).Select(x => new ViewFormatClass { Text = x.Name, Value = x.Name }).ToList();
            return query;

        }
    }
}
