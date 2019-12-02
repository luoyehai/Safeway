using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.ViewModel.ProjectBasicInfoVMs;
using System.Threading.Tasks;
using Safeway.ViewModel.MyTaskVMs;
using Safeway.ViewModel.CommonClass;

namespace Safeway.Controllers
{
    [ActionDescription("我的任务")]
    public class MyTaskController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index()
        {
            var vm = CreateVM<MyTaskListVM>();
            var commonvm = CreateVM<CommonVM>();
            vm.AllEnterprise = commonvm.GetEnterprises();
            vm.AllProject = commonvm.GetProjects();
            return PartialView(vm);
        }

        [ActionDescription("搜索")]
        [HttpPost]
        public string Search(MyTaskListVM vm)
        {
            return vm.GetJson(false);
        }

        #endregion
    }
}