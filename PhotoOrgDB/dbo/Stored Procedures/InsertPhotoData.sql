CREATE PROCEDURE [dbo].[InsertPhotoData]
	@path nvarchar(250),
	@location nvarchar(50),
	@dateTaken datetime,
	@people nvarchar(250),
	@imageName nvarchar(50)
AS
BEGIN
	if not exists(select * from Photos where path = @path)
		insert into Photos (
		path,
		location,
		dateTaken,
		people,
		imageName
		)
		values
		(@path,
		@location,
		@dateTaken,
		@people,
		@imageName);
END
		
