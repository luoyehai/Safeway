using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.BasicEntEvaluationBaseVMs;
using Safeway.Model.BasicEntEvaluation;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class BasicEntEvaluationBaseControllerTest
    {
        private BasicEntEvaluationBaseController _controller;
        private string _seed;

        public BasicEntEvaluationBaseControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<BasicEntEvaluationBaseController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as BasicEntEvaluationBaseListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(BasicEntEvaluationBaseVM));

            BasicEntEvaluationBaseVM vm = rv.Model as BasicEntEvaluationBaseVM;
            BasicEntEvaluationBase v = new BasicEntEvaluationBase();
			
            v.EnterpriseId = "4Vu61FW5";
            v.EvluationEnt = "986488Hg";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<BasicEntEvaluationBase>().FirstOrDefault();
				
                Assert.AreEqual(data.EnterpriseId, "4Vu61FW5");
                Assert.AreEqual(data.EvluationEnt, "986488Hg");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            BasicEntEvaluationBase v = new BasicEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.EnterpriseId = "4Vu61FW5";
                v.EvluationEnt = "986488Hg";
                context.Set<BasicEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(BasicEntEvaluationBaseVM));

            BasicEntEvaluationBaseVM vm = rv.Model as BasicEntEvaluationBaseVM;
            v = new BasicEntEvaluationBase();
            v.ID = vm.Entity.ID;
       		
            v.EnterpriseId = "nWO";
            v.EvluationEnt = "eSB";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.EnterpriseId", "");
            vm.FC.Add("Entity.EvluationEnt", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<BasicEntEvaluationBase>().FirstOrDefault();
 				
                Assert.AreEqual(data.EnterpriseId, "nWO");
                Assert.AreEqual(data.EvluationEnt, "eSB");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            BasicEntEvaluationBase v = new BasicEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.EnterpriseId = "4Vu61FW5";
                v.EvluationEnt = "986488Hg";
                context.Set<BasicEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(BasicEntEvaluationBaseVM));

            BasicEntEvaluationBaseVM vm = rv.Model as BasicEntEvaluationBaseVM;
            v = new BasicEntEvaluationBase();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<BasicEntEvaluationBase>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            BasicEntEvaluationBase v = new BasicEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.EnterpriseId = "4Vu61FW5";
                v.EvluationEnt = "986488Hg";
                context.Set<BasicEntEvaluationBase>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            BasicEntEvaluationBase v1 = new BasicEntEvaluationBase();
            BasicEntEvaluationBase v2 = new BasicEntEvaluationBase();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.EnterpriseId = "4Vu61FW5";
                v1.EvluationEnt = "986488Hg";
                v2.EnterpriseId = "nWO";
                v2.EvluationEnt = "eSB";
                context.Set<BasicEntEvaluationBase>().Add(v1);
                context.Set<BasicEntEvaluationBase>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(BasicEntEvaluationBaseBatchVM));

            BasicEntEvaluationBaseBatchVM vm = rv.Model as BasicEntEvaluationBaseBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<BasicEntEvaluationBase>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as BasicEntEvaluationBaseListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
