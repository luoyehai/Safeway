using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using Safeway.Controllers;
using Safeway.ViewModel.EnterpriseReviewElementVMs;
using Safeway.Model.EnterpriseReview;
using Safeway.DataAccess;

namespace Safeway.Test
{
    [TestClass]
    public class EnterpriseReviewElementApiTest
    {
        private EnterpriseReviewElementApiController _controller;
        private string _seed;

        public EnterpriseReviewElementApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<EnterpriseReviewElementApiController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            string rv = _controller.Search(new EnterpriseReviewElementApiSearcher());
            Assert.IsTrue(string.IsNullOrEmpty(rv)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            EnterpriseReviewElementApiVM vm = _controller.CreateVM<EnterpriseReviewElementApiVM>();
            EnterpriseReviewElement v = new EnterpriseReviewElement();
            
            v.ElementName = "C6w5ex9g";
            v.Order = 76;
            v.TotalScore = 18;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriseReviewElement>().FirstOrDefault();
                
                Assert.AreEqual(data.ElementName, "C6w5ex9g");
                Assert.AreEqual(data.Order, 76);
                Assert.AreEqual(data.TotalScore, 18);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            EnterpriseReviewElement v = new EnterpriseReviewElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ElementName = "C6w5ex9g";
                v.Order = 76;
                v.TotalScore = 18;
                context.Set<EnterpriseReviewElement>().Add(v);
                context.SaveChanges();
            }

            EnterpriseReviewElementApiVM vm = _controller.CreateVM<EnterpriseReviewElementApiVM>();
            var oldID = v.ID;
            v = new EnterpriseReviewElement();
            v.ID = oldID;
       		
            v.ElementName = "SDzYl";
            v.Order = 70;
            v.TotalScore = 7;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ElementName", "");
            vm.FC.Add("Entity.Order", "");
            vm.FC.Add("Entity.TotalScore", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<EnterpriseReviewElement>().FirstOrDefault();
 				
                Assert.AreEqual(data.ElementName, "SDzYl");
                Assert.AreEqual(data.Order, 70);
                Assert.AreEqual(data.TotalScore, 7);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            EnterpriseReviewElement v = new EnterpriseReviewElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ElementName = "C6w5ex9g";
                v.Order = 76;
                v.TotalScore = 18;
                context.Set<EnterpriseReviewElement>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            EnterpriseReviewElement v1 = new EnterpriseReviewElement();
            EnterpriseReviewElement v2 = new EnterpriseReviewElement();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ElementName = "C6w5ex9g";
                v1.Order = 76;
                v1.TotalScore = 18;
                v2.ElementName = "SDzYl";
                v2.Order = 70;
                v2.TotalScore = 7;
                context.Set<EnterpriseReviewElement>().Add(v1);
                context.Set<EnterpriseReviewElement>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<EnterpriseReviewElement>().Count(), 2);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
