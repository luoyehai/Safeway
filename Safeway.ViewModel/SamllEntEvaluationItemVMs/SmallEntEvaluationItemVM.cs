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
using Safeway.Model.ExportTemplate;
using Microsoft.EntityFrameworkCore;
using Safeway.ViewModel.SmallEntEvaluationBaseVMs;
using Safeway.Model.Enterprise;
using Safeway.Model.Project;

namespace Safeway.ViewModel.SamllEntEvaluationItemVMs
{
    public partial class SmallEntEvaluationItemVM : BaseCRUDVM<SmallEntEvaluationItem>
    {
        public SmallEntEvaluationItemVM()
        {
        }
        public string ReportPath {
            get 
            { 
                 return Path.Combine(Directory.GetCurrentDirectory(),
                                    "wwwroot", "exportTemplate", "小微评审.xlsx");
            }
        
        }

        public SmallEntEvaluationBase EntEvaluationBase { get; set; }

        public SmallEntEvaluationBase_View EntEvaluationBaseView { get; set; }

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

        public async Task<bool> IsReportExisted(string baseId)
        {
            return await DC.Set<SmallEntEvaluationItem>().AnyAsync<SmallEntEvaluationItem>(x => x.SmallEntEvaluationBaseId.Equals(baseId));
        }

        public void CalculateEvaluationTotalScore(string baseId)
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

            var baseItem = DC.Set<SmallEntEvaluationBase>().Where(x => x.ID.Equals(Guid.Parse(baseId))).FirstOrDefault();
            baseItem.Score = totalScore.ToString();
            DC.SaveChanges();
        }

        public void CalculateEvaluationProgress(string baseId)
        {
            var items = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId.Equals(baseId)).ToList();
            // get evaluated counts
            var evaluatedCount = (decimal)items.Count(x => x.IsEvaluated == true);
            // get counts of items
            var itemCounts = (decimal)items.Count();
           
