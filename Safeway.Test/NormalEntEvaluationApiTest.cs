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
    public class NormalEntEvaluationApiTest
    {
        private NormalEntEvaluationApiController _controller;
        private string _seed;

        public NormalEntEvaluationApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<NormalEntEvaluationApiController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new NormalEntEvaluationApiSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            NormalEntEvaluationApiVM vm = _controller.CreateVM<NormalEntEvaluationApiVM>();
            NormalEntEvaluation v = new NormalEntEvaluation();
            
            v.StandardScore = 59;
            v.ActualScore = 73;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluation>().FirstOrDefault();
                
                Assert.AreEqual(data.StandardScore, 59);
                Assert.AreEqual(data.ActualScore, 73);
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
       			
                v.StandardScore = 59;
                v.ActualScore = 73;
                context.Set<NormalEntEvaluation>().Add(v);
                context.SaveChanges();
            }

            NormalEntEvaluationApiVM vm = _controller.CreateVM<NormalEntEvaluationApiVM>();
            var oldID = v.ID;
            v = new NormalEntEvaluation();
            v.ID = oldID;
       		
            v.StandardScore = 74;
            v.ActualScore = 60;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.StandardScore", "");
            vm.FC.Add("Entity.ActualScore", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluation>().FirstOrDefault();
 				
                Assert.AreEqual(data.StandardScore, 74);
                Assert.AreEqual(data.ActualScore, 60);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            NormalEntEvaluation v = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.StandardScore = 59;
                v.ActualScore = 73;
                context.Set<NormalEntEvaluation>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            NormalEntEvaluation v1 = new NormalEntEvaluation();
            NormalEntEvaluation v2 = new NormalEntEvaluation();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.StandardScore = 59;
                v1.ActualScore = 73;
                v2.StandardScore = 74;
                v2.ActualScore = 60;
                context.Set<NormalEntEvaluation>().Add(v1);
                context.Set<NormalEntEvaluation>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<NormalEntEvaluation>().Count(), 0);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
