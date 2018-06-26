CREATE PROCEDURE dbo.uspTryLogin
	@pLoginName NVARCHAR(254),
	@pPassword NVARCHAR(50)
AS 
BEGIN
SELECT * FROM [dbo].[Accounts] WHERE LoginName = @pLoginName AND PasswordHash=HASHBYTES('SHA2_512', @pPassword)

END