using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Safeway.ViewModel.SamllEntEvaluationItemVMs;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using System.IO;

namespace Safeway.Controllers
{
    [AllowAnonymous]
    public class SmallEntEvaluationItemController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        #region 小微评审
        [ActionDescription("查看报告")]
        public IActionResult ViewReport(string id)
        {
            var vm = CreateVM<SmallEntEvaluationItemVM>();
            var entEvaluationBase = vm.GetSmallEntEvaluationBase(id);
            vm.EntEvaluationBase = entEvaluationBase.Result;
            ViewData["ID"]= id;
            return PartialView(vm);
        }

        [ActionDescription("查看任务")]
        public IActionResult ViewTask(string id)
        {
            var vm = CreateVM<SmallEntEvaluationItemVM>();
            var entEvaluationBase = vm.GetSmallEntEvaluationBase(id);
            vm.EntEvaluationBase = entEvaluationBase.Result;
            ViewData["ID"] = id;
            //LoginUserInfo.Name
            return PartialView(vm);
        }

        
        public async Task<JsonResult> GetLevelTwoEvaluationItems(SmallEntEvaluationItemVM vm, string id, string tab)
        {
            var items = await vm.GetLevelTwoEvaluationItems(id, tab);
            return Json(items);
        }

        public async Task<JsonResult> GetEvaluationItem(SmallEntEvaluationItemVM vm, string id,string tab)
        {
            var items = await vm.GetEvaluationItems(id, tab);
            return Json(items);
        }

        public async Task<JsonResult> GetLevel2EvaluationItem(SmallEntEvaluationItemVM vm, string id, string tab, string level2Name)
        {
            var items = await vm.GetEvaluationItems(id, tab, level2Name);
            return Json(items);
        }

        [HttpPost]
        public JsonResult SaveEvaluationItem(SmallEntEvaluationItemVM vm, [FromBody]List<SmallEntEvaluationItemView> items)
        {
            return Json(vm.SaveEvaluationItems(items));
        }
        #endregion

        #region 导出报告
        [ActionDescription("导出报告")]
        public IActionResult ExportReport(string id)
        {
            var vm = CreateVM<SmallEntEvaluationItemVM>();
            var result = vm.ExportData(id);
            var memoryStream = new MemoryStream();
            string sFileName = @"test.xlsm";
            var reportpath = Path.Combine(Directory.GetCurrentDirectory(),
                                   "wwwroot", "exportTemplate", "江苏省工贸行业小微企业安全生产标准化评分表.xlsm");
            using (var fileStream = new FileStream(reportpath, FileMode.Open))
            {
                fileStream.CopyTo(memoryStream);
            }
            memoryStream.Position = 0;
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
        #endregion
    }
}