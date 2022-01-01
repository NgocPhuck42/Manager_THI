create proc USP_Login 
@username nvarchar(50), @password nvarchar(50)
as
begin
	select * from Account
	where username = @username and password = @password
end
go

create proc USP_UpdateAccount
@username nvarchar(50), @displayname nvarchar(50), @password nvarchar(50), @newpassword nvarchar(50)
as
begin
	declare @isRightPass int = 0

	select @isRightPass = COUNT(*) from Account where username = @username and password = @password

	if(@isRightPass = 1)
	begin
		if(@newpassword = null or @newpassword ='')
		begin
			update Account set displayname = @displayname where username = @username
		end
		else
			update Account set displayname = @displayname , password = @newpassword where username = @username
	end
end
go

CREATE FUNCTION [dbo].[ufn_removeMark] (@text nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
	SET @text = LOWER(@text)
	DECLARE @textLen int = LEN(@text)
	IF @textLen > 0
	BEGIN
		DECLARE @index int = 1
		DECLARE @lPos int
		DECLARE @SIGN_CHARS nvarchar(100) = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýđð'
		DECLARE @UNSIGN_CHARS varchar(100) = 'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyydd'

		WHILE @index <= @textLen
		BEGIN
			SET @lPos = CHARINDEX(SUBSTRING(@text,@index,1),@SIGN_CHARS)
			IF @lPos > 0
			BEGIN
				SET @text = STUFF(@text,@index,1,SUBSTRING(@UNSIGN_CHARS,@lPos,1))
			END
			SET @index = @index + 1
		END
	END
	RETURN @text
END
select * from Product
select * from category
select * from Account
DBCC CHECKIDENT (Category, RESEED, 0);
GO

insert Category values(N'Sơn Ngu')
insert Category values(N'Dũng xì ke')


exec USP_Login dung , 123

update Category set name = N'Sơn ngu ngục' where id = 2

select * from Category where dbo.ufn_removeMark(name) LIKE N'%' + dbo.ufn_removeMark(N'Phúc') + '%' 

select * from Category where id = 