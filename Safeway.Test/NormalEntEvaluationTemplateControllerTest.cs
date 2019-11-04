using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.NormalEntEvaluationTemplateVMs;
using Safeway.Model.Evaluation;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class NormalEntEvaluationTemplateControllerTest
    {
        private NormalEntEvaluationTemplateController _controller;
        private string _seed;

        public NormalEntEvaluationTemplateControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<NormalEntEvaluationTemplateController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as NormalEntEvaluationTemplateListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationTemplateVM));

            NormalEntEvaluationTemplateVM vm = rv.Model as NormalEntEvaluationTemplateVM;
            NormalEntEvaluationTemplate v = new NormalEntEvaluationTemplate();
			
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluationTemplate>().FirstOrDefault();
				
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            NormalEntEvaluationTemplate v = new NormalEntEvaluationTemplate();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                context.Set<NormalEntEvaluationTemplate>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationTemplateVM));

            NormalEntEvaluationTemplateVM vm = rv.Model as NormalEntEvaluationTemplateVM;
            v = new NormalEntEvaluationTemplate();
            v.ID = vm.Entity.ID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<NormalEntEvaluationTemplate>().FirstOrDefault();
 				
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            NormalEntEvaluationTemplate v = new NormalEntEvaluationTemplate();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                context.Set<NormalEntEvaluationTemplate>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationTemplateVM));

            NormalEntEvaluationTemplateVM vm = rv.Model as NormalEntEvaluationTemplateVM;
            v = new NormalEntEvaluationTemplate();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<NormalEntEvaluationTemplate>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            NormalEntEvaluationTemplate v = new NormalEntEvaluationTemplate();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<NormalEntEvaluationTemplate>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            NormalEntEvaluationTemplate v1 = new NormalEntEvaluationTemplate();
            NormalEntEvaluationTemplate v2 = new NormalEntEvaluationTemplate();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                context.Set<NormalEntEvaluationTemplate>().Add(v1);
                context.Set<NormalEntEvaluationTemplate>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(NormalEntEvaluationTemplateBatchVM));

            NormalEntEvaluationTemplateBatchVM vm = rv.Model as NormalEntEvaluationTemplateBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<NormalEntEvaluationTemplate>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as NormalEntEvaluationTemplateListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
