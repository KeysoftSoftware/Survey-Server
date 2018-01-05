IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_Sheelon]'))
DROP VIEW [dbo].[View_Sheelon]
;
CREATE VIEW [dbo].[View_Sheelon]
AS
SELECT        Id, Code, IsActive, CreatedBy, CreatedOn, LastUpdateBy, Version, name, openning, loginManagerId, shared, userId, F1, F2, F3,
                             (SELECT        COUNT(Id) AS Expr1
                               FROM            dbo.SheelonRelease
                               WHERE        (sheelonId = SH.Id)) AS ReleaseCount
FROM            dbo.Sheelon AS SH
;
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_SheelonQuestions]'))
DROP VIEW [dbo].[View_SheelonQuestions]
;
CREATE VIEW [dbo].[View_SheelonQuestions]
AS
SELECT        dbo.QRelease.fromDate, dbo.SheelonQuestion.sheelonId, dbo.SheelonQuestion.sortOrder, dbo.SheelonQuestion.isMandatory, dbo.SheelonQuestion.pageNo, dbo.SheelonQuestion.questionId, dbo.QText.text, 
                         dbo.QRelease.minSelections, dbo.QRelease.rightanswer, dbo.Question.qOptCount, dbo.SheelonQuestion.Id
FROM            dbo.QRelease INNER JOIN
                         dbo.Question ON dbo.QRelease.questionId = dbo.Question.Id INNER JOIN
                         dbo.SheelonQuestion ON dbo.Question.Id = dbo.SheelonQuestion.questionId INNER JOIN
                         dbo.QText ON dbo.QRelease.qTextId = dbo.QText.Id
;
