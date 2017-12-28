IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_Sheelon]'))
DROP VIEW [dbo].[View_Sheelon]
;
CREATE VIEW [dbo].[View_Sheelon]
AS
SELECT        Id, IsActive, name, shared, F1, F2, F3
FROM            dbo.Sheelon
;
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_SheelonRelease]'))
DROP VIEW [dbo].[View_SheelonRelease]
;
CREATE VIEW [dbo].[View_SheelonRelease]
AS
SELECT        Id, IsActive, name, toDate, fromDate, sheelon
FROM            dbo.SheelonRelease
;
