using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.ProjectBasicInfoVMs;
using Safeway.Model.Project;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class ProjectBasicInfoControllerTest
    {
        private ProjectBasicInfoController _controller;
        private string _seed;

        public ProjectBasicInfoControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ProjectBasicInfoController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ProjectBasicInfoListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ProjectBasicInfoVM));

            ProjectBasicInfoVM vm = rv.Model as ProjectBasicInfoVM;
            ProjectBasicInfo v = new ProjectBasicInfo();
			
            v.ProjectName = "lHhk51hgA";
            v.ProjectMember = "123";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProjectBasicInfo>().FirstOrDefault();
				
                Assert.AreEqual(data.ProjectName, "lHhk51hgA");
                Assert.AreEqual(data.ProjectMember, 75);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ProjectBasicInfo v = new ProjectBasicInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ProjectName = "lHhk51hgA";
                v.ProjectMember = "232";
                context.Set<ProjectBasicInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ProjectBasicInfoVM));

            ProjectBasicInfoVM vm = rv.Model as ProjectBasicInfoVM;
            v = new ProjectBasicInfo();
            v.ID = vm.Entity.ID;
       		
            v.ProjectName = "y6jTNUn";
            v.ProjectMember = "asdadw";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ProjectName", "");
            vm.FC.Add("Entity.ProjectMember", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ProjectBasicInfo>().FirstOrDefault();
 				
                Assert.AreEqual(data.ProjectName, "y6jTNUn");
                Assert.AreEqual(data.ProjectMember, 5);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ProjectBasicInfo v = new ProjectBasicInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ProjectName = "lHhk51hgA";
                v.ProjectMember = "erwe";
                context.Set<ProjectBasicInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ProjectBasicInfoVM));

            ProjectBasicInfoVM vm = rv.Model as ProjectBasicInfoVM;
            v = new ProjectBasicInfo();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ProjectBasicInfo>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ProjectBasicInfo v = new ProjectBasicInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ProjectName = "lHhk51hgA";
                v.ProjectMember = "123123";
                context.Set<ProjectBasicInfo>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ProjectBasicInfo v1 = new ProjectBasicInfo();
            ProjectBasicInfo v2 = new ProjectBasicInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ProjectName = "lHhk51hgA";
                v1.ProjectMember = "45235";
                v2.ProjectName = "y6jTNUn";
                v2.ProjectMember = "123123";
                context.Set<ProjectBasicInfo>().Add(v1);
                context.Set<ProjectBasicInfo>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ProjectBasicInfoBatchVM));

            ProjectBasicInfoBatchVM vm = rv.Model as ProjectBasicInfoBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ProjectBasicInfo>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as ProjectBasicInfoListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
