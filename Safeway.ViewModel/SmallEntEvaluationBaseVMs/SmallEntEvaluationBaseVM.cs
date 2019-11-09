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
            //put EnterpriseReview item into small Ent Evaluation item
            //Get data from enterprise review element
            var data = DC.Set<EnterpriseReviewElement>().Where(x => x.Level== ElementLevelEnum.LevelFour).ToList();
            foreach (var obj in data) 
            {
                SmallEntEvaluationItem temp = new SmallEntEvaluationItem();
                temp.LevelFourID = obj.ID;
                temp.ComplianceStandard = obj.ElementName;
                temp.LevelThreeElement = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == obj.ParentElementId).Select(x=> x.ElementName).FirstOrDefault();
                temp.CreateTime = DateTime.Now;
                temp.StandardScore = obj.TotalScore;
                temp.SmallEntEvaluationBaseId = baseId;
                evaluationitemlist.Add(temp);
            }
            foreach (var o in evaluationitemlist) 
            { 
                var levelTwoId= DC.Set<EnterpriseReviewElement>().Where(x => x.ElementName == o.LevelThreeElement).Select(x => x.ParentElementId).FirstOrDefault();
                o.LevelTwoElement = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelTwoId).Select(x => x.ElementName).FirstOrDefault();

                var levelOneId = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelTwoId).Select(x => x.ParentElementId).FirstOrDefault();
                o.LevelOneElement = DC.Set<EnterpriseReviewElement>().Where(x => x.ID.ToString() == levelOneId).Select(x => x.ElementName).FirstOrDefault();

            }
            //Insert into SmallEntEvaluationItem
            DC.Set<SmallEntEvaluationItem>().AddRange(evaluationitemlist);
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
    }
}
