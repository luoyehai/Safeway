USE [SafeWay_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SmEnt_Get_EvaluationReport]    Script Date: 12/4/2019 3:48:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- exec SmEnt_Get_EvaluationReport 'EE9E9910-8B23-4AF4-A6CE-46FDC6903C51',  0
CREATE PROCEDURE [dbo].[SmEnt_Get_EvaluationReport] 
	@baseId  nvarchar(200),
	@type INT
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
	

	SELECT i.ID, i.LevelFourID,i.ComplianceStandard,i.ActualScore,i.ScoringMethod, 0.00 AS Deduction,
	CASE WHEN u.UnmatchedItemDes IS NULL THEN ''
	ELSE u.UnmatchedItemDes END AS UnMatchedItemDescription, i.LevelOneElement, i.LevelTwoElement
	FROM [dbo].[SmallEntEvaluationItems] i
	INNER JOIN @UnmatchedItem u
	ON i.ID = u.EvaluationItemId
	--INNER JOIN [dbo].[smallEntEvaluationBases] b
	--ON i.SmallEntEvaluationBaseId = b.ID
	--INNER JOIN [dbo].[EnterpriseBasicInfos] bi
	--ON b.EnterpriseId  = bi.ID
	WHERE i.[SmallEntEvaluationBaseId] = @baseId  AND I.EvaluationType = @type
	ORDER BY i.LevelOneOrder,i.LevelTwoOrder,i.LevelThreeOrder,i.LevelFourOrder
	
END





GO


