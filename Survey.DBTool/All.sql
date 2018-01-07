IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_Sheelon]'))
DROP VIEW [dbo].[View_Sheelon]
;
CREATE VIEW [dbo].[View_Sheelon]
AS
SELECT        Id, Code, IsActive, CreatedBy, CreatedOn, LastUpdateBy, Version, name, openning, loginManagerId, shared, userId, F1, F2, F3,
                             (SELECT        COUNT(Id) AS Expr1
                               FROM            dbo.SRelease
                               WHERE        (sheelonId = SH.Id)) AS ReleaseCount
FROM            dbo.Sheelon AS SH
;
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_QRelease]'))
DROP VIEW [dbo].[View_QRelease]
;
CREATE VIEW [dbo].[View_QRelease]
AS
SELECT        dbo.QRelease.Id, dbo.QRelease.questionId, dbo.QRelease.fromDate, dbo.QRelease.toDate, dbo.QText.text, dbo.QText.textLong, dbo.QText.textPopup, dbo.QText.textPrint, dbo.QText.textMobile, dbo.QText.picture, 
                         dbo.QRelease.maxOptCount, dbo.QRelease.minSelections, dbo.QRelease.rightanswer, dbo.QRelease.qTypeId
FROM            dbo.QRelease INNER JOIN
                         dbo.QText ON dbo.QRelease.qTextId = dbo.QText.Id
;
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_QReleaseOption]'))
DROP VIEW [dbo].[View_QReleaseOption]
;
CREATE VIEW [dbo].[View_QReleaseOption]
AS
SELECT        dbo.QReleaseOption.Id, dbo.QReleaseOption.qReleaseId, dbo.QReleaseOption.sortOrder, dbo.QOption.hasNoInput, dbo.QText.text, dbo.QText.picture, dbo.QText.textPrint, dbo.QText.textLong, dbo.QText.textPopup, 
                         dbo.QText.textMobile, dbo.QOption.value
FROM            dbo.QReleaseOption INNER JOIN
                         dbo.QOption ON dbo.QReleaseOption.qOptionId = dbo.QOption.Id INNER JOIN
                         dbo.QText ON dbo.QOption.qTextId = dbo.QText.Id
;
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_SQRelease]'))
DROP VIEW [dbo].[View_SQRelease]
;
CREATE VIEW [dbo].[View_SQRelease]
AS
SELECT        dbo.SQRelease.Id, dbo.SRelease.releaseVersion, dbo.SRelease.name, dbo.SQRelease.sReleaseId, dbo.SQRelease.pageNo, dbo.SQRelease.isMandatory, dbo.SQRelease.sortOrder, dbo.View_QRelease.text, 
                         dbo.View_QRelease.picture, dbo.View_QRelease.maxOptCount, dbo.View_QRelease.minSelections, dbo.View_QRelease.rightanswer, dbo.View_QRelease.textLong, dbo.View_QRelease.textPopup, dbo.View_QRelease.textPrint, 
                         dbo.View_QRelease.textMobile, dbo.View_QRelease.qTypeId, dbo.View_QRelease.questionId
FROM            dbo.SQRelease INNER JOIN
                         dbo.SRelease ON dbo.SQRelease.sReleaseId = dbo.SRelease.Id INNER JOIN
                         dbo.View_QRelease ON dbo.SQRelease.qReleaseId = dbo.View_QRelease.Id
;

