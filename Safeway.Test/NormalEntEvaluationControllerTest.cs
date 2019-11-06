using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.NormalEntEvaluationVMs;
using Safeway.Model.Evaluation;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class NormalEntEvaluationControllerTest
    {
        private NormalEntEvaluationController _controller;
        private string _seed;

        public NormalEntEvaluationControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<NormalEntEvaluationController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as NormalEntEvaluationListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationVM));

            NormalEntEvaluationVM vm = rv.Model as NormalEntEvaluationVM;
            NormalEntEvaluation v = new NormalEntEvaluation();
			
            v.StandardScore = 77;
            v.ActualScore = 97;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluation>().FirstOrDefault();
				
                Assert.AreEqual(data.StandardScore, 77);
                Assert.AreEqual(data.ActualScore, 97);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            NormalEntEvaluation v = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.StandardScore = 77;
                v.ActualScore = 97;
                context.Set<NormalEntEvaluation>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationVM));

            NormalEntEvaluationVM vm = rv.Model as NormalEntEvaluationVM;
            v = new NormalEntEvaluation();
            v.ID = vm.Entity.ID;
       		
            v.StandardScore = 70;
            v.ActualScore = 57;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.StandardScore", "");
            vm.FC.Add("Entity.ActualScore", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluation>().FirstOrDefault();
 				
                Assert.AreEqual(data.StandardScore, 70);
                Assert.AreEqual(data.ActualScore, 57);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            NormalEntEvaluation v = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.StandardScore = 77;
                v.ActualScore = 97;
                context.Set<NormalEntEvaluation>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationVM));

            NormalEntEvaluationVM vm = rv.Model as NormalEntEvaluationVM;
            v = new NormalEntEvaluation();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<NormalEntEvaluation>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            NormalEntEvaluation v = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.StandardScore = 77;
                v.ActualScore = 97;
                context.Set<NormalEntEvaluation>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            NormalEntEvaluation v1 = new NormalEntEvaluation();
            NormalEntEvaluation v2 = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.StandardScore = 77;
                v1.ActualScore = 97;
                v2.StandardScore = 70;
                v2.ActualScore = 57;
                context.Set<NormalEntEvaluation>().Add(v1);
                context.Set<NormalEntEvaluation>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationBatchVM));

            NormalEntEvaluationBatchVM vm = rv.Model as NormalEntEvaluationBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<NormalEntEvaluation>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as NormalEntEvaluationListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
