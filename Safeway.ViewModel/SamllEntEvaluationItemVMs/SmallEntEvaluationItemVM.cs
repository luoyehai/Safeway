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
            
            return true;
        }
        public XSSFWorkbook OExportData(string id)
        {
            XSSFWorkbook template;
            ISheet templatesheet;
            DataTable templatedata;
            //Get the data form db
            //var exportdatas = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId == id)
            //             .Where(x => x.SmallEntEvaluationBaseId == id).OrderBy(x => x.LevelOneOrder)
            //             .ThenBy(x => x.LevelTwoOrder).ThenBy(x => x.LevelThreeOrder).ThenBy(x => x.LevelFourOrder).ToList();
            //var unmatcheddatas = DC.Set<SmallEntEvaluationUnMatchedItem>().Where(x => x.SmallEntEvaluationBaseId == id)
            //             .Where(x => x.SmallEntEvaluationBaseId == id).ToList();

            //var binddata = (from item in exportdatas
            //                join unmatch in unmatcheddatas
            //                on item.ID equals new Guid (unmatch.SmallEntEvaluationItemId)
            //                where item.SmallEntEvaluationBaseId == id
            //                select new { item.ID, item.ComplianceStandard, item.ScoringMethod, item.ActualScore, unmatch.UnMatchedItemDescription, unmatch.Deduction }).ToList();
            //var binddata = (from items in DC.Set<SmallEntEvaluationItem>()
            //join unmatcheditems in DC.Set<SmallEntEvaluationUnMatchedItem>()
            //on items.ID equals new Guid(unmatcheditems.SmallEntEvaluationItemId)
            //where items.SmallEntEvaluationBaseId == id
            //orderby items.LevelOneOrder, items.LevelTwoOrder,items.LevelThreeOrder,items.LevelFourOrder
            //select new { items.ID, items.ComplianceStandard, items.ScoringMethod, items.ActualScore, unmatcheditems.UnMatchedItemDescription, unmatcheditems.Deduction }).ToList();

            //var binddata = exportdatas.Join(unmatcheddatas, exportdata => exportdata.ID,) 
            var exportdata = DC.Set<SmEntEvaluationTemplate>().FromSql("SmEnt_Get_EvaluationTemplate @baseId = {0}", id).ToList();
            //read datatable from template
            using (FileStream file = new FileStream(ReportPath, FileMode.Open, FileAccess.Read))
            {
                template = new XSSFWorkbook(file);
            }
            templatesheet = template.GetSheet("评分中间表");
            templatedata = new DataTable();
            //Read Sheet data
            templatedata = ReadExcelSheet(templatesheet, templatedata);
            //for (int i = 0; i < templatedata.Rows.Count; i++) 
            //{ 
            //    for (int j = 0; j < exportdata.Count(); j++) 
            //    {
            //        if (templatedata.Rows[i][3].ToString() == exportdata[j].ComplianceStandard) 
            //        {
            //            templatedata.Rows[i][6] = exportdata[j].UnMatchedItemDescription;
            //            templatedata.Rows[i][7] = exportdata[j].Deduction;
            //        }
            //    }                        
            //}

            for (int i = 0; i < templatedata.Rows.Count -1; i++)
            {
                if (templatedata.Rows[i][3].ToString().Equals(templatedata.Rows[i + 1][3].ToString()))
                {
                    if (templatedata.Rows[i][5].ToString().Equals(templatedata.Rows[i + 1][5].ToString()))
                    {
                        templatedata.Rows[i + 1][7] = "0";
                    }
                }
            
            }

            for (int i = 0; i < exportdata.Count(); i++) 
            {
                for (int j = 0; j < templatedata.Rows.Count; j++)
                {
                    if (exportdata[i].ComplianceStandard == templatedata.Rows[j][3].ToString())
                    {
                        if (!string.IsNullOrEmpty(templatedata.Rows[j][7].ToString()))
                        {                   
                            j++;
                        }
                        else 
                        {
                            if (!string.IsNullOrEmpty(exportdata[i].UnMatchedItemDescription)) 
                            {
                                templatedata.Rows[j][6] = exportdata[i].UnMatchedItemDescription;
                            }                           
                            templatedata.Rows[j][7] = exportdata[i].ActualScore;
                        }
                    }
                }
            }
            //insert into template
            ISheet EvaluationSheet = template.GetSheet("打印评分表");
            IRow row;
            ICell descriptioncell;
            ICell scorecell;
            for (int i = 5; i < templatedata.Rows.Count; i++)
            {
                row = EvaluationSheet.GetRow(i);
                descriptioncell = row.CreateCell(6);
                scorecell = row.CreateCell(7);

                descriptioncell.SetCellValue(templatedata.Rows[i-5][6].ToString());
                scorecell.SetCellValue(templatedata.Rows[i - 5][7] == null || string.IsNullOrEmpty(templatedata.Rows[i - 5][7].ToString()) ? 0:Convert.ToDouble(templatedata.Rows[i-5][7]));
            }
            return template;

        }
        public XSSFWorkbook ExportDataOld(string id)
        {
            var exportdata = DC.Set<SmallEntEvaluationItem>().Where(x => x.SmallEntEvaluationBaseId == id).OrderBy(x => x.LevelOneOrder)
                .ThenBy(x => x.LevelTwoOrder).ThenBy(x => x.LevelThreeOrder).ThenBy(x => x.LevelFourOrder).ToList();

            var memoryStream = new MemoryStream();
            XSSFWorkbook hssfwb;
            FileStream file = new FileStream(ReportPath, FileMode.Open, FileAccess.Read);
            hssfwb = new XSSFWorkbook(file);
            ISheet sheet = hssfwb.GetSheetAt(0);
            //set format
            HSSFFont myFont = (HSSFFont)hssfwb.CreateFont();
            myFont.FontHeightInPoints = (short)10.5;
            myFont.FontName = "宋体";
            //set style
            HSSFCellStyle borderedCellStyle = (HSSFCellStyle)hssfwb.CreateCellStyle();
            borderedCellStyle.SetFont(myFont);
            borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
            borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
            borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
            borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
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
            for (int i = 5; i < templatedata.Rows.Count; i++)
            {
                row = templatesheet.GetRow(i);
                descriptioncell = row.CreateCell(6);
                scorecell = row.CreateCell(7);

                var des = templatedata.Rows[i - 5][6].ToString();

                descriptioncell.SetCellValue(des.Contains("n") ? des.Replace("n",Environment.NewLine) :des);
                scorecell.SetCellValue(templatedata.Rows[i - 5][7] == null || string.IsNullOrEmpty(templatedata.Rows[i - 5][7].ToString()) ? 0 : Convert.ToDouble(templatedata.Rows[i - 5][7]));

                descriptioncell.CellStyle = borderedCellStyle;
                scorecell.CellStyle = borderedCellStyle;
            }
            return template;
        }
    }
    public class SmallEntEvaluationItemView: SmallEntEvaluationItem
    {
        public string UnMatchedItemDescription { get; set; }
        public List<EnterpriseReviewElement> UnMatchedItems { get; set; }
        public List<SmallEntEvaluationUnMatchedItem> EvaluatedUnMatchedItems { get; set; }
    }

   

}
