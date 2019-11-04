using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.ViewModel.NormalEntEvaTemplateListVMs;

namespace Safeway.Controllers
{
    public class NormalEntEvaTemplateController : Controller
    {
        public IActionResult Index()
        {
            var vm = new NormalEntEvaTemplateListVM();
            
            return View(vm.Index());
        }
    }
}