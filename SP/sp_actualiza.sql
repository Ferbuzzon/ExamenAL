CREATE PROCEDURE [dbo].[sp_actualiza]
	@Id int,
    @Nombre varchar(80),
    @Apaterno varchar(80),
    @AMaterno varchar(80)
AS
BEGIN
    BEGIN TRANSACTION;

    UPDATE EMPLEADOS SET Nombre=@Nombre,ApellidoPaterno=@Apaterno,ApellidoMaterno=@AMaterno WHERE Idusuario=@Id;

    INSERT INTO [MOVIMIENTOS-EMPLEADO] (Idusuario,TipoMovimiento,FechaMovimiento) VALUES (@Id,'CAMBIOS', GETDATE());

    COMMIT TRANSACTION;
END;