﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using Safeway.ViewModel.EnterpriseBasicInfoVMs;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Safeway.ViewModel.EnterpriseFinanceInfoVMs;
using Safeway.ViewModel.EnterpriseBusinessinfoVMs;
using Safeway.ViewModel.CommonClass;
using Microsoft.AspNetCore.Authorization;
using Safeway.Model.Enterprise;

namespace Safeway.Controllers
{
    
    [ActionDescription("企业基础信息")]
    public partial class EnterpriseBasicInfoController : BaseController
    {
        #region 搜索
        [ActionDescription("搜索")]
        public ActionResult Index()
        {
            var vm = CreateVM<EnterpriseBasicInfoListVM>();
            var commonvm = CreateVM<CommonVM>();
            vm.CompanyScaleList = commonvm.GetDictionaryItems("companyScaleList");
            vm.CompanyTypeList = commonvm.GetDictionaryItems("CompanyType");
            vm.TradeMethodList = commonvm.GetDictionaryItems("tradeTermList");
            return PartialView(vm);
        }

        [ActionDescription("搜索")]
        [HttpPost]
        public string Search(EnterpriseBasicInfoListVM vm)
        {
            return vm.GetJson(false);
        }

        #endregion

        #region 新建
        [ActionDescription("新建")]
        public ActionResult Create()
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("新建")]
        public ActionResult Create(EnterpriseBasicInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoAdd();
                vm.EnterpriseBusinessinfo.EnterpriseBasicInfoId = vm.Entity.ID;
                vm.EnterpriseFinanceInfo.EnterpriseBasicId = vm.Entity.ID;
                vm.DoAddBusinnessInfo(vm.EnterpriseBusinessinfo);
                vm.DoAddFinanceInfo(vm.EnterpriseFinanceInfo);
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
            var vm = CreateVM<EnterpriseBasicInfoVM>(id);
            vm.LoadAdditionalInfo(id);
            vm.LoadListInfo(id);
            return PartialView(vm);
        }
        [ActionDescription("修改")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(EnterpriseBasicInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoEdit();
                vm.EnterpriseBusinessinfo.EnterpriseBasicInfoId = vm.Entity.ID;
                vm.EnterpriseFinanceInfo.EnterpriseBasicId = vm.Entity.ID;
                vm.DoEditBusinnessInfo(vm.EnterpriseBusinessinfo);
                vm.DoEditFinanceInfo(vm.EnterpriseFinanceInfo);
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
            var vm = CreateVM<EnterpriseBasicInfoVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("删除")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>(id);
            vm.DeleteEnterpriseInfo(id);
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
            var vm = CreateVM<EnterpriseBasicInfoVM>(id);
            vm.LoadAdditionalInfo(id);
            vm.LoadListInfo(id);
            //vm.EnterpriseBusinessinfo = vm.GetBusinessInfo(new Guid(id));
            //vm.EnterpriseFinanceInfo = vm.GetFinanceInfo(new Guid(id));
            return PartialView(vm);
        }
        #endregion

        #region 批量修改
        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult BatchEdit(string[] IDs)
        {
            var vm = CreateVM<EnterpriseBasicInfoBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量修改")]
        public ActionResult DoBatchEdit(EnterpriseBasicInfoBatchVM vm, IFormCollection nouse)
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
            var vm = CreateVM<EnterpriseBasicInfoBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("批量删除")]
        public ActionResult DoBatchDelete(EnterpriseBasicInfoBatchVM vm, IFormCollection nouse)
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
            var vm = CreateVM<EnterpriseBasicInfoImportVM>();

            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("导入")]
        public ActionResult Import(EnterpriseBasicInfoImportVM vm, IFormCollection nouse)
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

        [ActionDescription("导出")]
        [HttpPost]
        public IActionResult ExportExcel(EnterpriseBasicInfoListVM vm)
        {
            vm.SearcherMode = vm.Ids != null && vm.Ids.Count > 0 ? ListVMSearchModeEnum.CheckExport : ListVMSearchModeEnum.Export;
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_EnterpriseBasicInfo_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }
        [ActionDescription("LoadCity")]   
        public IActionResult LoadCities(string id)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result= vm.GetCities(id);
            string names = vm.CityItemNames;
            HttpContext.Session.SetString("citynames", names);
            return Json(result);
        }
        [ActionDescription("LoadDistrict")]
        public IActionResult LoadDistricts(EnterpriseBasicInfoVM vm,string id)
        {
            return Json(vm.GetDistricts(id, HttpContext.Session.GetString("citynames")));

        }
        #region VueMethod
        [AllowAnonymous]
        public JsonResult LoadEnteprise(EnterpriseBasicInfoVM vm, string keywords)
        {
            var result = vm.GetBaseQuery().Where(x => x.ComapanyName.Contains(keywords)).Select(x => new ViewFormatClass { Text = x.ComapanyName, Value = x.ComapanyName }).ToList();
            return Json(result);
        }
        [ActionDescription("GetProvinces")]
        public IActionResult GetProvinces()
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.GetProvinces();
            return Json(result);
        }
        [ActionDescription("GetCities")]
        public IActionResult GetCities(string provinceid)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.GetSelectedCities(provinceid);
            return Json(result);
        }
        [ActionDescription("GetDistricts")]
        public IActionResult GetDistricts(string cityid)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.GetDistricts(cityid);
            return Json(result);
        }
        [HttpPost]
        public ActionResult AddEnterpriseInfo([FromBody]params string[] parameters)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.AddNewEnterpriseInfo(parameters);
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
        [HttpPost]
        public ActionResult EditEnterpriseInfo([FromBody]params string[] parameters)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.EditNewEnterpriseInfo(parameters);
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
        [HttpGet]
        public JsonResult GetEnterpriseInfo(string Id)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.GetEnterpriseInfo(Id);
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetDictionaryData(string dictionaryCode)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.GetDictionaryData(dictionaryCode);
            return Json(result);
        }

        [ActionDescription("企业基本信息")]
        public IActionResult LimitedEnterpriseInfo(string id) 
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>(id);
            //string enterpriseId = vm.GetEnterprisebyEvaluationId(id);
            //vm.Entity.ID = new Guid(enterpriseId);
            //ViewData["ID"] = enterpriseId;
            return PartialView(vm);

        }
        [HttpGet]
        public JsonResult GetLimitedEnterpriseInfo(string Id)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            //vm.EnterpriseContacts = 
            var result = vm.GetLimitedEnterpriseInfo(Id);
            return Json(result);
        }
        [HttpPost]
        public ActionResult EditLimitedEnterpriseInfo([FromBody]params string[] parameters)
        {
            var vm = CreateVM<EnterpriseBasicInfoVM>();
            var result = vm.EditLimitedEnterpriseInfo(parameters);
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
        #endregion
    }
}
