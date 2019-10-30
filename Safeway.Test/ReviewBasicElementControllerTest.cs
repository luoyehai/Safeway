using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.ReviewBasicElementVMs;
using Safeway.Model.ReviewTemp;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class ReviewBasicElementControllerTest
    {
        private ReviewBasicElementController _controller;
        private string _seed;

        public ReviewBasicElementControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ReviewBasicElementController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ReviewBasicElementListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewBasicElementVM));

            ReviewBasicElementVM vm = rv.Model as ReviewBasicElementVM;
            ReviewBasicElement v = new ReviewBasicElement();
			
            v.ElementName = "yBYJVqzCa";
            v.Order = 33;
            v.TotalScore = 21;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ReviewBasicElement>().FirstOrDefault();
				
                Assert.AreEqual(data.ElementName, "yBYJVqzCa");
                Assert.AreEqual(data.Order, 33);
                Assert.AreEqual(data.TotalScore, 21);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ReviewBasicElement v = new ReviewBasicElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ElementName = "yBYJVqzCa";
                v.Order = 33;
                v.TotalScore = 21;
                context.Set<ReviewBasicElement>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewBasicElementVM));

            ReviewBasicElementVM vm = rv.Model as ReviewBasicElementVM;
            v = new ReviewBasicElement();
            v.ID = vm.Entity.ID;
       		
            v.ElementName = "j2vTA7rRa";
            v.Order = 12;
            v.TotalScore = 57;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ElementName", "");
            vm.FC.Add("Entity.Order", "");
            vm.FC.Add("Entity.TotalScore", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ReviewBasicElement>().FirstOrDefault();
 				
                Assert.AreEqual(data.ElementName, "j2vTA7rRa");
                Assert.AreEqual(data.Order, 12);
                Assert.AreEqual(data.TotalScore, 57);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ReviewBasicElement v = new ReviewBasicElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ElementName = "yBYJVqzCa";
                v.Order = 33;
                v.TotalScore = 21;
                context.Set<ReviewBasicElement>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewBasicElementVM));

            ReviewBasicElementVM vm = rv.Model as ReviewBasicElementVM;
            v = new ReviewBasicElement();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ReviewBasicElement>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ReviewBasicElement v = new ReviewBasicElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ElementName = "yBYJVqzCa";
                v.Order = 33;
                v.TotalScore = 21;
                context.Set<ReviewBasicElement>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ReviewBasicElement v1 = new ReviewBasicElement();
            ReviewBasicElement v2 = new ReviewBasicElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ElementName = "yBYJVqzCa";
                v1.Order = 33;
                v1.TotalScore = 21;
                v2.ElementName = "j2vTA7rRa";
                v2.Order = 12;
                v2.TotalScore = 57;
                context.Set<ReviewBasicElement>().Add(v1);
                context.Set<ReviewBasicElement>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewBasicElementBatchVM));

            ReviewBasicElementBatchVM vm = rv.Model as ReviewBasicElementBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ReviewBasicElement>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as ReviewBasicElementListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
