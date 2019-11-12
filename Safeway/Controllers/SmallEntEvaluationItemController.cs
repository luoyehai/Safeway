using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safeway.ViewModel.SamllEntEvaluationItemVMs;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace Safeway.Controllers
{
    public class SmallEntEvaluationItemController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        #region 查看报告
        [ActionDescription("查看报告")]
        public IActionResult ViewReport(string baseId)
        {
            var vm = CreateVM<SmallEntEvaluationItemVM>();
            return PartialView(vm);
        }
        
        public JsonResult GetEvaluationItem(SmallEntEvaluationItemVM vm)
        {
            var items = vm.GetEvaluationItems("281247f7-e586-4751-9713-2ab3ee9a4df4");
            return Json(items);
        }
        #endregion
    }
}