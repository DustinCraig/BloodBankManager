CREATE PROCEDURE dbo.uspAddUser
	@pLogin NVARCHAR(50),
	@pPassword NVARCHAR(50),
	@pFirstName NVARCHAR(50) = NULL,
	@pLastName NVARCHAR(50)  = NULL,
	@responseMessage NVARCHAR(250) OUTPUT

AS
BEGIN
	SET NOCOUNT ON 
	
	BEGIN TRY 
		
		INSERT INTO dbo.[Accounts] (LoginName, PasswordHash, FirstName, LastName)
		VALUES(@pLogin, HASHBYTES('SHA2_512', @pPassword), @pFirstName, @pLastName)

		SET @responseMessage='Success'

		END TRY
		BEGIN CATCH
			SET @responseMessage=ERROR_MESSAGE()
		END CATCH
END