﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Safeway.DataAccess;

namespace Safeway.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriseBasicInfo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("ComapanyName")
                        .HasMaxLength(300);

                    b.Property<int?>("CompanyScale");

                    b.Property<string>("CompanyType")
                        .HasMaxLength(30);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("District")
                        .HasMaxLength(200);

                    b.Property<Guid?>("FinanceInfoID");

                    b.Property<string>("ForeignCountry")
                        .HasMaxLength(100);

                    b.Property<string>("Industry")
                        .HasMaxLength(100);

                    b.Property<string>("LegalRepresentative")
                        .HasMaxLength(100);

                    b.Property<string>("MainProducts")
                        .HasMaxLength(100);

                    b.Property<string>("NoofEmployees")
                        .HasMaxLength(100);

                    b.Property<string>("Province")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasMaxLength(300);

                    b.Property<int?>("TermsofTrade");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.HasIndex("FinanceInfoID");

                    b.ToTable("EnterpriseBasicInfos");
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriseBusinessinfo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CertificateLevel")
                        .HasMaxLength(50);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Description")
                        .HasMaxLength(50);

                    b.Property<Guid>("EnterpriseBasicInfoId");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<string>("OriginalServiceCom")
                        .HasMaxLength(50);

                    b.Property<string>("OtherSafetyServiceType");

                    b.Property<int?>("SafetyServiceType");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.HasIndex("EnterpriseBasicInfoId")
                        .IsUnique();

                    b.ToTable("EnterpriseBusinessinfos");
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriseContact", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Dept")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasMaxLength(30);

                    b.Property<Guid>("EnterpriseBasicInfoId");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Position")
                        .HasMaxLength(50);

                    b.Property<string>("Tele")
                        .HasMaxLength(30);

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.HasIndex("EnterpriseBasicInfoId");

                    b.ToTable("EnterpriseContacts");
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriseFinanceInfo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account")
                        .HasMaxLength(50);

                    b.Property<string>("Bank")
                        .HasMaxLength(50);

                    b.Property<string>("Company_Address")
                        .HasMaxLength(50);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("CustomerReceiptReceiver")
                        .HasMaxLength(50);

                    b.Property<Guid>("EnterpriseBasicId");

                    b.Property<string>("Tele_Number")
                        .HasMaxLength(50);

                    b.Property<string>("UnifiedSocialCreditCode")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("EnterpriseFinanceInfos");
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriserYearYield", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("EnterpriseBasicInfoId");

                    b.Property<DateTime>("FiscalYear");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<decimal>("YearYieldValue")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("ID");

                    b.HasIndex("EnterpriseBasicInfoId");

                    b.ToTable("EnterpriserYearYields");
                });

            modelBuilder.Entity("Safeway.Model.EnterpriseReview.EnterpriseReviewElement", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("ElementName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int?>("EvaluationType");

                    b.Property<bool>("IsValid");

                    b.Property<int>("Level");

                    b.Property<int>("Order");

                    b.Property<string>("ParentElementId");

                    b.Property<int>("TotalScore");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("EnterpriseReviewElements");
                });

            modelBuilder.Entity("Safeway.Model.NormalEntEvaluation.NormalEntEvaluationBase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("EnterpriseId");

                    b.Property<DateTime>("EvaluationEndDate");

                    b.Property<string>("EvaluationLeader")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EvaluationStartDate");

                    b.Property<string>("EvaluationTeamMember")
                        .HasMaxLength(500);

                    b.Property<string>("EvluationEnt")
                        .HasMaxLength(300);

                    b.Property<bool>("IsValid");

                    b.Property<string>("ModuleOne")
                        .HasMaxLength(200);

                    b.Property<string>("ModuleThree")
                        .HasMaxLength(200);

                    b.Property<string>("ModuleTwo")
                        .HasMaxLength(200);

                    b.Property<string>("ReportLeader")
                        .HasMaxLength(200);

                    b.Property<int>("Status");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("NormalEntEvaluationBases");
                });

            modelBuilder.Entity("Safeway.Model.NormalEntEvaluation.NormalEntEvaluationItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ActualScore")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<string>("AssignTo")
                        .HasMaxLength(200);

                    b.Property<string>("BasicRuleRequirement")
                        .HasMaxLength(500);

                    b.Property<string>("ComplianceStandard")
                        .HasMaxLength(500);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("EvaluationDescription");

                    b.Property<int?>("EvaluationType");

                    b.Property<Guid>("LevelFourID");

                    b.Property<string>("LevelOneElement")
                        .HasMaxLength(300);

                    b.Property<string>("LevelThreeElement")
                        .HasMaxLength(300);

                    b.Property<string>("LevelTwoElement")
                        .HasMaxLength(300);

                    b.Property<string>("NormalEntEvaluationBaseId");

                    b.Property<decimal>("StandardScore")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<bool>("UnInvolved");

                    b.Property<bool>("UnMatched");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("NormalEntEvaluationItems");
                });

            modelBuilder.Entity("Safeway.Model.NormalEntEvaluation.NormalEntEvaluationUnmatchedItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<decimal>("Deduction")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<decimal>("DeductionReference")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("NormalEntEvaluationBaseId");

                    b.Property<string>("SmallEntEvaluationItemId");

                    b.Property<string>("UnMatchedItemDescription")
                        .HasMaxLength(500);

                    b.Property<string>("UnMatchedItemReferDescription")
                        .HasMaxLength(500);

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("NormalEntEvaluationUnmatchedItems");
                });

            modelBuilder.Entity("Safeway.Model.SmallEntEvaluation.SmallEntEvaluationBase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("EnterpriseId");

                    b.Property<DateTime>("EvaluationEndDate");

                    b.Property<string>("EvaluationLeader")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("EvaluationStartDate");

                    b.Property<string>("EvaluationTeamMember")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("EvluationEnt")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<bool>("IsValid");

                    b.Property<string>("ModuleOne")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ModuleThree")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ModuleTwo")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ReportLeader")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Status");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("smallEntEvaluationBases");
                });

            modelBuilder.Entity("Safeway.Model.SmallEntEvaluation.SmallEntEvaluationItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ActualScore")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<string>("AssignTo")
                        .HasMaxLength(200);

                    b.Property<string>("BasicRuleRequirement")
                        .HasMaxLength(500);

                    b.Property<string>("ComplianceStandard")
                        .HasMaxLength(500);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("EvaluationDescription");

                    b.Property<int?>("EvaluationType");

                    b.Property<Guid>("LevelFourID");

                    b.Property<string>("LevelOneElement")
                        .HasMaxLength(300);

                    b.Property<string>("LevelThreeElement")
                        .HasMaxLength(300);

                    b.Property<string>("LevelTwoElement")
                        .HasMaxLength(300);

                    b.Property<string>("SmallEntEvaluationBaseId");

                    b.Property<decimal>("StandardScore")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<bool>("UnInvolved");

                    b.Property<bool>("UnMatched");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("SmallEntEvaluationItems");
                });

            modelBuilder.Entity("Safeway.Model.SmallEntEvaluation.SmallEntEvaluationUnMatchedItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<decimal>("Deduction")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<decimal>("DeductionReference")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("SmallEntEvaluationBaseId");

                    b.Property<string>("SmallEntEvaluationItemId");

                    b.Property<string>("UnMatchedItemDescription")
                        .HasMaxLength(500);

                    b.Property<string>("UnMatchedItemReferDescription")
                        .HasMaxLength(500);

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("SmallEntEvaluationUnMatchedItems");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.ActionLog", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ActionTime");

                    b.Property<string>("ActionUrl")
                        .HasMaxLength(250);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<double>("Duration");

                    b.Property<string>("IP")
                        .HasMaxLength(50);

                    b.Property<string>("ITCode")
                        .HasMaxLength(50);

                    b.Property<int>("LogType");

                    b.Property<string>("ModuleName")
                        .HasMaxLength(50);

                    b.Property<string>("Remark");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("ActionLogs");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.DataPrivilege", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid?>("DomainId");

                    b.Property<Guid?>("GroupId");

                    b.Property<string>("RelateId");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<Guid?>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("DomainId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("DataPrivileges");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FileAttachment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<byte[]>("FileData");

                    b.Property<string>("FileExt")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<string>("GroupName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsTemprory");

                    b.Property<long>("Length");

                    b.Property<string>("Path");

                    b.Property<int?>("SaveFileMode");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<DateTime>("UploadTime");

                    b.HasKey("ID");

                    b.ToTable("FileAttachments");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkAction", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("ModuleId");

                    b.Property<string>("Parameter")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.HasIndex("ModuleId");

                    b.ToTable("FrameworkActions");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkArea", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("FrameworkAreas");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkDomain", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("DomainAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("DomainName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("DomainPort");

                    b.Property<string>("EntryUrl");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("FrameworkDomains");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkGroup", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("GroupRemark");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("FrameworkGroups");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkMenu", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionName");

                    b.Property<string>("ClassName");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<int?>("DisplayOrder")
                        .IsRequired();

                    b.Property<Guid?>("DomainId");

                    b.Property<bool>("FolderOnly");

                    b.Property<string>("ICon")
                        .HasMaxLength(50);

                    b.Property<bool>("IsInherit");

                    b.Property<bool?>("IsInside")
                        .IsRequired();

                    b.Property<bool>("IsPublic");

                    b.Property<string>("MethodName");

                    b.Property<string>("ModuleName");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("ParentId");

                    b.Property<bool>("ShowOnMenu");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.HasIndex("DomainId");

                    b.HasIndex("ParentId");

                    b.ToTable("FrameworkMenus");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkModule", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AreaId");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NameSpace");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.HasIndex("AreaId");

                    b.ToTable("FrameworkModules");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkRole", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RoleRemark");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("ID");

                    b.ToTable("FrameworkRoles");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserBase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("CellPhone");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("HomePhone")
                        .HasMaxLength(30);

                    b.Property<string>("ITCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsValid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<Guid?>("PhotoId");

                    b.Property<int?>("Sex");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("ZipCode");

                    b.HasKey("ID");

                    b.HasIndex("PhotoId");

                    b.ToTable("FrameworkUsers");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserGroup", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("GroupId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("FrameworkUserGroup");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserRole", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("RoleId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<Guid>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("FrameworkUserRole");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FunctionPrivilege", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Allowed")
                        .IsRequired();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("MenuItemId");

                    b.Property<Guid?>("RoleId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<Guid?>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("MenuItemId");

                    b.ToTable("FunctionPrivileges");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.SearchCondition", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Condition");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime");

                    b.Property<string>("Name");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<Guid>("UserId");

                    b.Property<string>("VMName");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("SearchConditions");
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriseBasicInfo", b =>
                {
                    b.HasOne("Safeway.Model.Enterprise.EnterpriseFinanceInfo", "FinanceInfo")
                        .WithMany()
                        .HasForeignKey("FinanceInfoID");
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriseBusinessinfo", b =>
                {
                    b.HasOne("Safeway.Model.Enterprise.EnterpriseBasicInfo")
                        .WithOne("EnterpriseBusinessinfo")
                        .HasForeignKey("Safeway.Model.Enterprise.EnterpriseBusinessinfo", "EnterpriseBasicInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriseContact", b =>
                {
                    b.HasOne("Safeway.Model.Enterprise.EnterpriseBasicInfo")
                        .WithMany("EnterpriseContacts")
                        .HasForeignKey("EnterpriseBasicInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Safeway.Model.Enterprise.EnterpriserYearYield", b =>
                {
                    b.HasOne("Safeway.Model.Enterprise.EnterpriseBasicInfo")
                        .WithMany("EnterpriserYearYields")
                        .HasForeignKey("EnterpriseBasicInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.DataPrivilege", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkDomain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainId");

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkAction", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkModule", "Module")
                        .WithMany("Actions")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkMenu", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkDomain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainId");

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkMenu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkModule", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkArea", "Area")
                        .WithMany("Modules")
                        .HasForeignKey("AreaId");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserBase", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FileAttachment", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserGroup", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkGroup", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserRole", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FunctionPrivilege", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkMenu", "MenuItem")
                        .WithMany("Privileges")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.SearchCondition", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany("SearchConditions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
