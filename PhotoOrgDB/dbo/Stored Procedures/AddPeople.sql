CREATE PROCEDURE [dbo].[AddPeople]
	@path nvarchar(250),
	@people nvarchar(50)
AS
BEGIN
	update Photos
	set people = nullif(@people, '')
	where path = @path
END
