using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.ViewModel.SmallEntEvaluationBaseVMs;
using Safeway.ViewModel.SamllEntEvaluationItemVMs;
using Microsoft.AspNetCore.Authorization;

namespace Safeway.Controllers
{
    
    [ActionDescription("小微评审项目管理")]
    public partial class SmallEntEvaluationBaseController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index()
        {
            var vm = CreateVM<SmallEntEvaluationBaseListVM>();
            return PartialView(vm);
        }

        [ActionDescription("搜索")]
        [HttpPost]
        public string Search(SmallEntEvaluationBaseListVM vm)
        {
            return vm.GetJson(false);
        }

        #endregion

        #region 新建
        [ActionDescription("新建")]
        public ActionResult Create()
        {
            var vm = CreateVM<SmallEntEvaluationBaseVM>();
            vm.Entity.EvaluationStartDate = DateTime.Now;
            vm.Entity.EvaluationEndDate = DateTime.Now;
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("新建")]
        public ActionResult Create(SmallEntEvaluationBaseVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoAdd();
                //Add all the relative elements into item table           
                vm.InsertElements(vm.Entity.ID.ToString());
              if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }
        }
        #endregion

        #region 修改
        [ActionDescription("修改")]
        public ActionResult Edit(string id)
        {
            var vm = CreateVM<SmallEntEvaluationBaseVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("修改")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(SmallEntEvaluationBaseVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoEdit();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGridRow(vm.Entity.ID);
                }
            }
        }
        #endregion

        #region 删除
        [ActionDescription("删除")]
        public ActionResult Delete(string id)
        {
            var vm = CreateVM<SmallEntEvaluationBaseVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("删除")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = CreateVM<SmallEntEvaluationBaseVM>(id);
            vm.DoDelete();
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid();
            }
        }
        #endregion

        #region 详细
        [ActionDescription("详细")]
        public ActionResult Details(string id)
        {
            var vm = CreateVM<SmallEntEvaluationBaseVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region 查看报告
        [ActionDescription("查看报告")]
        public ActionResult ViewReport(string id)
        {
            var vm = CreateVM<SmallEntEvaluationItemVM>();
            var entEvaluationBase = vm.GetSmallEntEvaluationBase(id);
            vm.EntEvaluationBase = entEvaluationBase.Result;
            ViewData["ID"] = id;
            return PartialView(vm);
        }
        #endregion

        #region 批量修改
        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult BatchEdit(string[] IDs)
        {
            var vm = CreateVM<SmallEntEvaluationBaseBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult DoBatchEdit(SmallEntEvaluationBaseBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return PartialView("BatchEdit",vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有"+vm.Ids.Length+"条数据被修改");
            }
        }
        #endregion

        #region 批量删除
        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult BatchDelete(string[] IDs)
        {
            var vm = CreateVM<SmallEntEvaluationBaseBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult DoBatchDelete(SmallEntEvaluationBaseBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return PartialView("BatchDelete",vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有"+vm.Ids.Length+"条数据被删除");
            }
        }
        #endregion

        #region 导入
		[ActionDescription("导入")]
        public ActionResult Import()
        {
            var vm = CreateVM<SmallEntEvaluationBaseImportVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("导入")]
        public ActionResult Import(SmallEntEvaluationBaseImportVM vm, IFormCollection nouse)
        {
            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("成功导入 " + vm.EntityList.Count.ToString() + " 行数据");
            }
        }
        #endregion

        [AllowAnonymous]
        [ActionDescription("导出")]
        [HttpPost]
        public IActionResult ExportExcel(SmallEntEvaluationBaseListVM vm)
        {
            vm.SearcherMode = vm.Ids != null && vm.Ids.Count > 0 ? ListVMSearchModeEnum.CheckExport : ListVMSearchModeEnum.Export;
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_SmallEntEvaluationBase_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }

        [AllowAnonymous]
        [ActionDescription("查询用户")]
        public IActionResult SearchUser(SmallEntEvaluationBaseVM vm, string keywords)
        {
            return Json(vm.SearchUser(keywords));
        }

    }
}
