USE [SafeWay_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SmEnt_Get_EvaluationGeneralInfo]    Script Date: 12/4/2019 4:46:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SmEnt_Get_EvaluationGeneralInfo] 
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
	
END

GO






GO


