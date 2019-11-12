using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.EnterpriserYearYieldVMs;
using Safeway.Model.Enterprise;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class EnterpriserYearYieldControllerTest
    {
        private EnterpriserYearYieldController _controller;
        private string _seed;

        public EnterpriserYearYieldControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<EnterpriserYearYieldController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as EnterpriserYearYieldListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriserYearYieldVM));

            EnterpriserYearYieldVM vm = rv.Model as EnterpriserYearYieldVM;
            EnterpriserYearYield v = new EnterpriserYearYield();
			
            v.YearYieldValue = 87;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriserYearYield>().FirstOrDefault();
				
                Assert.AreEqual(data.YearYieldValue, 87);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            EnterpriserYearYield v = new EnterpriserYearYield();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.YearYieldValue = 87;
                context.Set<EnterpriserYearYield>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriserYearYieldVM));

            EnterpriserYearYieldVM vm = rv.Model as EnterpriserYearYieldVM;
            v = new EnterpriserYearYield();
            v.ID = vm.Entity.ID;
       		
            v.YearYieldValue = 13;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.YearYieldValue", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriserYearYield>().FirstOrDefault();
 				
                Assert.AreEqual(data.YearYieldValue, 13);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            EnterpriserYearYield v = new EnterpriserYearYield();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.YearYieldValue = 87;
                context.Set<EnterpriserYearYield>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriserYearYieldVM));

            EnterpriserYearYieldVM vm = rv.Model as EnterpriserYearYieldVM;
            v = new EnterpriserYearYield();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EnterpriserYearYield>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            EnterpriserYearYield v = new EnterpriserYearYield();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.YearYieldValue = 87;
                context.Set<EnterpriserYearYield>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            EnterpriserYearYield v1 = new EnterpriserYearYield();
            EnterpriserYearYield v2 = new EnterpriserYearYield();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.YearYieldValue = 87;
                v2.YearYieldValue = 13;
                context.Set<EnterpriserYearYield>().Add(v1);
                context.Set<EnterpriserYearYield>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriserYearYieldBatchVM));

            EnterpriserYearYieldBatchVM vm = rv.Model as EnterpriserYearYieldBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EnterpriserYearYield>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as EnterpriserYearYieldListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
