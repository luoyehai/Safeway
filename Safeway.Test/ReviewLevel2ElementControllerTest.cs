using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.ReviewLevel2ElementVMs;
using Safeway.Model.ReviewTemp;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class ReviewLevel2ElementControllerTest
    {
        private ReviewLevel2ElementController _controller;
        private string _seed;

        public ReviewLevel2ElementControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ReviewLevel2ElementController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ReviewLevel2ElementListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewLevel2ElementVM));

            ReviewLevel2ElementVM vm = rv.Model as ReviewLevel2ElementVM;
            ReviewLevel2Element v = new ReviewLevel2Element();
			
            v.ElementName = "96o80jm";
            v.ElementStandard = "8vV";
            v.Order = "f7y4u";
            v.TotalScore = 17;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ReviewLevel2Element>().FirstOrDefault();
				
                Assert.AreEqual(data.ElementName, "96o80jm");
                Assert.AreEqual(data.ElementStandard, "8vV");
                Assert.AreEqual(data.Order, "f7y4u");
                Assert.AreEqual(data.TotalScore, 17);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ReviewLevel2Element v = new ReviewLevel2Element();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ElementName = "96o80jm";
                v.ElementStandard = "8vV";
                v.Order = "f7y4u";
                v.TotalScore = 17;
                context.Set<ReviewLevel2Element>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewLevel2ElementVM));

            ReviewLevel2ElementVM vm = rv.Model as ReviewLevel2ElementVM;
            v = new ReviewLevel2Element();
            v.ID = vm.Entity.ID;
       		
            v.ElementName = "BEer";
            v.ElementStandard = "kNfePd";
            v.Order = "o8mMnJB60";
            v.TotalScore = 86;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ElementName", "");
            vm.FC.Add("Entity.ElementStandard", "");
            vm.FC.Add("Entity.Order", "");
            vm.FC.Add("Entity.TotalScore", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ReviewLevel2Element>().FirstOrDefault();
 				
                Assert.AreEqual(data.ElementName, "BEer");
                Assert.AreEqual(data.ElementStandard, "kNfePd");
                Assert.AreEqual(data.Order, "o8mMnJB60");
                Assert.AreEqual(data.TotalScore, 86);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ReviewLevel2Element v = new ReviewLevel2Element();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ElementName = "96o80jm";
                v.ElementStandard = "8vV";
                v.Order = "f7y4u";
                v.TotalScore = 17;
                context.Set<ReviewLevel2Element>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewLevel2ElementVM));

            ReviewLevel2ElementVM vm = rv.Model as ReviewLevel2ElementVM;
            v = new ReviewLevel2Element();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ReviewLevel2Element>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ReviewLevel2Element v = new ReviewLevel2Element();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ElementName = "96o80jm";
                v.ElementStandard = "8vV";
                v.Order = "f7y4u";
                v.TotalScore = 17;
                context.Set<ReviewLevel2Element>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ReviewLevel2Element v1 = new ReviewLevel2Element();
            ReviewLevel2Element v2 = new ReviewLevel2Element();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ElementName = "96o80jm";
                v1.ElementStandard = "8vV";
                v1.Order = "f7y4u";
                v1.TotalScore = 17;
                v2.ElementName = "BEer";
                v2.ElementStandard = "kNfePd";
                v2.Order = "o8mMnJB60";
                v2.TotalScore = 86;
                context.Set<ReviewLevel2Element>().Add(v1);
                context.Set<ReviewLevel2Element>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ReviewLevel2ElementBatchVM));

            ReviewLevel2ElementBatchVM vm = rv.Model as ReviewLevel2ElementBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ReviewLevel2Element>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as ReviewLevel2ElementListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
