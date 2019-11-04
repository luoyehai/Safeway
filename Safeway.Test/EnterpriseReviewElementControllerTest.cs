using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.EnterpriseReviewElementVMs;
using Safeway.Model.EnterpriseReview;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class EnterpriseReviewElementControllerTest
    {
        private EnterpriseReviewElementController _controller;
        private string _seed;

        public EnterpriseReviewElementControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<EnterpriseReviewElementController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as EnterpriseReviewElementListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseReviewElementVM));

            EnterpriseReviewElementVM vm = rv.Model as EnterpriseReviewElementVM;
            EnterpriseReviewElement v = new EnterpriseReviewElement();
			
            v.ElementName = "U3a";
            v.Order = 34;
            v.TotalScore = 95;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriseReviewElement>().FirstOrDefault();
				
                Assert.AreEqual(data.ElementName, "U3a");
                Assert.AreEqual(data.Order, 34);
                Assert.AreEqual(data.TotalScore, 95);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            EnterpriseReviewElement v = new EnterpriseReviewElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ElementName = "U3a";
                v.Order = 34;
                v.TotalScore = 95;
                context.Set<EnterpriseReviewElement>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseReviewElementVM));

            EnterpriseReviewElementVM vm = rv.Model as EnterpriseReviewElementVM;
            v = new EnterpriseReviewElement();
            v.ID = vm.Entity.ID;
       		
            v.ElementName = "Wj1pZCrGg";
            v.Order = 63;
            v.TotalScore = 7;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ElementName", "");
            vm.FC.Add("Entity.Order", "");
            vm.FC.Add("Entity.TotalScore", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriseReviewElement>().FirstOrDefault();
 				
                Assert.AreEqual(data.ElementName, "Wj1pZCrGg");
                Assert.AreEqual(data.Order, 63);
                Assert.AreEqual(data.TotalScore, 7);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            EnterpriseReviewElement v = new EnterpriseReviewElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ElementName = "U3a";
                v.Order = 34;
                v.TotalScore = 95;
                context.Set<EnterpriseReviewElement>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseReviewElementVM));

            EnterpriseReviewElementVM vm = rv.Model as EnterpriseReviewElementVM;
            v = new EnterpriseReviewElement();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EnterpriseReviewElement>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            EnterpriseReviewElement v = new EnterpriseReviewElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ElementName = "U3a";
                v.Order = 34;
                v.TotalScore = 95;
                context.Set<EnterpriseReviewElement>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            EnterpriseReviewElement v1 = new EnterpriseReviewElement();
            EnterpriseReviewElement v2 = new EnterpriseReviewElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ElementName = "U3a";
                v1.Order = 34;
                v1.TotalScore = 95;
                v2.ElementName = "Wj1pZCrGg";
                v2.Order = 63;
                v2.TotalScore = 7;
                context.Set<EnterpriseReviewElement>().Add(v1);
                context.Set<EnterpriseReviewElement>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(EnterpriseReviewElementBatchVM));

            EnterpriseReviewElementBatchVM vm = rv.Model as EnterpriseReviewElementBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EnterpriseReviewElement>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as EnterpriseReviewElementListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
