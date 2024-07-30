CREATE PROCEDURE sp_FiltrarMovimientos
    @FechaMovimiento DATE,
    @TipoMovimiento VARCHAR(50)
AS
BEGIN
    SELECT Idusuario, TipoMovimiento, FechaMovimiento
    FROM [MOVIMIENTOS-EMPLEADO]
    WHERE CAST(FechaMovimiento AS DATE) = @FechaMovimiento 
      AND TipoMovimiento = @TipoMovimiento;
END