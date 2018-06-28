ALTER PROCEDURE dbo.uspAddDonor
	@pID UNIQUEIDENTIFIER,
	@pName NVARCHAR(50),
	@pBloodGroup NVARCHAR(50),
	@pAge NVARCHAR(50),
	@pSex NVARCHAR(50),
	@pStreetAddress NVARCHAR(50),
	@pCity NVARCHAR(50),
	@pState NVARCHAR(50),
	@pDate DATETIME,
	@pPhoneNumber NVARCHAR(50),
	@pEmail NVARCHAR(50),
	@pRh NVARCHAR(50),
	@responseMessage NVARCHAR(250) OUTPUT
AS 
BEGIN 
	
		SET NOCOUNT ON

		BEGIN TRY 
			
			INSERT INTO dbo.[Donors] (Id, Name, BloodGroup, Age, Sex, StreetAddress, City, State, Date, PhoneNumber, Email, Rh)
			VALUES(@pID, @pName, @pBloodGroup, @pAge, @pSex, @pStreetAddress, @pCity, @pState, @pDate, @pPhoneNumber, @pEmail, @pRh)

		END TRY 
		BEGIN CATCH 
			SET @responseMessage=ERROR_MESSAGE()
		END CATCH
END