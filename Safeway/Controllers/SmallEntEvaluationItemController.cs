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
        public IActionResult ViewReport(string id)
        {
            var vm = CreateVM<SmallEntEvaluationItemVM>();
            ViewData["ID"]= id;
            return PartialView(vm);
        }
        
        public JsonResult GetEvaluationItem(SmallEntEvaluationItemVM vm, string id)
        {
            var items = vm.GetEvaluationItems(id);
            return Json(items);
        }
        #endregion
    }
}