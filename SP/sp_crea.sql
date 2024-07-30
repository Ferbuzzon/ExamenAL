CREATE PROCEDURE [dbo].[sp_crea]
    @Nombre varchar(80),
    @Apaterno varchar(80),
    @AMaterno varchar(80)
AS
BEGIN
    BEGIN TRANSACTION;
    
    DECLARE @NuevoID int;

    INSERT INTO EMPLEADOS (Nombre,ApellidoPaterno,ApellidoMaterno) VALUES (@Nombre, @Apaterno, @AMaterno);

    SET @NuevoID = SCOPE_IDENTITY();

    INSERT INTO [MOVIMIENTOS-EMPLEADO] (Idusuario,TipoMovimiento,FechaMovimiento) VALUES (@NuevoID,'ALTA', GETDATE());

    COMMIT TRANSACTION;
END;