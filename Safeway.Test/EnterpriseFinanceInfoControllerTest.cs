using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.EnterpriseFinanceInfoVMs;
using Safeway.Model.Enterprise;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class EnterpriseFinanceInfoControllerTest
    {
        private EnterpriseFinanceInfoController _controller;
        private string _seed;

        public EnterpriseFinanceInfoControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<EnterpriseFinanceInfoController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as EnterpriseFinanceInfoListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseFinanceInfoVM));

            EnterpriseFinanceInfoVM vm = rv.Model as EnterpriseFinanceInfoVM;
            EnterpriseFinanceInfo v = new EnterpriseFinanceInfo();
			
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriseFinanceInfo>().FirstOrDefault();
				
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            EnterpriseFinanceInfo v = new EnterpriseFinanceInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                context.Set<EnterpriseFinanceInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseFinanceInfoVM));

            EnterpriseFinanceInfoVM vm = rv.Model as EnterpriseFinanceInfoVM;
            v = new EnterpriseFinanceInfo();
            v.ID = vm.Entity.ID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriseFinanceInfo>().FirstOrDefault();
 				
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            EnterpriseFinanceInfo v = new EnterpriseFinanceInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                context.Set<EnterpriseFinanceInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseFinanceInfoVM));

            EnterpriseFinanceInfoVM vm = rv.Model as EnterpriseFinanceInfoVM;
            v = new EnterpriseFinanceInfo();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EnterpriseFinanceInfo>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            EnterpriseFinanceInfo v = new EnterpriseFinanceInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<EnterpriseFinanceInfo>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            EnterpriseFinanceInfo v1 = new EnterpriseFinanceInfo();
            EnterpriseFinanceInfo v2 = new EnterpriseFinanceInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<EnterpriseFinanceInfo>().Add(v1);
                context.Set<EnterpriseFinanceInfo>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseFinanceInfoBatchVM));

            EnterpriseFinanceInfoBatchVM vm = rv.Model as EnterpriseFinanceInfoBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EnterpriseFinanceInfo>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as EnterpriseFinanceInfoListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