            var baseItem = DC.Set<SmallEntEvaluationBase>().Where(x => x.ID.Equals(Guid.Parse(baseId))).FirstOrDefault();
            baseItem.Progress = Math.Round(evaluatedCount / itemCounts * 100, 2).ToString();
            DC.SaveChanges();
        }

        public async Task<SmallEntEvaluationBase> GetSmallEntEvaluationBase(string baseId)
        {
            return DC.Set<SmallEntEvaluationBase>().FirstOrDefault(x => x.ID.Equals(Guid.Parse(baseId)));
        }

        public async Task<SmallEntEvaluationBase_View> GetSmallEntEvaluationBaseView(string baseId)
        {
            var item = DC.Set<SmallEntEvaluationBase>().FirstOrDefault(x => x.ID.Equals(Guid.Parse(baseId)));
            return new SmallEntEvaluationBase_View()
            {
                ID = item.ID,
                ProjectId = item.ProjectId,
                ProjectName = DC.Set<ProjectBasicInfo>().FirstOrDefault(x => x.ID.Equals(Guid.Parse(item.ProjectId))).ProjectName,
                EnterpriseId = item.EnterpriseId,
                EnterpriseName = DC.Set<EnterpriseBasicInfo>().FirstOrDefault(x => x.ID.Equals(Guid.Parse(item.EnterpriseId))).ComapanyName,
                EvaluationStartDate = item.EvaluationStartDate,
                EvaluateStartDateStr = item.EvaluationStartDate.ToShortDateFormatString(),
                EvaluationEndDate = item.EvaluationEndDate,
                EvaluateEndDateStr = item.EvaluationEndDate.ToShortDateFormatString(),
                EvaluationLeader = item.EvaluationLeader,
                ReportLeader = item.ReportLeader,
                ReportFileId = item.ReportFileId,
                EvaluationTeamMember = item.EvaluationTeamMember,
                Status = item.Status,
                ModuleOne = item.ModuleOne,
                ModuleTwo = item.ModuleTwo,
                ModuleThree = item.ModuleThree,
            };
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
                evaluationViewItem.AllMatched = item.AllMatched;
                evaluationViewItem.IsEvaluated = item.IsEvaluated;
                evaluationViewItem.DeductScore = 0;
                evaluationViewItem.ScoringMethod = item.ScoringMethod;
                evaluationViewItem.EvaluationType = item.EvaluationType;
                evaluationViewItem.UnMatchedItemDescription = string.Empty;
                evaluationViewItem.SmallEntEvaluationBaseId = item.SmallEntEvaluationBaseId;
                evaluationViewItems.Add(evaluationViewItem);
            });
            return evaluationViewItems;
        }

        public async Task<bool> SaveEvaluationItems(List<SmallEntEvaluationItemView> evaluationViewItems)
        {
            if (evaluationViewItems == null)
                return false;
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
                evaluationItem.AllMatched = item.AllMatched;
                evaluationItem.IsEvaluated = item.UnMatched || item.UnInvolved || item.AllMatched;
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

            // update total score
            CalculateEvaluationTotalScore(evaluationViewItems[0].SmallEntEvaluationBaseId);

            // update progress
            CalculateEvaluationProgress(evaluationViewItems[0].SmallEntEvaluationBaseId);

            return true;
        }
        public DataTable ReadExcelSheet(ISheet input, DataTable output)
        {
            IRow headerRow = input.GetRow(4);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                output.Columns.Add(cell.ToString());
            }

            for (int i = (input.FirstRowNum + 5); i <= input.LastRowNum; i++)
            {
                IRow row = input.GetRow(i);
                DataRow dataRow = output.NewRow();
                if (row == null)
                {
                    break;
                }
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                output.Rows.Add(dataRow);
            }
            return output;
        }

        public XSSFWorkbook ExportData(string id) 
        {
            var exportdata = DC.Set<SmEntEvaluationTemplate>().FromSql("SmEnt_Get_EvaluationTemplate @baseId = {0}", id).ToList();
            XSSFWorkbook template;
            ISheet templatesheet;
            DataTable templatedata;
            using (FileStream file = new FileStream(ReportPath, FileMode.Open, FileAccess.Read))
            {
                template = new XSSFWorkbook(file);
            }
            templatesheet = template.GetSheet("评分表");
            templatedata = new DataTable();
            //Read Sheet data
            templatedata = ReadExcelSheet(templatesheet, templatedata);

            //update datatable
            for (int i = 0; i < exportdata.Count(); i++)
            {
                for (int j = 0; j < templatedata.Rows.Count; j++)
                {
                    if (exportdata[i].LevelFourID.ToString().ToLower().Equals(templatedata.Rows[j][8].ToString().ToLower())) 
                    {
                        if (!string.IsNullOrEmpty(exportdata[i].UnMatchedItemDescription))
                        {
                            templatedata.Rows[j][6] = exportdata[i].UnMatchedItemDescription;
                        }
                        templatedata.Rows[j][7] = exportdata[i].ActualScore;
                    }
                }

            }
            //define format
            //set format
            XSSFFont myFont = (XSSFFont)template.CreateFont();
            myFont.FontHeightInPoints = (short)10.5;
            myFont.FontName = "宋体";
            //set style
            XSSFCellStyle borderedCellStyle = (XSSFCellStyle)template.CreateCellStyle();
            borderedCellStyle.SetFont(myFont);
            borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

            //set middle
            borderedCellStyle.Alignment = HorizontalAlignment.Center;
            borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

            borderedCellStyle.WrapText = true;
            //Insert into worksheet
            IRow row;
            ICell descriptioncell;
            ICell scorecell;
            for (int i = 0; i < templatedata.Rows.Count-1; i++)
            {
                row = templatesheet.GetRow(i+5);
                descriptioncell = row.CreateCell(6);
                scorecell = row.CreateCell(7);

                var des = templatedata.Rows[i][6].ToString();

                descriptioncell.SetCellValue(des.Contains("n") ? des.Replace("n",Environment.NewLine) :des);
                scorecell.SetCellValue(templatedata.Rows[i][7] == null || string.IsNullOrEmpty(templatedata.Rows[i][7].ToString()) ? 0 : Convert.ToDouble(templatedata.Rows[i][7]));

                descriptioncell.CellStyle = borderedCellStyle;
                scorecell.CellStyle = borderedCellStyle;
            }
            template = ExportUnmatchedItemsData(template, id);
            return template;
        }
        public XSSFWorkbook ExportUnmatchedItemsData(XSSFWorkbook input , string id)
        {
            var unMatchedData = DC.Set<SmEntEvaluationTemplate>().FromSql("SmEnt_Get_EvaUnmatchedTemplate @baseId = {0}", id).ToList();
            ISheet templatesheet = input.GetSheet("扣分项");
           // DataTable templatedata = new DataTable();

            XSSFFont myFont = (XSSFFont)input.CreateFont();
            myFont.FontHeightInPoints = (short)10.5;
            myFont.FontName = "宋体";
            //set style
            XSSFCellStyle borderedCellStyle = (XSSFCellStyle)input.CreateCellStyle();
            borderedCellStyle.SetFont(myFont);
            borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

            //set middle
            borderedCellStyle.Alignment = HorizontalAlignment.Center;
            borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

            borderedCellStyle.WrapText = true;

            IRow row;
            ICell levelOneCell;
            ICell levelTwoCell;
            ICell standardCell;
            ICell descriptioncell;
            ICell scorecell;
            for (int i = 0; i < unMatchedData.Count(); i++)
            {
                row = templatesheet.GetRow(i + 4);

                levelOneCell = row.CreateCell(0);
                levelTwoCell = row.CreateCell(1);
                standardCell = row.CreateCell(2);
                descriptioncell = row.CreateCell(3);
                scorecell = row.CreateCell(4);

                levelOneCell.SetCellValue(unMatchedData[i].LevelOneElement.ToString());
                levelTwoCell.SetCellValue(unMatchedData[i].LevelTwoElement.ToString());
                standardCell.SetCellValue(unMatchedData[i].ComplianceStandard.ToString());
                var des = unMatchedData[i].UnMatchedItemDescription.ToString();
                descriptioncell.SetCellValue(des.Contains("n") ? des.Replace("n", Environment.NewLine) : des);
                scorecell.SetCellValue(string.IsNullOrEmpty(unMatchedData[i].ActualScore.ToString()) ? 0 : Convert.ToDouble(unMatchedData[i].ActualScore));

                levelOneCell.CellStyle = borderedCellStyle;
                levelTwoCell.CellStyle = borderedCellStyle;
                standardCell.CellStyle = borderedCellStyle;
                descriptioncell.CellStyle = borderedCellStyle;
                scorecell.CellStyle = borderedCellStyle;
            }

            return input;
        }
    }

    public class SmallEntEvaluationItemView: SmallEntEvaluationItem
    {
        public string UnMatchedItemDescription { get; set; }
        public List<EnterpriseReviewElement> UnMatchedItems { get; set; }
        public List<SmallEntEvaluationUnMatchedItem> EvaluatedUnMatchedItems { get; set; }
    }

   

}
