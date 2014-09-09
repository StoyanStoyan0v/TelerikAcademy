
CREATE PROCEDURE dbo.usp_GetRelatedItems
	@ItemId int AS
BEGIN

IF NOT EXIST (SELECT * FROM Cache.dbo.GetRelatedItems WHERE ItemId=@ItemId)
	BEGIN 
		INSERT INTO Cache.dbo.GetRelatedItems
			(ItemID, RelatedID,RelatedItemName)
		FROM dbo.BigComplicatedView
		WHERE SoldItemId = @ItemId;
	END

SELECT *
FROM Cache.dbo.GetRelatedItems
WHERE ItemID = @ItemId

END 

GO