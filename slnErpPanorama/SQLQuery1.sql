

--backup bd
BACKUP DATABASE BD_ERPPanorama TO DISK = 'C:\miguelbd\backup200723.bak' WITH INIT;

-- saber cuantos procedures tengo

SELECT COUNT(*) AS TotalProcedimientosAlmacenados
FROM sys.procedures
WHERE type = 'P';
go
------ saber cuantos procedures tengo y tambien muestra los nombres de los procedimientos

SELECT COUNT(*) AS TotalProcedimientosAlmacenados, NULL AS nombre
FROM sys.procedures
UNION ALL
SELECT NULL AS TotalProcedimientosAlmacenados, name
FROM sys.procedures;



-- como llamar un procedure 
EXEC usp_MovimientoPedido_ListaNumero 2021, '0027306';
go

Exec usp_CuentaBanco_Lista 4;
Exec usp_Equipo_ListaTodosActivo 1;

-- tablas que se usan en PedidoVenta

select * from MovimientoPedido
select fecha from Pedido
select Numero from Pedido

-- saber  información sobre la estructura de una tabla, incluyendo los tipos de datos de las columnas, utilizando el sistema de catálogos de metadatos.

SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'PromocionTemporal'

-- Para obtener solo la definición del procedimiento almacenado o una tablas sin la información adicional:

EXEC sp_helptext 'usp_PromocionValeDescuento_ListaTodosActivo';

-- Para obtener solo lista de  tablas sin la información adicional:
--1
EXEC sp_help 'PromocionTemporal';
--2 Para obtener solo lista de  tablas pero mejorada con columnas personalizadas (alias)
SELECT name AS Columna, system_type_name AS TipoDatos, max_length AS Longitud
FROM sys.dm_exec_describe_first_result_set(N'SELECT * FROM PromocionTemporal', NULL, 0);

--3 Para obetener la definición de la creación de tablas es recomendable revisar y ajustar manualmente la consulta generada según sea necesario.
DECLARE @TableName VARCHAR(100) = 'TablaElemento';
DECLARE @CreateTableSQL NVARCHAR(MAX) = '';

SELECT @CreateTableSQL += 
    'CREATE TABLE ' + @TableName + ' (' + 
    STUFF((
        SELECT ', ' + COLUMN_NAME + ' ' + DATA_TYPE +
            CASE
                WHEN CHARACTER_MAXIMUM_LENGTH IS NOT NULL THEN '(' + CAST(CHARACTER_MAXIMUM_LENGTH AS VARCHAR(10)) + ')'
                ELSE ''
            END +
            CASE
                WHEN IS_NULLABLE = 'NO' THEN ' NOT NULL'
                ELSE ' NULL'
            END
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_NAME = @TableName
        ORDER BY ORDINAL_POSITION
        FOR XML PATH('')
    ), 1, 2, '') +
    ');'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME = @TableName;

PRINT @CreateTableSQL;
---
--ApePaterno, ApeMaterno,  Nombres , TipoPersona, Celular, Email, DescTienda

--IdTienda = 5
---

-- modifica nombre a bd

ALTER DATABASE BD_ERPPanorma
MODIFY NAME = BD_ERPPanorama;

-- ver sesiones en uso con la BD

SELECT session_id, login_name, host_name
FROM sys.dm_exec_sessions
WHERE database_id = DB_ID('BD_ERPPanorama');

-- matar sesión 
kill 55
--

