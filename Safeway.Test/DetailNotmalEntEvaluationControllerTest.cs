using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.DetailNotmalEntEvaluationVMs;
using Safeway.Model.Evaluation;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class DetailNotmalEntEvaluationControllerTest
    {
        private DetailNotmalEntEvaluationController _controller;
        private string _seed;

        public DetailNotmalEntEvaluationControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<DetailNotmalEntEvaluationController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as DetailNotmalEntEvaluationListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(DetailNotmalEntEvaluationVM));

            DetailNotmalEntEvaluationVM vm = rv.Model as DetailNotmalEntEvaluationVM;
            DetailNotmalEntEvaluation v = new DetailNotmalEntEvaluation();
			
            v.DeductionReference = 80;
            v.Deduction = 23;
            v.NormalEntEvaluationId = AddNormalEntEvaluation();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DetailNotmalEntEvaluation>().FirstOrDefault();
				
                Assert.AreEqual(data.DeductionReference, 80);
                Assert.AreEqual(data.Deduction, 23);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            DetailNotmalEntEvaluation v = new DetailNotmalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DeductionReference = 80;
                v.Deduction = 23;
                v.NormalEntEvaluationId = AddNormalEntEvaluation();
                context.Set<DetailNotmalEntEvaluation>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(DetailNotmalEntEvaluationVM));

            DetailNotmalEntEvaluationVM vm = rv.Model as DetailNotmalEntEvaluationVM;
            v = new DetailNotmalEntEvaluation();
            v.ID = vm.Entity.ID;
       		
            v.DeductionReference = 20;
            v.Deduction = 48;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DeductionReference", "");
            vm.FC.Add("Entity.Deduction", "");
            vm.FC.Add("Entity.NormalEntEvaluationId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DetailNotmalEntEvaluation>().FirstOrDefault();
 				
                Assert.AreEqual(data.DeductionReference, 20);
                Assert.AreEqual(data.Deduction, 48);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            DetailNotmalEntEvaluation v = new DetailNotmalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DeductionReference = 80;
                v.Deduction = 23;
                v.NormalEntEvaluationId = AddNormalEntEvaluation();
                context.Set<DetailNotmalEntEvaluation>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(DetailNotmalEntEvaluationVM));

            DetailNotmalEntEvaluationVM vm = rv.Model as DetailNotmalEntEvaluationVM;
            v = new DetailNotmalEntEvaluation();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<DetailNotmalEntEvaluation>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            DetailNotmalEntEvaluation v = new DetailNotmalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.DeductionReference = 80;
                v.Deduction = 23;
                v.NormalEntEvaluationId = AddNormalEntEvaluation();
                context.Set<DetailNotmalEntEvaluation>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            DetailNotmalEntEvaluation v1 = new DetailNotmalEntEvaluation();
            DetailNotmalEntEvaluation v2 = new DetailNotmalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeductionReference = 80;
                v1.Deduction = 23;
                v1.NormalEntEvaluationId = AddNormalEntEvaluation();
                v2.DeductionReference = 20;
                v2.Deduction = 48;
                v2.NormalEntEvaluationId = v1.NormalEntEvaluationId; 
                context.Set<DetailNotmalEntEvaluation>().Add(v1);
                context.Set<DetailNotmalEntEvaluation>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(DetailNotmalEntEvaluationBatchVM));

            DetailNotmalEntEvaluationBatchVM vm = rv.Model as DetailNotmalEntEvaluationBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<DetailNotmalEntEvaluation>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as DetailNotmalEntEvaluationListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddNormalEntEvaluation()
        {
            NormalEntEvaluation v = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.StandardScore = 44;
                v.ActualScore = 62;
                context.Set<NormalEntEvaluation>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
