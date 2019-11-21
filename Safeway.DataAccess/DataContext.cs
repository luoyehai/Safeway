using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using Safeway.Model.Enterprise;
using Safeway.Model.EnterpriseReview;
using Safeway.Model.NormalEntEvaluation;
using Safeway.Model.SmallEntEvaluation;

namespace Safeway.DataAccess
{
    public class DataContext : FrameworkContext
    {

        public DbSet<EnterpriseReviewElement> EnterpriseReviewElements { get; set; }

        #region Enterprise
        public DbSet<EnterpriseContact> EnterpriseContacts { get; set; }
        public DbSet<EnterpriseBasicInfo> EnterpriseBasicInfos { get; set; }
        public DbSet<EnterpriseBusinessinfo> EnterpriseBusinessinfos { get; set; }
        public DbSet<EnterpriseFinanceInfo> EnterpriseFinanceInfos { get; set; }
        public DbSet<EnterpriserYearYield> EnterpriserYearYields { get; set; }
        #endregion

        #region NormalEnt
        public DbSet<NormalEntEvaluationBase> NormalEntEvaluationBases { get; set; }
        public DbSet<NormalEntEvaluationItem> NormalEntEvaluationItems { get; set; }
        public DbSet<NormalEntEvaluationUnmatchedItem> NormalEntEvaluationUnmatchedItems { get; set; }
        #endregion
        public DbSet<SmallEntEvaluationBase> smallEntEvaluationBases { get; set; }
        public DbSet<SmallEntEvaluationItem> SmallEntEvaluationItems { get; set; }
        public DbSet<SmallEntEvaluationUnMatchedItem> SmallEntEvaluationUnMatchedItems { get; set; }
        #region SmallEnt
        #region SmExportTemplate
        #endregion

        #endregion
        public DataContext(string cs, DBTypeEnum dbtype)
             : base(cs, dbtype)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Enterprise Guid auto generate
            modelBuilder.Entity<EnterpriseBasicInfo>()
            .HasKey(c => new { c.ID });
            modelBuilder.Entity<EnterpriseContact>()
            .HasKey(c => new { c.ID });
            modelBuilder.Entity<EnterpriserYearYield>()
            .HasKey(y => new { y.ID });
            modelBuilder.Entity<EnterpriseFinanceInfo>()
            .HasKey(c => new { c.ID });
            modelBuilder.Entity<EnterpriseBusinessinfo>()
            .HasKey(b => new { b.ID });
            #endregion

            #region Evaluation
            modelBuilder.Entity<NormalEntEvaluationBase>()
              .HasKey(c => new { c.ID });
            modelBuilder.Entity<NormalEntEvaluationItem>()
              .HasKey(c => new { c.ID });
            modelBuilder.Entity<NormalEntEvaluationUnmatchedItem>()
              .HasKey(c => new { c.ID });
            #endregion

            #region SmallEnt Set Primary Key
            modelBuilder.Entity<SmallEntEvaluationBase>()
              .HasKey(c => new { c.ID });
            modelBuilder.Entity<SmallEntEvaluationItem>()
              .HasKey(c => new { c.ID });
            modelBuilder.Entity<SmallEntEvaluationUnMatchedItem>()
              .HasKey(c => new { c.ID });

            #endregion

        }

    }

    /// <summary>
    /// 为EF的Migration准备的辅助类，填写完整连接字符串和数据库类型
    /// 就可以使用Add-Migration和Update-Database了
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("Server=SCNSZHS0016\\SHAREPOINT;Database=SafeWay_Dev;Trusted_Connection=True;MultipleActiveResultSets=true", DBTypeEnum.SqlServer);
        }
    }


}
