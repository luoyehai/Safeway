using Safeway.Model.SmallEntEvaluation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WalkingTec.Mvvm.Core;
using Safeway.Model.EnterpriseReview;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Safeway.ViewModel.CommonClass;



namespace Safeway.ViewModel.SamllEntEvaluationItemVMs
{
    public partial class SmallEntEvaluationItemVM : BaseCRUDVM<SmallEntEvaluationItem>
    {
        public SmallEntEvaluationItemVM()
        {
        }

        public SmallEntEvaluationBase EntEvaluationBase { get; set; }

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

        public async Task<string> CalculateEvaluationScore(string baseId)
        {
            var items = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId.Equals(baseId)).ToList();
            // get standard total score, should be 600
            var standardTotalScore = items.Sum(x => x.StandardScore);
            // get uninvolved total score
            var uninvolvedTotalScore = items.Where(x => x.UnInvolved == true).Sum(x => x.StandardScore);
            // get actual total score
            var actualTotalScore = items.Where(x => x.UnInvolved == false).Sum(x => x.ActualScore);
            // caculate total score
            var totalScore = Math.Round(actualTotalScore / (standardTotalScore - uninvolvedTotalScore) * 100, 2);
            return totalScore.ToString();
        }

        public async Task<SmallEntEvaluationBase> GetSmallEntEvaluationBase(string baseId)
        {
            return DC.Set<SmallEntEvaluationBase>().FirstOrDefault(x => x.ID.Equals(Guid.Parse(baseId)));
        }

