using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.EntRegularCheckElementVMs;
using Safeway.Model.EnterpriseReview;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class EntRegularCheckElementControllerTest
    {
        private EntRegularCheckElementController _controller;
        private string _seed;

        public EntRegularCheckElementControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<EntRegularCheckElementController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as EntRegularCheckElementListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(EntRegularCheckElementVM));

            EntRegularCheckElementVM vm = rv.Model as EntRegularCheckElementVM;
            EntRegularCheckElement v = new EntRegularCheckElement();
			
            v.ElementName = "Dd7iNP";
            v.CheckContent = "LajPW";
            v.CheckPoint = "4RlPPQU";
            v.Order = 43;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EntRegularCheckElement>().FirstOrDefault();
				
                Assert.AreEqual(data.ElementName, "Dd7iNP");
                Assert.AreEqual(data.CheckContent, "LajPW");
                Assert.AreEqual(data.CheckPoint, "4RlPPQU");
                Assert.AreEqual(data.Order, 43);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            EntRegularCheckElement v = new EntRegularCheckElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ElementName = "Dd7iNP";
                v.CheckContent = "LajPW";
                v.CheckPoint = "4RlPPQU";
                v.Order = 43;
                context.Set<EntRegularCheckElement>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EntRegularCheckElementVM));

            EntRegularCheckElementVM vm = rv.Model as EntRegularCheckElementVM;
            v = new EntRegularCheckElement();
            v.ID = vm.Entity.ID;
       		
            v.ElementName = "SnT";
            v.CheckContent = "yZ45xBa";
            v.CheckPoint = "22imxPZz";
            v.Order = 48;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ElementName", "");
            vm.FC.Add("Entity.CheckContent", "");
            vm.FC.Add("Entity.CheckPoint", "");
            vm.FC.Add("Entity.Order", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EntRegularCheckElement>().FirstOrDefault();
 				
                Assert.AreEqual(data.ElementName, "SnT");
                Assert.AreEqual(data.CheckContent, "yZ45xBa");
                Assert.AreEqual(data.CheckPoint, "22imxPZz");
                Assert.AreEqual(data.Order, 48);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            EntRegularCheckElement v = new EntRegularCheckElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ElementName = "Dd7iNP";
                v.CheckContent = "LajPW";
                v.CheckPoint = "4RlPPQU";
                v.Order = 43;
                context.Set<EntRegularCheckElement>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EntRegularCheckElementVM));

            EntRegularCheckElementVM vm = rv.Model as EntRegularCheckElementVM;
            v = new EntRegularCheckElement();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EntRegularCheckElement>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            EntRegularCheckElement v = new EntRegularCheckElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ElementName = "Dd7iNP";
                v.CheckContent = "LajPW";
                v.CheckPoint = "4RlPPQU";
                v.Order = 43;
                context.Set<EntRegularCheckElement>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            EntRegularCheckElement v1 = new EntRegularCheckElement();
            EntRegularCheckElement v2 = new EntRegularCheckElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ElementName = "Dd7iNP";
                v1.CheckContent = "LajPW";
                v1.CheckPoint = "4RlPPQU";
                v1.Order = 43;
                v2.ElementName = "SnT";
                v2.CheckContent = "yZ45xBa";
                v2.CheckPoint = "22imxPZz";
                v2.Order = 48;
                context.Set<EntRegularCheckElement>().Add(v1);
                context.Set<EntRegularCheckElement>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(EntRegularCheckElementBatchVM));

            EntRegularCheckElementBatchVM vm = rv.Model as EntRegularCheckElementBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EntRegularCheckElement>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as EntRegularCheckElementListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
