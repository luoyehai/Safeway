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
    public class DetailNotmalEntEvaluationApiTest
    {
        private DetailNotmalEntEvaluationApiController _controller;
        private string _seed;

        public DetailNotmalEntEvaluationApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<DetailNotmalEntEvaluationApiController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new DetailNotmalEntEvaluationApiSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            DetailNotmalEntEvaluationApiVM vm = _controller.CreateVM<DetailNotmalEntEvaluationApiVM>();
            DetailNotmalEntEvaluation v = new DetailNotmalEntEvaluation();
            
            v.DeductionReference = 77;
            v.Deduction = 30;
            v.NormalEntEvaluationId = AddNormalEntEvaluation();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DetailNotmalEntEvaluation>().FirstOrDefault();
                
                Assert.AreEqual(data.DeductionReference, 77);
                Assert.AreEqual(data.Deduction, 30);
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
       			
                v.DeductionReference = 77;
                v.Deduction = 30;
                v.NormalEntEvaluationId = AddNormalEntEvaluation();
                context.Set<DetailNotmalEntEvaluation>().Add(v);
                context.SaveChanges();
            }

            DetailNotmalEntEvaluationApiVM vm = _controller.CreateVM<DetailNotmalEntEvaluationApiVM>();
            var oldID = v.ID;
            v = new DetailNotmalEntEvaluation();
            v.ID = oldID;
       		
            v.DeductionReference = 2;
            v.Deduction = 44;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DeductionReference", "");
            vm.FC.Add("Entity.Deduction", "");
            vm.FC.Add("Entity.NormalEntEvaluationId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<DetailNotmalEntEvaluation>().FirstOrDefault();
 				
                Assert.AreEqual(data.DeductionReference, 2);
                Assert.AreEqual(data.Deduction, 44);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            DetailNotmalEntEvaluation v = new DetailNotmalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DeductionReference = 77;
                v.Deduction = 30;
                v.NormalEntEvaluationId = AddNormalEntEvaluation();
                context.Set<DetailNotmalEntEvaluation>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            DetailNotmalEntEvaluation v1 = new DetailNotmalEntEvaluation();
            DetailNotmalEntEvaluation v2 = new DetailNotmalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DeductionReference = 77;
                v1.Deduction = 30;
                v1.NormalEntEvaluationId = AddNormalEntEvaluation();
                v2.DeductionReference = 2;
                v2.Deduction = 44;
                v2.NormalEntEvaluationId = v1.NormalEntEvaluationId; 
                context.Set<DetailNotmalEntEvaluation>().Add(v1);
                context.Set<DetailNotmalEntEvaluation>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<DetailNotmalEntEvaluation>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddNormalEntEvaluation()
        {
            NormalEntEvaluation v = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.StandardScore = 89;
                v.ActualScore = 35;
                context.Set<NormalEntEvaluation>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
