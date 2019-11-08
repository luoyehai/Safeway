using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.NormalEntEvaluationBaseVMs;
using Safeway.Model.NormalEntEvaluation;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class NormalEntEvaluationBaseControllerTest
    {
        private NormalEntEvaluationBaseController _controller;
        private string _seed;

        public NormalEntEvaluationBaseControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<NormalEntEvaluationBaseController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as NormalEntEvaluationBaseListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationBaseVM));

            NormalEntEvaluationBaseVM vm = rv.Model as NormalEntEvaluationBaseVM;
            NormalEntEvaluationBase v = new NormalEntEvaluationBase();
			
            v.Status = 31;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluationBase>().FirstOrDefault();
				
                Assert.AreEqual(data.Status, 31);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            NormalEntEvaluationBase v = new NormalEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Status = 31;
                context.Set<NormalEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationBaseVM));

            NormalEntEvaluationBaseVM vm = rv.Model as NormalEntEvaluationBaseVM;
            v = new NormalEntEvaluationBase();
            v.ID = vm.Entity.ID;
       		
            v.Status = 9;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Status", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluationBase>().FirstOrDefault();
 				
                Assert.AreEqual(data.Status, 9);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            NormalEntEvaluationBase v = new NormalEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Status = 31;
                context.Set<NormalEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationBaseVM));

            NormalEntEvaluationBaseVM vm = rv.Model as NormalEntEvaluationBaseVM;
            v = new NormalEntEvaluationBase();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<NormalEntEvaluationBase>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            NormalEntEvaluationBase v = new NormalEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.Status = 31;
                context.Set<NormalEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            NormalEntEvaluationBase v1 = new NormalEntEvaluationBase();
            NormalEntEvaluationBase v2 = new NormalEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Status = 31;
                v2.Status = 9;
                context.Set<NormalEntEvaluationBase>().Add(v1);
                context.Set<NormalEntEvaluationBase>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationBaseBatchVM));

            NormalEntEvaluationBaseBatchVM vm = rv.Model as NormalEntEvaluationBaseBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<NormalEntEvaluationBase>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as NormalEntEvaluationBaseListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
