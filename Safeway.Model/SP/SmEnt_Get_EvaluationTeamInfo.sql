USE [SafeWay_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SmEnt_Get_EvaluationGeneralInfo]    Script Date: 12/4/2019 9:35:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- EXEC SmEnt_Get_EvaluationTeamInfo 'EE9E9910-8B23-4AF4-A6CE-46FDC6903C51'
ALTER PROCEDURE [dbo].[SmEnt_Get_EvaluationTeamInfo] 
	@baseId  nvarchar(200)
AS
BEGIN

	SET NOCOUNT ON;

	Declare @EvaluationTeam Table (
        ProjectID uniqueidentifier null,
		SmallEntEvaBaseID uniqueidentifier null,
		Name nvarchar(300) null,
		Position nvarchar(300) null,
		Tel nvarchar(300) null,
		Mobile nvarchar(300) null,
		Email nvarchar(300) null
	) 
	
	INSERT INTO @EvaluationTeam(
		ProjectID,
		SmallEntEvaBaseID,
		Name,
		Position,
		Tel,
		Mobile,
		Email
	)
	SELECT B.ProjectId,B.ID,b.EvaluationLeader,N'组长',u.HomePhone,u.CellPhone,u.Email
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
				ProjectID,
				SmallEntEvaBaseID,
				Name,
				Position,
				Tel,
				Mobile,
				Email
	      )
    SELECT ProjectId,ID,@Name,N'成员',@Tel,@Mobile,@Email
	FROM [dbo].[smallEntEvaluationBases] 
	WHERE ID  = @baseId AND CHARINDEX(@Name,EvaluationTeamMember) > 0 



    RAISERROR(@MessageOutput,0,1) WITH NOWAIT

FETCH NEXT FROM Contact_Cursor INTO
    @Name, @Tel, @Mobile,@Email
END
CLOSE Contact_Cursor
DEALLOCATE Contact_Cursor


SELECT * FROM @EvaluationTeam
END





GO


