CREATE PROCEDURE sp_DepuracionUsuarios
AS
BEGIN
    DELETE FROM EMPLEADOS
    WHERE Idsuario IN (
        SELECT Idusuario
        FROM MOVIMIENTOS-EMPLEADOS
        WHERE DechaMovimiento < DATEADD(MONTH, -3, GETDATE())
        GROUP BY Idusuario
        HAVING MAX(FechaMovimiento) < DATEADD(MONTH, -3, GETDATE())
    );
END