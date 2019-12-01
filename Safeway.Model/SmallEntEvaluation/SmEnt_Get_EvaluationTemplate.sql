USE [SafeWay_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SmEnt_Get_EvaluationTemplate]    Script Date: 12/1/2019 2:12:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- exec SmEnt_Get_EvaluationTemplate 'ee9e9910-8b23-4af4-a6ce-46fdc6903c51'
CREATE PROCEDURE [dbo].[SmEnt_Get_EvaluationTemplate] 
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
	

	SELECT i.ID, i.LevelFourID,i.ComplianceStandard,i.ActualScore,i.ScoringMethod, 0.00 AS Deduction,
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
END


GO