        public async Task<List<ViewFormatClass>> GetLevelTwoEvaluationItems(string baseId, string tabName)
        {
            var items = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId.Equals(baseId) && x.LevelOneElement.Equals(tabName))
                .Select(x => new ViewFormatClass() { Text =  x.LevelTwoElement, Value = x.LevelTwoOrder.ToString() }).Distinct();
            return items.OrderBy(x => x.Value).Select(x => new ViewFormatClass() { Text = x.Text, Value = $"{x.Value}.{x.Text}" }).ToList();
        }

        public async Task<List<SmallEntEvaluationItemView>> GetEvaluationItems(string baseId,string tabName)
        {
            var evaluationViewItems = new List<SmallEntEvaluationItemView>();
            var evaluationItems = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId.Equals(baseId) && x.LevelOneElement.Equals(tabName))
                .OrderBy(x => x.LevelTwoOrder).ThenBy(x => x.LevelThreeOrder).ThenBy(x => x.LevelFourOrder).ToList();
            evaluationItems.ForEach(item =>
            {
                var evaluatedUnMatchedItems = DC.Set<SmallEntEvaluationUnMatchedItem>()
                .Where(i => i.SmallEntEvaluationItemId.Equals(item.ID.ToString())).ToList();

                var unMatchedItems = DC.Set<EnterpriseReviewElement>()
                .Where(i => i.ParentElementId.Equals(item.LevelFourID.ToString()) && i.IsValid.Equals(true)).OrderBy(i => i.Order).ToList();

                unMatchedItems.ForEach(x =>
                {
                    x.IsValid = evaluatedUnMatchedItems.Any(i => i.ReviewElementId == x.ID.ToString()) ? true : false;
                });

                var evaluationViewItem = new SmallEntEvaluationItemView();
                evaluationViewItem.UnMatchedItems = unMatchedItems;
                evaluationViewItem.EvaluatedUnMatchedItems = evaluatedUnMatchedItems ?? new List<SmallEntEvaluationUnMatchedItem>();
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
                evaluationViewItem.ScoringMethod = item.ScoringMethod;
                evaluationViewItem.EvaluationType = item.EvaluationType;
                evaluationViewItem.UnMatchedItemDescription = string.Empty;
                evaluationViewItem.SmallEntEvaluationBaseId = item.SmallEntEvaluationBaseId;
                evaluationViewItems.Add(evaluationViewItem);
            });
            return evaluationViewItems;
        }

        public async Task<List<SmallEntEvaluationItemView>> GetEvaluationItems(string baseId, string tabName,string level2Name)
        {
            var evaluationViewItems = new List<SmallEntEvaluationItemView>();
            var evaluationItems = DC.Set<SmallEntEvaluationItem>()
                .Where(x => x.SmallEntEvaluationBaseId.Equals(baseId) && x.LevelOneElement.Equals(tabName) && x.LevelTwoElement.Equals(level2Name))
                .OrderBy(x => x.LevelTwoOrder).ThenBy(x => x.LevelThreeOrder).ThenBy(x => x.LevelFourOrder).ToList();
            evaluationItems.ForEach(item =>
            {
                var evaluatedUnMatchedItems = DC.Set<SmallEntEvaluationUnMatchedItem>()
                .Where(i => i.SmallEntEvaluationItemId.Equals(item.ID.ToString())).ToList();

                var unMatchedItems = DC.Set<EnterpriseReviewElement>()
                .Where(i => i.ParentElementId.Equals(item.LevelFourID.ToString()) && i.IsValid.Equals(true)).OrderBy(i => i.Order).ToList();

                unMatchedItems.ForEach(x =>
                {
                    x.IsValid = evaluatedUnMatchedItems.Any(i => i.ReviewElementId == x.ID.ToString()) ? true : false;
                });

                var evaluationViewItem = new SmallEntEvaluationItemView();
                evaluationViewItem.UnMatchedItems = unMatchedItems;
                evaluationViewItem.EvaluatedUnMatchedItems = evaluatedUnMatchedItems ?? new List<SmallEntEvaluationUnMatchedItem>();
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
                evaluationViewItem.ScoringMethod = item.ScoringMethod;
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
                // update evaluation items
                var evaluationItem = evaluationItems.Where(x => x.ID.Equals(item.ID)).FirstOrDefault();
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
                evaluationItem.DeductScore = item.DeductScore;
                evaluationItem.ActualScore = item.ActualScore;
                evaluationItem.EvaluationType = item.EvaluationType;
                evaluationItem.SmallEntEvaluationBaseId = item.SmallEntEvaluationBaseId;
                evaluationItem.UpdateTime = DateTime.Now;
                DC.Set<SmallEntEvaluationItem>().Update(evaluationItem);
                DC.SaveChanges();

                // delete existed unmathed item
                var removedUnMatchedEvaluationItems = DC.Set<SmallEntEvaluationUnMatchedItem>()
                .Where(i => i.SmallEntEvaluationItemId.Equals(item.ID.ToString()));
                DC.Set<SmallEntEvaluationUnMatchedItem>().RemoveRange(removedUnMatchedEvaluationItems);
                DC.SaveChanges();

                // save evaluated unmatched items
                item.EvaluatedUnMatchedItems.ForEach(i =>
                {
                    i.SmallEntEvaluationItemId = item.ID.ToString();
                    i.SmallEntEvaluationBaseId = item.SmallEntEvaluationBaseId;
                    DC.Set<SmallEntEvaluationUnMatchedItem>().AddAsync(i);
                });
                DC.SaveChanges();
            });
            
            return true;
        }

        public XSSFWorkbook ExportData(string id)
        {
            var exportdata = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId == id).OrderBy(x => x.LevelOneOrder)
                .ThenBy(x => x.LevelTwoOrder).ThenBy(x => x.LevelThreeOrder).ThenBy(x => x.LevelFourOrder).ToList();
           // var result = "";
            var reportpath = Path.Combine(Directory.GetCurrentDirectory(),
                                    "wwwroot", "exportTemplate", "小微评审.xlsx");
            var memoryStream = new MemoryStream();
            XSSFWorkbook hssfwb;
            FileStream file = new FileStream(reportpath, FileMode.Open, FileAccess.Read);
            
            hssfwb = new XSSFWorkbook(file);
            ISheet sheet = hssfwb.GetSheetAt(0);
            IRow row;
            ICell descriptioncell;
            ICell scorecell;
            for (int i = 0; i < exportdata.Count(); i++) 
            {
                row = sheet.GetRow(i+5);
                descriptioncell = row.CreateCell(6);
                scorecell = row.CreateCell(7);

                descriptioncell.SetCellValue(exportdata[i].ScoringMethod);
                scorecell.SetCellValue(Convert.ToDouble(exportdata[i].ActualScore));
            }
            return hssfwb;
            

            //using (var export = new MemoryStream())
            //{
            //    HttpResponse.Clear();
            //    hssfwb.Write(export);
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("Content-Disposition", string.Format("attachment;filename=小微企业安全生产标准化评分.xlsx"));
            //    Response.BinaryWrite(export.ToArray());
            //    Response.End();
            //}
            //string sFileName = @"小微企业安全生产标准化评分.xlsx";
            //using (var fileStream = new FileStream(reportpath, FileMode.Open))
            //{
            //    fileStream.CopyTo(memoryStream);
            //}
            //memoryStream.Position = 0;
            //return "s"; 
        }
    }

    public class SmallEntEvaluationItemView: SmallEntEvaluationItem
    {
        public string UnMatchedItemDescription { get; set; }
        public List<EnterpriseReviewElement> UnMatchedItems { get; set; }
        public List<SmallEntEvaluationUnMatchedItem> EvaluatedUnMatchedItems { get; set; }
    }

   

}
