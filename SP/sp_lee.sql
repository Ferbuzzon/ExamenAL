CREATE PROCEDURE [dbo].[sp_lee]
	@Id int
AS BEGIN

    SELECT * FROM EMPLEADOS WHERE Idusuario=@Id;

END;