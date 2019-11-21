using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.SmallEntEvaluationBaseVMs;
using Safeway.Model.SmallEntEvaluation;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class SmallEntEvaluationBaseControllerTest
    {
        private SmallEntEvaluationBaseController _controller;
        private string _seed;

        public SmallEntEvaluationBaseControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<SmallEntEvaluationBaseController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as SmallEntEvaluationBaseListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(SmallEntEvaluationBaseVM));

            SmallEntEvaluationBaseVM vm = rv.Model as SmallEntEvaluationBaseVM;
            SmallEntEvaluationBase v = new SmallEntEvaluationBase();
			
            v.Status = Model.Common.EvaluationStatus.Completed;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SmallEntEvaluationBase>().FirstOrDefault();
				
                Assert.AreEqual(data.Status, 43);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            SmallEntEvaluationBase v = new SmallEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Status = Model.Common.EvaluationStatus.Completed;
                context.Set<SmallEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SmallEntEvaluationBaseVM));

            SmallEntEvaluationBaseVM vm = rv.Model as SmallEntEvaluationBaseVM;
            v = new SmallEntEvaluationBase();
            v.ID = vm.Entity.ID;
       		
            v.Status = Model.Common.EvaluationStatus.Completed;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Status", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<SmallEntEvaluationBase>().FirstOrDefault();
 				
                Assert.AreEqual(data.Status, 74);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            SmallEntEvaluationBase v = new SmallEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Status = Model.Common.EvaluationStatus.Completed;
                context.Set<SmallEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(SmallEntEvaluationBaseVM));

            SmallEntEvaluationBaseVM vm = rv.Model as SmallEntEvaluationBaseVM;
            v = new SmallEntEvaluationBase();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<SmallEntEvaluationBase>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            SmallEntEvaluationBase v = new SmallEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Status = Model.Common.EvaluationStatus.Completed;
                context.Set<SmallEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            SmallEntEvaluationBase v1 = new SmallEntEvaluationBase();
            SmallEntEvaluationBase v2 = new SmallEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Status = Model.Common.EvaluationStatus.Completed;
                v2.Status = Model.Common.EvaluationStatus.InProgress;
                context.Set<SmallEntEvaluationBase>().Add(v1);
                context.Set<SmallEntEvaluationBase>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(SmallEntEvaluationBaseBatchVM));

            SmallEntEvaluationBaseBatchVM vm = rv.Model as SmallEntEvaluationBaseBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<SmallEntEvaluationBase>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as SmallEntEvaluationBaseListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
