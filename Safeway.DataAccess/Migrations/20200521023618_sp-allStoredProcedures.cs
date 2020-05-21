using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class spallStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasicEntEvaluationBases",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<string>(nullable: true),
                    EnterpriseId = table.Column<string>(nullable: false),
                    EvluationEnt = table.Column<string>(maxLength: 300, nullable: false),
                    EvaluationStartDate = table.Column<DateTime>(nullable: false),
                    EvaluationEndDate = table.Column<DateTime>(nullable: false),
                    Evaluator = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: true),
                    ReportFileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicEntEvaluationBases", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BasicEntEvaluationItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    CheckElementName = table.Column<string>(nullable: true),
                    CheckContent = table.Column<string>(nullable: true),
                    CheckPoint = table.Column<string>(nullable: true),
                    UnInvolved = table.Column<bool>(nullable: false),
                    Regulation = table.Column<string>(nullable: true),
                    RetificationComments = table.Column<string>(nullable: true),
                    CurrentState = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicEntEvaluationItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BasicEntEvaluationItemStateTracks",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BasicEntEvaluationItemID = table.Column<Guid>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicEntEvaluationItemStateTracks", x => x.ID);
                });

            var sp_SmEnt_Get_EvaluationGeneralInfo = @"CREATE PROCEDURE [dbo].[SmEnt_Get_EvaluationGeneralInfo]
                    @baseId  nvarchar(200)
                    AS
                    BEGIN

	                    SET NOCOUNT ON;

	                    Declare @EvaluationGeneral Table (
	                        EnterpriseID uniqueidentifier null,
		                    ComapanyName nvarchar(300) null,
		                    Industry nvarchar(300) null,
		                    EvaluationStartDate datetime null,
		                    EvaluationEndDate datetime null,
		                    LegalRepresentative nvarchar(300) null,
		                    LegalRepTel nvarchar(300) null,
		                    LegalRepMobile nvarchar(300) null,
		                    ContactName nvarchar(300) null,
		                    ContactTel nvarchar(300) null,
		                    ContactFax nvarchar(300) null,
		                    ContactMobile nvarchar(300) null,
		                    ContactEmail nvarchar(300) null,
		                    EvaluationLeader nvarchar(300) null,
		                    EvaluationTeamMember nvarchar(300) null
	                    ) 
	
	                    INSERT INTO @EvaluationGeneral(
		                    EnterpriseID,
		                    ComapanyName,
		                    Industry,
		                    EvaluationStartDate,
		                    EvaluationEndDate,
		                    EvaluationLeader,
		                    EvaluationTeamMember
	                    )
	                    SELECT bi.ID, bi.ComapanyName,bi.Industry,b.EvaluationStartDate,b.EvaluationEndDate,b.EvaluationLeader,b.EvaluationTeamMember
	                    FROM [dbo].[smallEntEvaluationBases] b
	                    INNER JOIN [dbo].[EnterpriseBasicInfos] bi
	                    ON b.EnterpriseId  = bi.ID
	                    WHERE b.ID = @baseId  

	                    UPDATE E	
	                    SET E.LegalRepresentative = C.Name,E.LegalRepTel = C.Tele,E.LegalRepMobile = C.MobilePhone
	                    FROM @EvaluationGeneral E
	                    INNER JOIN [dbo].[EnterpriseContacts] C
	                    ON E.EnterpriseID = C.EnterpriseBasicInfoId
	                    WHERE C.Position = N'法人'

	                    UPDATE E
	                    SET E.ContactName = C.Name,E.ContactTel = C.Tele, E.ContactMobile = C.MobilePhone, E.ContactEmail = C.Email
                        FROM @EvaluationGeneral E
	                    INNER JOIN [dbo].[EnterpriseContacts] C
	                    ON E.EnterpriseID = C.EnterpriseBasicInfoId
	                    WHERE C.Position = N'主要负责人'


	                    SELECT * FROM @EvaluationGeneral
	
                    END";

            migrationBuilder.Sql(sp_SmEnt_Get_EvaluationGeneralInfo);

            var sp_SmEnt_Get_EvaluationReport = @"CREATE PROCEDURE [dbo].[SmEnt_Get_EvaluationReport] 
	                        @baseId  nvarchar(200),
	                        @type INT
                        AS
                        BEGIN

	                        SET NOCOUNT ON;

	                        DECLARE @UnmatchedItem TABLE(
	  
	                            UnmatchedItemDes nvarchar(max) null,
		                        EvaluationBaseId nvarchar(200) null,
		                        EvaluationItemId nvarchar(200) null,
		                        EvaluationType bit null

	                        )
	                        INSERT INTO @UnmatchedItem(EvaluationBaseId,EvaluationItemId,UnmatchedItemDes, EvaluationType)
	                        SELECT @baseId, [SmallEntEvaluationItemId],UnMatchedItemDescription,EvaluationType
	                        FROM [dbo].[SmallEntEvaluationUnMatchedItems] AS u
	                        WHERE [SmallEntEvaluationBaseId] = @baseId AND u.UnMatchedItemDescription != N'不涉及'


	                        SELECT i.ID, i.LevelFourID,i.ComplianceStandard,i.ActualScore,i.ScoringMethod, 0.00 AS Deduction,i.UnInvolved AS UnInvolved,i.StandardScore AS StandardScore,
	                        CASE WHEN u.UnmatchedItemDes IS NULL THEN ''
	                        ELSE u.UnmatchedItemDes END AS UnMatchedItemDescription, i.LevelOneElement, i.LevelTwoElement
	                        FROM [dbo].[SmallEntEvaluationItems] i
	                        INNER JOIN @UnmatchedItem u
	                        ON i.ID = u.EvaluationItemId
	                        --INNER JOIN [dbo].[smallEntEvaluationBases] b
	                        --ON i.SmallEntEvaluationBaseId = b.ID
	                        --INNER JOIN [dbo].[EnterpriseBasicInfos] bi
	                        --ON b.EnterpriseId  = bi.ID
	                        WHERE i.[SmallEntEvaluationBaseId] = @baseId  AND u.EvaluationType = @type
	                        ORDER BY i.LevelOneOrder,i.LevelTwoOrder,i.LevelThreeOrder,i.LevelFourOrder
	
                        END";
            migrationBuilder.Sql(sp_SmEnt_Get_EvaluationReport);


            var sp_SmEnt_Get_EvaluationTeamInfo = @"CREATE PROCEDURE [dbo].[SmEnt_Get_EvaluationTeamInfo] 
	                    @baseId  nvarchar(200)
                    AS
                    BEGIN

	                    SET NOCOUNT ON;

	                    Declare @EvaluationTeam Table (
	                        ID uniqueidentifier null,
                            ProjectID nvarchar(300) null,
		                    SmallEntEvaBaseID nvarchar(300) null,
		                    Name nvarchar(300) null,
		                    Position nvarchar(300) null,
		                    Tel nvarchar(300) null,
		                    Mobile nvarchar(300) null,
		                    Email nvarchar(300) null
	                    ) 
	
	                    INSERT INTO @EvaluationTeam(
	                        ID,
		                    ProjectID,
		                    SmallEntEvaBaseID,
		                    Name,
		                    Position,
		                    Tel,
		                    Mobile,
		                    Email
	                    )
	                    SELECT NEWID(),B.ProjectId,B.ID,b.EvaluationLeader,N'组长',u.HomePhone,u.CellPhone,u.Email
	                    FROM [dbo].[smallEntEvaluationBases] b
	                    INNER JOIN [dbo].[FrameworkUsers] u
	                    ON b.EvaluationLeader = u.Name
	                    where b.ID = @baseId

	                    --Declare Variable
	                    DECLARE	@Name nvarchar(300) ,
			                    @Tel nvarchar(300) ,
			                    @Mobile nvarchar(300) ,
			                    @Email nvarchar(300) 
	                    DECLARE @MessageOutput VARCHAR(100)
	                    --Declare Cursor
	                    DECLARE Contact_Cursor CURSOR FOR 
                        SELECT Name, HomePhone, CellPhone, Email FROM [dbo].[FrameworkUsers]

	                    OPEN Contact_Cursor 

                    FETCH NEXT FROM Contact_Cursor INTO
                        @Name, @Tel, @Mobile,@Email

                    WHILE @@FETCH_STATUS = 0
                    BEGIN
                        INSERT INTO @EvaluationTeam(
	                                ID,
				                    ProjectID,
				                    SmallEntEvaBaseID,
				                    Name,
				                    Position,
				                    Tel,
				                    Mobile,
				                    Email
	                          )
                        SELECT NEWID(),ProjectId,ID,@Name,N'成员',@Tel,@Mobile,@Email
	                    FROM [dbo].[smallEntEvaluationBases] 
	                    WHERE ID  = @baseId AND CHARINDEX(@Name,EvaluationTeamMember) > 0 



                        RAISERROR(@MessageOutput,0,1) WITH NOWAIT

                    FETCH NEXT FROM Contact_Cursor INTO
                        @Name, @Tel, @Mobile,@Email
                    END
                    CLOSE Contact_Cursor
                    DEALLOCATE Contact_Cursor


                    SELECT * FROM @EvaluationTeam
                    END";
            migrationBuilder.Sql(sp_SmEnt_Get_EvaluationTeamInfo);

            var sp_SmEnt_Get_EvaluationTemplate = @"CREATE PROCEDURE [dbo].[SmEnt_Get_EvaluationTemplate] 
	                    @baseId  nvarchar(200)
                    AS
                    BEGIN

	                    SET NOCOUNT ON;

	                    DECLARE @UnmatchedItem TABLE(
	  
	                        UnmatchedItemDes nvarchar(max) null,
		                    EvaluationBaseId nvarchar(200) null,
		                    EvaluationItemId nvarchar(200) null
	                    )
	                    INSERT INTO @UnmatchedItem(EvaluationBaseId,EvaluationItemId,UnmatchedItemDes)
	                    SELECT @baseId, [SmallEntEvaluationItemId],STUFF(
                            (SELECT DISTINCT 'n' + [UnMatchedItemDescription]
                            FROM [dbo].[SmallEntEvaluationUnMatchedItems]
                            WHERE [SmallEntEvaluationBaseId] = @baseId AND [SmallEntEvaluationItemId] = u.[SmallEntEvaluationItemId]
                            FOR XML PATH (''))
                            , 1, 1, '')  AS UnMatchedItems
	                    FROM [dbo].[SmallEntEvaluationUnMatchedItems] AS u
	                    WHERE [SmallEntEvaluationBaseId] = @baseId
	                    GROUP BY [SmallEntEvaluationItemId]
	

	                    SELECT i.ID, i.LevelFourID,i.ComplianceStandard,i.ActualScore,i.ScoringMethod, 0.00 AS Deduction,i.UnInvolved AS UnInvolved,i.StandardScore AS StandardScore,
	                    CASE WHEN u.UnmatchedItemDes IS NULL THEN ''
	                    ELSE u.UnmatchedItemDes END AS UnMatchedItemDescription, i.LevelOneElement, i.LevelTwoElement
	                    FROM [dbo].[SmallEntEvaluationItems] i
	                    LEFT JOIN @UnmatchedItem u
	                    ON i.ID = u.EvaluationItemId
	                    WHERE i.[SmallEntEvaluationBaseId] = @baseId
	                    ORDER BY i.LevelOneOrder,i.LevelTwoOrder,i.LevelThreeOrder,i.LevelFourOrder
	

	                    --SELECT newid() as ID, i.LevelFourID,i.ComplianceStandard,i.ActualScore,i.ScoringMethod, 
	                    --        CASE WHEN u.Deduction is null THEN '0.0'
	                    --		ELSE u.Deduction END AS Deduction,
	                    --		CASE WHEN u.UnMatchedItemDescription is null THEN ''
	                    --		ELSE u.UnMatchedItemDescription END AS UnMatchedItemDescription
	                    --FROM [dbo].[SmallEntEvaluationItems] i
	                    --LEFT JOIN [dbo].[SmallEntEvaluationUnMatchedItems] u
	                    --ON i.ID =  u.SmallEntEvaluationItemId
	                    --WHERE i.[SmallEntEvaluationBaseId] = @baseId
                    END";
            migrationBuilder.Sql(sp_SmEnt_Get_EvaluationTemplate);

            var sp_SmEnt_Get_EvaUnmatchedTemplate = @"CREATE PROCEDURE [dbo].[SmEnt_Get_EvaUnmatchedTemplate] 
	                    @baseId  nvarchar(200)
                    AS
                    BEGIN

	                    SET NOCOUNT ON;

	                    DECLARE @UnmatchedItem TABLE(
	  
	                        UnmatchedItemDes nvarchar(max) null,
		                    EvaluationBaseId nvarchar(200) null,
		                    EvaluationItemId nvarchar(200) null
	                    )
	                    INSERT INTO @UnmatchedItem(EvaluationBaseId,EvaluationItemId,UnmatchedItemDes)
	                    SELECT @baseId, [SmallEntEvaluationItemId],STUFF(
                            (SELECT DISTINCT 'n' + [UnMatchedItemDescription]
                            FROM [dbo].[SmallEntEvaluationUnMatchedItems]
                            WHERE [SmallEntEvaluationBaseId] = @baseId AND [SmallEntEvaluationItemId] = u.[SmallEntEvaluationItemId]
                            FOR XML PATH (''))
                            , 1, 1, '')  AS UnMatchedItems
	                    FROM [dbo].[SmallEntEvaluationUnMatchedItems] AS u
	                    WHERE [SmallEntEvaluationBaseId] = @baseId AND u.UnMatchedItemDescription != N'不涉及'
	                    GROUP BY [SmallEntEvaluationItemId]
	
	                    SELECT i.ID, i.LevelFourID,i.ComplianceStandard,i.ActualScore,i.ScoringMethod, 0.00 AS Deduction,i.UnInvolved AS UnInvolved,i.StandardScore AS StandardScore,
	                    CASE WHEN u.UnmatchedItemDes IS NULL THEN ''
	                    ELSE u.UnmatchedItemDes END AS UnMatchedItemDescription, i.LevelOneElement, i.LevelTwoElement
	                    FROM [dbo].[SmallEntEvaluationItems] i
	                    INNER JOIN @UnmatchedItem u
	                    ON i.ID = u.EvaluationItemId
	                    WHERE i.[SmallEntEvaluationBaseId] = @baseId
	                    ORDER BY i.LevelOneOrder,i.LevelTwoOrder,i.LevelThreeOrder,i.LevelFourOrder
	

	                    --SELECT newid() as ID, i.LevelFourID,i.ComplianceStandard,i.ActualScore,i.ScoringMethod, 
	                    --        CASE WHEN u.Deduction is null THEN '0.0'
	                    --		ELSE u.Deduction END AS Deduction,
	                    --		CASE WHEN u.UnMatchedItemDescription is null THEN ''
	                    --		ELSE u.UnMatchedItemDescription END AS UnMatchedItemDescription
	                    --FROM [dbo].[SmallEntEvaluationItems] i
	                    --LEFT JOIN [dbo].[SmallEntEvaluationUnMatchedItems] u
	                    --ON i.ID =  u.SmallEntEvaluationItemId
	                    --WHERE i.[SmallEntEvaluationBaseId] = @baseId
                    END";
            migrationBuilder.Sql(sp_SmEnt_Get_EvaUnmatchedTemplate);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicEntEvaluationBases");

            migrationBuilder.DropTable(
                name: "BasicEntEvaluationItems");

            migrationBuilder.DropTable(
                name: "BasicEntEvaluationItemStateTracks");
        }
    }
}
