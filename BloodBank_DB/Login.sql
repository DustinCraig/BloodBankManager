CREATE PROCEDURE dbo.uspTryLogin
	@pLoginName NVARCHAR(254),
	@pPassword NVARCHAR(50),
	@responseMessage NVARCHAR(250)='' OUTPUT
AS 
BEGIN
SELECT * FROM [dbo].[Accounts] WHERE LoginName = @pLoginName AND PasswordHash=HASHBYTES('SHA2_512', @pPassword)

END