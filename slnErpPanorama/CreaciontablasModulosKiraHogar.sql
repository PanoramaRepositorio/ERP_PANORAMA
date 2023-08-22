--listar en orden Menu

select * from Menu
ORDER BY MenuCodigo ASC;

select * from MenuTipo
where IdMenuTipo = 6

--DELETE - FROM Menu
--WHERE - IdMenu = 2467;

--select * from - AccesoUsuario
--where - IdMenu = 2467

select * from AccesoUsuario
where IdMenu = 2467

--TAB
select * from Menu
where IdMenuTipo = 1
ORDER BY MenuCodigo ASC;
-- BUTTON
select * from Menu
where IdMenuTipo = 2 OR IdMenuTipo = 4 OR IdMenuTipo = 1
ORDER BY MenuCodigo ASC;

--GRUPOS
select * from Menu
where IdMenuTipo = 4
ORDER BY MenuCodigo ASC;

--  CONSULTAS VARIADOS

/*

SELECT *
FROM Menu
WHERE IdMenuTipo = 4
  AND IdMenuPadre = '2459'
  AND MenuDescripcion IN ('Registros', 'consultas');

  Select * from MenuTipo

  select * from Menu
  where Clase = 'frmConfacturaCompra'

--actualizar Menus principal (TAB)
--UPDATE Menu
--SET IdMenuPadre = 2459
--WHERE IdMenu = 2461;
--select * from Tabla
--select * from TablaElemento
--where DescTabla like 'tipo%'

*/


/*

Select * from MenuTipo

-- insertar Menus principal (TAB)

INSERT INTO Menu ( MenuCodigo, IdMenuPadre, MenuDescripcion, Imagen, LargeImage, Clase, Ensamblado, IdMenuTipo, ModoCargaVentana, FlagEstado)
VALUES ('0013', 1, 'Kira', '', 0, '', '', 1, 0, 1);

-- insertar menu  (GRUPOS) Registros - Consultas

INSERT INTO Menu ( MenuCodigo, IdMenuPadre, MenuDescripcion, Imagen, LargeImage, Clase, Ensamblado, IdMenuTipo, ModoCargaVentana, FlagEstado)
VALUES ('001301', 2456, 'Consultas', '', 0, '', '', 4, 0, 1);
INSERT INTO Menu ( MenuCodigo, IdMenuPadre, MenuDescripcion, Imagen, LargeImage, Clase, Ensamblado, IdMenuTipo, ModoCargaVentana, FlagEstado)
VALUES ('001302', 2456, 'Precio Producto Cliente Stock', '', 0, '', '', 4, 0, 1);
INSERT INTO Menu ( MenuCodigo, IdMenuPadre, MenuDescripcion, Imagen, LargeImage, Clase, Ensamblado, IdMenuTipo, ModoCargaVentana, FlagEstado)
VALUES ('001303', 2456, 'Precio Producto Terminado', '', 0, '', '', 4, 0, 1);

-- insertar menu  (BUTTON) Cotizar

INSERT INTO Menu ( MenuCodigo, IdMenuPadre, MenuDescripcion, Imagen, LargeImage, Clase, Ensamblado, IdMenuTipo, ModoCargaVentana, FlagEstado)
VALUES ('00130101', 2457, 'Cotización', 'Consultas_32x32', 1, 'frmRegKiraCotizacion', 'ErpPanorama.Presentation.Modulos.KiraHogar.Registros.frmRegKiraCotizacion', 2, 1, 1);
INSERT INTO Menu ( MenuCodigo, IdMenuPadre, MenuDescripcion, Imagen, LargeImage, Clase, Ensamblado, IdMenuTipo, ModoCargaVentana, FlagEstado)
VALUES ('00130201', 2458, 'Precio Producto Cliente Stock', 'PedidoVenta_32x32', 1, 'frmCotizacion', 'ErpPanorama.Presentation.Modulos.KiraHogar.Consultas.frmCotizacion', 2, 1, 1);
INSERT INTO Menu ( MenuCodigo, IdMenuPadre, MenuDescripcion, Imagen, LargeImage, Clase, Ensamblado, IdMenuTipo, ModoCargaVentana, FlagEstado)
VALUES ('00130202', 2458 , 'Precio Producto Terminado', 'PedidoVenta_32x32', 1, 'frmRegKiraCotizacionProductoTerminado', 'ErpPanorama.Presentation.Modulos.KiraHogar.', 2, 1, 1);
---



-- Insertar datos de nuevas DescTabla a TABLA para los combosBOX

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'TIPO COTIZACIÓN', 1);

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'MATERIALES', 1);

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'INSUMOS', 1);

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'ACCESORIOS', 1);

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'MANO DE OBRA', 1);

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'MOVILIDAD Y VIATICOS', 1);

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'EQUIPOS Y HERRAMIENTAS', 1);

INSERT INTO Tabla (IdEmpresa, DescTabla, FlagEstado)
VALUES (13, 'PRODUCTO TERMINADO', 1);


-- Insertar datos a TABLA ELEMENTO (TIPO COTIZACIÓN)

INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (105, 'CPC', 'COTIZACIÓN PARA EL CLIENTE', NULL, NULL, 1);

INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (105, 'CF', 'COTIZACION DE FABRICACION PARA STOCK', NULL, NULL, 1);

-- Insertar datos a TABLA ELEMENTO (TIPO MATERIAL)
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'AC', 'ACERO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'BRC', 'BRONCE', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'CSC', 'CASCO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'ESPM', 'ESPUMA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'ESP', 'ESPEJO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'FRR', 'FIERRO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'MDR', 'MADERA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'MDF', 'MDF', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'MLMN', 'MELAMINE', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'NP', 'NAPA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'NTX', 'NOTEX', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'PDA', 'PIEDRA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'TL', 'TELA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (106, 'VDR', 'VIDRIO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)


VALUES (106, 'ENCD', 'ENCHAPE DE MADERA', NULL, NULL, 1);

-- Insertar datos a TABLA ELEMENTO (TIPO INSUMOS)

INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (107, 'CRPRS', 'CARTON PRENSADO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (107, 'CRD', 'CRUDO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (107, 'NSG', 'NOSAG', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (107, 'PTRA', 'PINTURA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (107, 'PLSD', 'POLISEDA', NULL, NULL, 1);

-- Insertar datos a TABLA ELEMENTO (TIPO ACCESORIOS)

INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (108, 'BGS', 'BISAGRAS', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (108, 'CRS', 'CORREDERAS', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (108, 'TRDS', 'TIRADORES', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (108, 'ILMN', 'ILUMINACIÓN', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (108, 'PTZL', 'PATAS CON ZOCALO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (108, 'PTMD', 'PATAS DE MADERA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (108, 'PTML', 'PATAS METALICAS', NULL, NULL, 1);

-- Insertar datos a TABLA ELEMENTO (TIPO MANO DE OBRA)

INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'CPT', 'CARPINTERIA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'CTRO', 'COSTURERO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'ETCA', 'ELECTRICISTA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'ESBR', 'ENSAMBLADOR', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'PTR', 'PINTURA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'SDR', 'SOLDADOR', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'TPO', 'TAPICERO', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (109, 'VDO', 'VIDRIERO', NULL, NULL, 1);

-- Insertar datos a TABLA ELEMENTO (TIPO MOVILIDAD Y VIATICOS)

INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (110, 'CPT', 'PASAJE DISEÑADORA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (110, 'CPT', 'PASAJE PARA LA ENTREGA', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (110, 'CPT', 'PASAJE PRODUCCION', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (110, 'CPT', 'VIATICOS', NULL, NULL, 1);

-- Insertar datos a TABLA ELEMENTO (EQUIPOS Y HERRAMIENTAS)

INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (111, '', 'EQUIPOS Y HERRAMIENTAS', NULL, NULL, 1);

-- Insertar datos a TABLA ELEMENTO (PRODUCTO TERMINADO)
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (112, 'CIGV', 'COSTO INC. IGV', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (112, 'MVD', 'MOVILIDAD', NULL, NULL, 1);
INSERT INTO TablaElemento (IdTabla, Abreviatura, DescTablaElemento, IdTablaExterna, Valor, FlagEstado)
VALUES (112, 'SVAD', 'SERVICIOS ADICIONALES', NULL, NULL, 1);

*/

----PRECIO_PRODUCTO CLIENTE-STOCK

CREATE TABLE CotizacionKIRA (
    IdCotizacion INT IDENTITY(1,1) PRIMARY KEY,
    IdTablaElemento INT NOT NULL,
    Fecha DATE NOT NULL,
    CodigoProducto VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    Caracteristicas VARCHAR(500) NOT NULL,
    Imagen NVARCHAR(100),
    CostoMateriales DECIMAL(18, 2) NULL,
    CostoInsumos DECIMAL(18, 2) NULL,
    CostoAccesorios DECIMAL(18, 2) NULL,
    CostoManoObra DECIMAL(18, 2) NULL,
    CostoMovilidad DECIMAL(18, 2) NULL,
    CostoEquipos DECIMAL(18, 2) NULL,
    TotalGastos DECIMAL(18, 2) NOT NULL,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    Moneda INT NOT NULL, -- Nuevo campo para la moneda
    FlagEstado BIT NOT NULL, -- Nueva columna agregada
    FOREIGN KEY (IdTablaElemento) REFERENCES TablaElemento (IdTablaElemento),
    FOREIGN KEY (Moneda) REFERENCES TablaElemento (IdTablaElemento) -- Relación con la tabla TablaElemento para la columna Moneda
);

CREATE TABLE DetalleCotizacion (

    IdCotizacionDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdCotizacion INT NOT NULL,
    IdTablaElemento INT  NULL,
    Item INT NULL,
    DescripcionGastos VARCHAR(255) NULL,
    FlagAprobacion BIT NULL,
    FlagEstado BIT NULL, -- Nueva columna agregada
    Costo DECIMAL(18, 2) NULL, -- Nueva columna agregada
    FOREIGN KEY (IdCotizacion) REFERENCES CotizacionKIRA (IdCotizacion),
    FOREIGN KEY (IdTablaElemento) REFERENCES TablaElemento (IdTablaElemento)
);

CREATE TYPE dbo.DetalleCotizacionType AS TABLE
(
    IdTablaElemento INT NOT NULL,
    Item INT NOT NULL,
    DescripcionGastos VARCHAR(255) NOT NULL,
    FlagAprobacion BIT NOT NULL,
    FlagEstado BIT NOT NULL,
    Costo DECIMAL(18, 2) NOT NULL -- Nuevo campo "Costo" agregado
);

--Procedimiento almacenado para RegistrarCotizacionDetalle
CREATE PROCEDURE usp_RegistrarCotizacionYDetalle
(
    @IdTablaElemento INT,
    @Fecha DATE,
    @CodigoProducto VARCHAR(50),
    @Descripcion VARCHAR(255),
    @Caracteristicas VARCHAR(500),
    @Imagen NVARCHAR(100),
    @CostoMateriales DECIMAL(18, 2),
    @CostoInsumos DECIMAL(18, 2),
    @CostoAccesorios DECIMAL(18, 2),
    @CostoManoObra DECIMAL(18, 2),
    @CostoMovilidad DECIMAL(18, 2),
    @CostoEquipos DECIMAL(18, 2),
    @TotalGastos DECIMAL(18, 2),
    @PrecioVenta DECIMAL(18, 2),
    @Moneda INT, -- Nuevo parámetro para la moneda
    @DetalleCotizacion dbo.DetalleCotizacionType READONLY,
    @IdCotizacion INT OUTPUT,
    @FlagEstado BIT -- Nuevo parámetro para el FlagEstado de la Cotización
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar la cotización en la tabla "CotizacionKIRA"
    INSERT INTO CotizacionKIRA (IdTablaElemento, Fecha, CodigoProducto, Descripcion, Caracteristicas, Imagen, CostoMateriales, CostoInsumos, CostoAccesorios, CostoManoObra, CostoMovilidad, CostoEquipos, TotalGastos, PrecioVenta, Moneda, FlagEstado)
    VALUES (@IdTablaElemento, @Fecha, @CodigoProducto, @Descripcion, @Caracteristicas, @Imagen, @CostoMateriales, @CostoInsumos, @CostoAccesorios, @CostoManoObra, @CostoMovilidad, @CostoEquipos, @TotalGastos, @PrecioVenta, @Moneda, @FlagEstado)

    -- Obtener el ID de la cotización recién insertada
    SET @IdCotizacion = SCOPE_IDENTITY()

    -- Insertar los detalles de cotización desde la tabla estructurada a la tabla "DetalleCotizacion"
    INSERT INTO DetalleCotizacion (IdCotizacion, IdTablaElemento, Item, DescripcionGastos, FlagAprobacion, FlagEstado, Costo)
    SELECT @IdCotizacion, IdTablaElemento, Item, DescripcionGastos, FlagAprobacion, FlagEstado, Costo
    FROM @DetalleCotizacion
END

---------------- PRUEBA DE REGISTRO 

-- Declarar una variable para almacenar el IdCotizacion de salida
DECLARE @IdCotizacionResult INT;

-- Declarar una tabla para almacenar los detalles de cotización
DECLARE @DetalleCotizacionData AS dbo.DetalleCotizacionType;

-- Insertar datos en la tabla de detalles de cotización (puedes ajustar estos valores según tus necesidades)
INSERT INTO @DetalleCotizacionData (IdTablaElemento, Item, DescripcionGastos, FlagAprobacion, FlagEstado, Costo)
VALUES
    (718, 1, 'ESPEJO', 1, 1, 100.00),
    (722, 1, 'MELAMINE', 1, 1, 150.00),
    (727, 2, 'VIDRIO', 1, 1, 200.00);

-- Ejecutar el procedimiento almacenado
EXEC usp_RegistrarCotizacionYDetalle
    @IdTablaElemento = 712,
    @Fecha = '2023-07-18',
    @CodigoProducto = 'PROD002',
    @Descripcion = 'MUEBLE BAR FLOTANTE (desde SQL)',
    @Caracteristicas = 'MUEBLE BAR FLOTANTE / ESTRUCTURA: MELAMINA PELIKANO ROVERE CON FONDO DE ESPEJO / PUERTAS: VIDRIO AHUMADO / ILUMINACIÓN: LED DICROICO LUZ CÁLIDA / MEDIDAS: 2.16m largo x 0.36m profundidad x 0.91m alto',
    @Imagen = 'imagen_producto.jpg',
    @CostoMateriales = 800.00,
    @CostoInsumos = 20.00,
    @CostoAccesorios = 200.00,
    @CostoManoObra = 407.50,
    @CostoMovilidad = 274.00,
    @CostoEquipos = 50.00,
    @TotalGastos = 1751.50,
    @PrecioVenta = 2919.17,
    @Moneda = 5, -- Asignar el valor correspondiente para la moneda (5 para SOLES)
    @DetalleCotizacion = @DetalleCotizacionData, -- Datos de los detalles de cotización
    @IdCotizacion = @IdCotizacionResult OUTPUT, -- Variable de salida para el IdCotizacion
    @FlagEstado = 1; -- Valor para el nuevo parámetro FlagEstado (1 para activo)

-- Verificar el resultado mostrando el IdCotizacion generado
SELECT @IdCotizacionResult AS 'IdCotizacion';
------
GO


-----------PROCEDIMIENTOS ALMACENADOS

CREATE PROCEDURE usp_ListarCotizaciones
AS

BEGIN
    SET NOCOUNT ON;
    SELECT
	    CK.IdCotizacion ,
        CK.CodigoProducto,
        CK.Descripcion,
        CK.CostoMateriales,
        CK.CostoInsumos,
        CK.CostoAccesorios,
        CK.CostoManoObra,
        CK.CostoMovilidad,
        CK.CostoEquipos,
        CK.TotalGastos,
        CK.PrecioVenta,
        CK.Fecha,
        TE.DescTablaElemento -- Agregamos la columna DescTablaElemento
    FROM CotizacionKIRA CK
    INNER JOIN TablaElemento TE ON CK.IdTablaElemento = TE.IdTablaElemento -- Realizamos un INNER JOIN con la tabla TablaElemento
    WHERE CK.FlagEstado = 1; -- Filtrar solo los registros con FlagEstado igual a 1
	END


CREATE PROCEDURE usp_EliminarCotizacion
    @CodigoProducto VARCHAR(50)
AS
BEGIN
    UPDATE CotizacionKIRA
    SET FlagEstado = 0
    WHERE CodigoProducto = @CodigoProducto;
END
GO

CREATE PROCEDURE usp_EliminarCotizacionProducto
    @CodigoProducto VARCHAR(50)
AS
BEGIN
    UPDATE CotizacionKIRATerminado
    SET FlagEstado = 0
    WHERE CodigoProducto = @CodigoProducto;
END
GO


--CREATE PROCEDURE usp_ActualizarCotizacionpreview
--    @IdCotizacion INT,
--    @NuevoCodigoProducto VARCHAR(50),
--    @NuevaDescripcion VARCHAR(255)
--AS
--BEGIN
--    SET NOCOUNT ON;

--    -- Verificar si el nuevo CodigoProducto ya existe en la base de datos
--    IF EXISTS (SELECT 1 FROM CotizacionKIRA WHERE CodigoProducto = @NuevoCodigoProducto AND IdCotizacion <> @IdCotizacion)
--    BEGIN
--        THROW 50001, 'El nuevo CodigoProducto ya existe en la base de datos.', 1;
--        RETURN;
--    END
    
--    -- Actualizamos el CodigoProducto y la Descripción utilizando el procedimiento almacenado
--    UPDATE CotizacionKIRA
--    SET CodigoProducto = @NuevoCodigoProducto, Descripcion = @NuevaDescripcion
--    WHERE IdCotizacion = @IdCotizacion;

--    RETURN;
--END


--EXEC usp_ListarCotizaciones;

--EXEC sp_helptext 'usp_ValidarCodigoProducto';

create PROCEDURE usp_ValidarCodigoProducto
(
    @CodigoProducto VARCHAR(50),
    @ExisteCodigo BIT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM CotizacionKIRA WHERE CodigoProducto = @CodigoProducto)
    BEGIN
        PRINT 'El Código de Producto ' + @CodigoProducto + ' ya existe en la base de datos.';
        SET @ExisteCodigo = 1;
    END
    ELSE
    BEGIN
        PRINT 'El Código de Producto ' + @CodigoProducto + ' no existe en la base de datos.';
        SET @ExisteCodigo = 0;
    END
END
GO

create PROCEDURE usp_ValidarCodigoProductoproducto
(
    @CodigoProducto VARCHAR(50),
    @ExisteCodigo BIT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM CotizacionKIRATerminado WHERE CodigoProducto = @CodigoProducto)
    BEGIN
        PRINT 'El Código de Producto ' + @CodigoProducto + ' ya existe en la base de datos.';
        SET @ExisteCodigo = 1;
    END
    ELSE
    BEGIN
        PRINT 'El Código de Producto ' + @CodigoProducto + ' no existe en la base de datos.';
        SET @ExisteCodigo = 0;
    END
END
GO



----CREATE PROCEDURE usp_ValidarCodigoProducto
----(
----    @CodigoProducto VARCHAR(50),
----    @ExisteCodigo BIT OUTPUT
----)
----AS
----BEGIN
----    SET NOCOUNT ON;

----    IF EXISTS (SELECT 1 FROM CotizacionKIRA WHERE CodigoProducto = @CodigoProducto)
----        SET @ExisteCodigo = 1;
----    ELSE
----        SET @ExisteCodigo = 0;
----END
----

----Código de producto existente:

--DECLARE @CodigoProductoExistente VARCHAR(50) = 'COT-001';
--DECLARE @ExisteCodigoExistente BIT;

--EXEC usp_ValidarCodigoProducto
--    @CodigoProducto = @CodigoProductoExistente,
--    @ExisteCodigo = @ExisteCodigoExistente OUTPUT;

--SELECT @ExisteCodigoExistente AS 'ExisteCodigoExistente';

---- Código de producto no existente:

--DECLARE @CodigoProductoNoExistente VARCHAR(50) = 'PROD999';
--DECLARE @ExisteCodigoNoExistente BIT;

--EXEC usp_ValidarCodigoProducto
--    @CodigoProducto = @CodigoProductoNoExistente,
--    @ExisteCodigo = @ExisteCodigoNoExistente OUTPUT;

--SELECT @ExisteCodigoNoExistente AS 'ExisteCodigoNoExistente';


--Select * from CotizacionKIRA
--Select * from DetalleCotizacion
--DBCC CHECKIDENT ('DetalleCotizacion', RESEED, 0);

--select * from TablaElemento
--where IdTabla = 111

----DELETE FROM CotizacionKIRA;
----DELETE FROM DetalleCotizacion;

----LLAMANDO PROCEDIMIENTOS

--exec usp_Combo_ListaTipoCotizacion;
--exec usp_Combo_ListaMateriales;
--exec usp_Combo_ListaInsumos;
--exec usp_Combo_ListaAccesorios;
--exec usp_Combo_ListaManoObra;
--exec usp_Combo_ListaMovilidadyViaticos;
--exec usp_Combo_ListaTipoMoneda;
--exec usp_Combo_ListaEquiposHerramientas;
--go

----CREATE PROCEDURE usp_ActualizarCotizacion
----    @IdCotizacion INT,
----    @NuevoCodigoProducto VARCHAR(50),
----    @NuevaDescripcion VARCHAR(255),
----    @NuevoCaracteristicas VARCHAR(500),
----    @NuevoImagen NVARCHAR(100),
----    @NuevoCostoMateriales DECIMAL(18, 2),
----    @NuevoCostoInsumos DECIMAL(18, 2),
----    @NuevoCostoAccesorios DECIMAL(18, 2),
----    @NuevoCostoManoObra DECIMAL(18, 2),
----    @NuevoCostoMovilidad DECIMAL(18, 2),
----    @NuevoCostoEquipos DECIMAL(18, 2),
----    @NuevoTotalGastos DECIMAL(18, 2),
----    @NuevoPrecioVenta DECIMAL(18, 2),
----    @NuevoMoneda INT,
----    @NuevoFlagEstado BIT,
----    @NuevaDescripcionGastos VARCHAR(255),
----    @NuevoFlagAprobacion BIT,
----    @NuevoFlagEstadoDetalle BIT,
----    @NuevoCosto DECIMAL(18, 2)
----AS
----BEGIN
----    SET NOCOUNT ON;

----    -- Verificar si el nuevo CodigoProducto ya existe en la base de datos
----    IF EXISTS (SELECT 1 FROM CotizacionKIRA WHERE CodigoProducto = @NuevoCodigoProducto AND IdCotizacion <> @IdCotizacion)
----    BEGIN
----        THROW 50001, 'El nuevo CodigoProducto ya existe en la base de datos.', 1;
----        RETURN;
----    END

----    -- Actualizar los datos en la tabla CotizacionKIRA
----    UPDATE CotizacionKIRA
----    SET CodigoProducto = @NuevoCodigoProducto,
----        Descripcion = @NuevaDescripcion,
----        Caracteristicas = @NuevoCaracteristicas,
----        Imagen = @NuevoImagen,
----        CostoMateriales = @NuevoCostoMateriales,
----        CostoInsumos = @NuevoCostoInsumos,
----        CostoAccesorios = @NuevoCostoAccesorios,
----        CostoManoObra = @NuevoCostoManoObra,
----        CostoMovilidad = @NuevoCostoMovilidad,
----        CostoEquipos = @NuevoCostoEquipos,
----        TotalGastos = @NuevoTotalGastos,
----        PrecioVenta = @NuevoPrecioVenta,
----        Moneda = @NuevoMoneda,
----        FlagEstado = @NuevoFlagEstado
----    WHERE IdCotizacion = @IdCotizacion;

----    -- Actualizar detalles de la cotización si es necesario
----    UPDATE DetalleCotizacion
----    SET DescripcionGastos = @NuevaDescripcionGastos,
----        FlagAprobacion = @NuevoFlagAprobacion,
----        FlagEstado = @NuevoFlagEstadoDetalle,
----        Costo = @NuevoCosto
----    WHERE IdCotizacion = @IdCotizacion;

----    RETURN;
----END

-------
----DECLARE @Resultado NVARCHAR(200);

----BEGIN TRY
----    EXEC usp_ActualizarCotizacion
----        @IdCotizacion = 4,  -- Cambia esto al ID de la cotización que deseas actualizar
----        @NuevoCodigoProducto = 'SPORTINGX ',
----        @NuevaDescripcion = 'Nueva descripción',
----        @NuevoCaracteristicas = 'Nuevas características',
----        @NuevoImagen = 'Nueva imagen',
----        @NuevoCostoMateriales = 100.00,
----        @NuevoCostoInsumos = 50.00,
----        @NuevoCostoAccesorios = 20.00,
----        @NuevoCostoManoObra = 80.00,
----        @NuevoCostoMovilidad = 10.00,
----        @NuevoCostoEquipos = 30.00,
----        @NuevoTotalGastos = 290.00,
----        @NuevoPrecioVenta = 500.00,
----        @NuevoMoneda = 5,  -- Cambia esto al valor correcto de la moneda
----        @NuevoFlagEstado = 1,  -- Cambia esto al valor correcto del estado
----        @NuevaDescripcionGastos = 'Nueva descripción de gastos',
----        @NuevoFlagAprobacion = 1,  -- Cambia esto al valor correcto de aprobación
----        @NuevoFlagEstadoDetalle = 1,  -- Cambia esto al valor correcto del estado detalle
----        @NuevoCosto = 150.00;

----    SET @Resultado = 'Éxito';
----END TRY
----BEGIN CATCH
----    SET @Resultado = ERROR_MESSAGE();
----END CATCH;

----SELECT @Resultado AS Resultado;
------

CREATE PROCEDURE usp_ActualizarCotizacion
    @IdCotizacion INT,
    @NuevoCodigoProducto VARCHAR(50),
    @NuevaDescripcion VARCHAR(255),
    @NuevoCaracteristicas VARCHAR(500),
    @NuevoImagen NVARCHAR(100),
    @NuevoCostoMateriales DECIMAL(18, 2),
    @NuevoCostoInsumos DECIMAL(18, 2),
    @NuevoCostoAccesorios DECIMAL(18, 2),
    @NuevoCostoManoObra DECIMAL(18, 2),
    @NuevoCostoMovilidad DECIMAL(18, 2),
    @NuevoCostoEquipos DECIMAL(18, 2)
    --@NuevoMoneda INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nuevo CodigoProducto ya existe en la base de datos
    IF EXISTS (SELECT 1 FROM CotizacionKIRA WHERE CodigoProducto = @NuevoCodigoProducto AND IdCotizacion <> @IdCotizacion)
    BEGIN
        THROW 50001, 'El nuevo CodigoProducto ya existe en la base de datos.', 1;
        RETURN;
    END

    -- Calcular el nuevo TotalGastos
    DECLARE @NuevoTotalGastos DECIMAL(18, 2);
    SET @NuevoTotalGastos = @NuevoCostoMateriales + @NuevoCostoInsumos + @NuevoCostoAccesorios + @NuevoCostoManoObra + @NuevoCostoMovilidad + @NuevoCostoEquipos;

    -- Calcular el nuevo PrecioVenta
    DECLARE @NuevoPrecioVenta DECIMAL(18, 2);
    SET @NuevoPrecioVenta = @NuevoTotalGastos / (1 - 0.4);

    -- Actualizar los datos en la tabla CotizacionKIRA
    UPDATE CotizacionKIRA
    SET CodigoProducto = @NuevoCodigoProducto,
        Descripcion = @NuevaDescripcion,
        Caracteristicas = @NuevoCaracteristicas,
        Imagen = @NuevoImagen,
        CostoMateriales = @NuevoCostoMateriales,
        CostoInsumos = @NuevoCostoInsumos,
        CostoAccesorios = @NuevoCostoAccesorios,
        CostoManoObra = @NuevoCostoManoObra,
        CostoMovilidad = @NuevoCostoMovilidad,
        CostoEquipos = @NuevoCostoEquipos,
        TotalGastos = @NuevoTotalGastos,
        PrecioVenta = @NuevoPrecioVenta
        --Moneda = @NuevoMoneda
    WHERE IdCotizacion = @IdCotizacion;

    RETURN;
END
--- VALIDAR ACTUALIZACION usp_ActualizarCotizacion

DECLARE @Resultado NVARCHAR(200);

BEGIN TRY
    EXEC usp_ActualizarCotizacion
        @IdCotizacion = 1,  -- Cambia esto al ID de la cotización que deseas actualizar
        @NuevoCodigoProducto = 'CODSC',
        @NuevaDescripcion = 'liga 1',
        @NuevoCaracteristicas = 'liga',
        @NuevoImagen = 'Nueva imagen',
        @NuevoCostoMateriales = 100.00,
        @NuevoCostoInsumos = 50.00,
        @NuevoCostoAccesorios = 70.00,
        @NuevoCostoManoObra = 80.00,
        @NuevoCostoMovilidad = 10.00,
        @NuevoCostoEquipos = 50.00
        --@NuevoTotalGastos = 290.00,
        --@NuevoPrecioVenta = 500.00,

    SET @Resultado = 'Éxito';
END TRY
BEGIN CATCH
    SET @Resultado = ERROR_MESSAGE();
END CATCH;

SELECT @Resultado AS Resultado;

GO

select * from CotizacionKIRATerminado

CREATE PROCEDURE usp_ActualizarCotizacionProductos
    @IdCotizacion INT,
    @NuevoCodigoProducto VARCHAR(50),
    @NuevaDescripcion VARCHAR(255),
    @NuevoCaracteristicas VARCHAR(500),
    @NuevoImagen NVARCHAR(100),
    @NuevoCostoProductos DECIMAL(18, 2)
    --@NuevoMoneda INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nuevo CodigoProducto ya existe en la base de datos
    IF EXISTS (SELECT 1 FROM CotizacionKIRATerminado WHERE CodigoProducto = @NuevoCodigoProducto AND IdCotizacion <> @IdCotizacion)
    BEGIN
        THROW 50001, 'El nuevo CodigoProducto ya existe en la base de datos.', 1;
        RETURN;
    END

    -- Calcular el nuevo TotalGastos
    DECLARE @NuevoTotalGastos DECIMAL(18, 2);
    SET @NuevoTotalGastos = @NuevoCostoProductos;

    -- Calcular el nuevo PrecioVenta
    DECLARE @NuevoPrecioVenta DECIMAL(18, 2);
    SET @NuevoPrecioVenta = @NuevoTotalGastos / (1 - 0.4);

    -- Actualizar los datos en la tabla CotizacionKIRA
    UPDATE CotizacionKIRATerminado
    SET CodigoProducto = @NuevoCodigoProducto,
        Descripcion = @NuevaDescripcion,
        Caracteristicas = @NuevoCaracteristicas,
        Imagen = @NuevoImagen,
        CostoProductos = @NuevoCostoProductos,
        TotalGastos = @NuevoTotalGastos,
        PrecioVenta = @NuevoPrecioVenta
        --Moneda = @NuevoMoneda
    WHERE IdCotizacion = @IdCotizacion;

    RETURN;
END
---- VALIDAR ACTUALIZACION PRODUCTOS
DECLARE @Resultado NVARCHAR(200);

BEGIN TRY
    EXEC usp_ActualizarCotizacionProductos
        @IdCotizacion = 1,  -- Cambia esto al ID de la cotización que deseas actualizar
        @NuevoCodigoProducto = 'CODSCs',
        @NuevaDescripcion = 'liga 1',
        @NuevoCaracteristicas = 'liga',
        @NuevoImagen = 'Nueva imagen',
        @NuevoCostoProductos = 100.00
        --@NuevoTotalGastos = 290.00,
        --@NuevoPrecioVenta = 500.00,

    SET @Resultado = 'Éxito';
END TRY
BEGIN CATCH
    SET @Resultado = ERROR_MESSAGE();
END CATCH;

SELECT @Resultado AS Resultado;
GO
select * from CotizacionKIRATerminado

CREATE PROCEDURE usp_ObtenerDetallesCotizacionPorId
    @IdCotizacion INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Aquí escribe la lógica para obtener los detalles de la cotización por su IdCotizacion
    -- Puedes realizar las consultas necesarias para obtener los detalles de la tabla DetalleCotizacion
    -- y retornar los resultados
    SELECT IdTablaElemento, Item, DescripcionGastos, FlagAprobacion, FlagEstado, Costo
    FROM DetalleCotizacion
    WHERE IdCotizacion = @IdCotizacion;
END;
GO

CREATE PROCEDURE usp_ValidarCodigoProductoDuplicado
    @IdCotizacion INT,
    @CodigoProducto VARCHAR(50),
    @ExisteDuplicado BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM CotizacionKIRA WHERE CodigoProducto = @CodigoProducto AND IdCotizacion <> @IdCotizacion)
        SET @ExisteDuplicado = 1;
    ELSE
        SET @ExisteDuplicado = 0;

    RETURN;
END
GO

CREATE PROCEDURE usp_ObtenerSiguienteNumeroCotizacion
AS
BEGIN
    DECLARE @SiguienteNumero INT;

    SELECT @SiguienteNumero = ISNULL(MAX(IdCotizacion), 0) + 1
    FROM CotizacionKIRA;

    SELECT @SiguienteNumero AS SiguienteNumero;
	END
GO

CREATE PROCEDURE usp_FiltrarCotizacionesPorPeriodoYNumero
    @Periodo INT,
    @NumeroCotizacion INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
	    CK.IdCotizacion ,
        CK.CodigoProducto,
        CK.Descripcion,
        CK.CostoMateriales,
        CK.CostoInsumos,
        CK.CostoAccesorios,
        CK.CostoManoObra,
        CK.CostoMovilidad,
        CK.CostoEquipos,
        CK.TotalGastos,
        CK.PrecioVenta,
        CK.Fecha,
        TE.DescTablaElemento -- Agregamos la columna DescTablaElemento
    FROM CotizacionKIRA CK INNER JOIN TablaElemento TE ON CK.IdTablaElemento = TE.IdTablaElemento -- Realizamos un INNER JOIN con la tabla TablaElemento
    WHERE YEAR(Fecha) = @Periodo AND IdCotizacion = @NumeroCotizacion;
END
GO

CREATE PROCEDURE usp_FiltrarCotizacionesPorPeriodoYNumeroproducto
    @Periodo INT,
    @NumeroCotizacion INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
	    CK.IdCotizacion ,
        CK.CodigoProducto,
        CK.Descripcion,
        CK.CostoProductos,
        CK.TotalGastos,
        CK.PrecioVenta,
        CK.Fecha,
        TE.DescTablaElemento -- Agregamos la columna DescTablaElemento
    FROM CotizacionKIRATerminado CK INNER JOIN TablaElemento TE ON CK.IdTablaElemento = TE.IdTablaElemento -- Realizamos un INNER JOIN con la tabla TablaElemento
    WHERE YEAR(Fecha) = @Periodo AND IdCotizacion = @NumeroCotizacion;
END
GO

CREATE PROCEDURE usp_ObtenerCotizacionPorId2
    @IdCotizacion INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
	    CK.IdCotizacion ,
        CK.CodigoProducto,
        CK.Descripcion,
        CK.CostoMateriales,
        CK.CostoInsumos,
        CK.CostoAccesorios,
        CK.CostoManoObra,
        CK.CostoMovilidad,
        CK.CostoEquipos,
        CK.TotalGastos,
        CK.PrecioVenta,
        CK.Fecha,
        TE.DescTablaElemento -- Agregamos la columna DescTablaElemento
    FROM CotizacionKIRA CK INNER JOIN TablaElemento TE ON CK.IdTablaElemento = TE.IdTablaElemento -- Realizamos un INNER JOIN con la tabla TablaElemento
    WHERE IdCotizacion = @IdCotizacion;
END
GO

CREATE PROCEDURE usp_ObtenerCotizacionproductoPorId2
    @IdCotizacion INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
	    CK.IdCotizacion ,
        CK.CodigoProducto,
        CK.Descripcion,
        CK.CostoProductos,
        CK.TotalGastos,
        CK.PrecioVenta,
        CK.Fecha,
        TE.DescTablaElemento -- Agregamos la columna DescTablaElemento
    FROM CotizacionKIRATerminado CK INNER JOIN TablaElemento TE ON CK.IdTablaElemento = TE.IdTablaElemento -- Realizamos un INNER JOIN con la tabla TablaElemento
    WHERE IdCotizacion = @IdCotizacion;
END
GO

exec usp_ObtenerCotizacionPorId 4
exec usp_ObtenerCotizacionproductoPorId 4

CREATE PROCEDURE usp_ObtenerCotizacionPorId
    @IdCotizacion INT
AS
BEGIN
    SELECT
        c.IdCotizacion,
        c.IdTablaElemento,
        c.Fecha,
        c.CodigoProducto,
        c.Descripcion,
        c.Caracteristicas,
        c.Imagen,
        c.CostoMateriales,
        c.CostoInsumos,
        c.CostoAccesorios,
        c.CostoManoObra,
        c.CostoMovilidad,
        c.CostoEquipos,
        c.TotalGastos,
        c.PrecioVenta,
        c.Moneda, -- Columna Moneda agregada
        c.FlagEstado,
        ce.DescTablaElemento,
        dc.DescripcionGastos,
        dc.FlagAprobacion,
        dc.FlagEstado AS FlagEstadoDetalle,
        dc.Costo AS CostoDetalle
    FROM CotizacionKIRA c
    INNER JOIN TablaElemento ce ON c.IdTablaElemento = ce.IdTablaElemento
    LEFT JOIN DetalleCotizacion dc ON c.IdCotizacion = dc.IdCotizacion
    WHERE c.IdCotizacion = @IdCotizacion;
END;
GO

exec usp_ObtenerCotizacionPorId 3
exec usp_ObtenerCotizacionProductoPorId 1

alter PROCEDURE usp_ObtenerCotizacionProductoPorId

    @IdCotizacion INT
AS
BEGIN
    SELECT
        c.IdCotizacion,
        c.IdTablaElemento,
        c.Fecha,
        c.CodigoProducto,
        c.Descripcion,
        c.Caracteristicas,
        c.Imagen,
        c.Moneda,
		ce.DescTablaElemento 
    FROM CotizacionKIRATerminado c INNER JOIN TablaElemento ce ON c.IdTablaElemento = ce.IdTablaElemento
    WHERE c.IdCotizacion = @IdCotizacion;
END;
GO

--CREATE PROCEDURE usp_ObtenerCotizacionProductoPorId(antes)
--   @IdCotizacion INT
--AS
--BEGIN
--    SELECT
--        c.IdCotizacion,
--        c.IdTablaElemento,
--        c.Fecha,
--        c.CodigoProducto,
--        c.Descripcion,
--        c.Caracteristicas,
--        c.Imagen,
--        c.CostoProductos,
--        c.TotalGastos,
--        c.PrecioVenta,
--        c.Moneda, -- Columna Moneda agregada
--        c.FlagEstado,
--        ce.DescTablaElemento,
--        dc.DescripcionGastos,
--        dc.FlagAprobacion,
--        dc.FlagEstado AS FlagEstadoDetalle,
--        dc.Costo AS CostoDetalle
--    FROM CotizacionKIRATerminado c
--    INNER JOIN TablaElemento ce ON c.IdTablaElemento = ce.IdTablaElemento
--    LEFT JOIN DetalleCotizacionTerminado dc ON c.IdCotizacion = dc.IdCotizacion
--    WHERE c.IdCotizacion = @IdCotizacion;
--	end
--GO
 
exec usp_ObtenerCotizacionProductoPorIdprueba 11
usp_ObtenerCotizacionProductoPorId 11

--CREANDO PROCEDIMIENTOS combos Form Edit

CREATE PROCEDURE usp_Combo_ListaTipoCotizacion
@IdTabla INT = 105
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END
GO
CREATE PROCEDURE usp_Combo_ListaMateriales
@IdTabla INT = 106
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END
GO
CREATE PROCEDURE usp_Combo_ListaInsumos
@IdTabla INT = 107
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END

GO
CREATE PROCEDURE usp_Combo_ListaAccesorios
@IdTabla INT = 108
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END

GO
CREATE PROCEDURE usp_Combo_ListaManoObra
@IdTabla INT = 109
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END
GO
CREATE PROCEDURE usp_Combo_ListaMovilidadyViaticos
@IdTabla INT = 110
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END
GO
CREATE PROCEDURE usp_Combo_ListaTipoMoneda
@IdTabla INT = 2
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END
GO
CREATE PROCEDURE usp_Combo_ListaEquiposHerramientas
@IdTabla INT = 111
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END
GO
CREATE PROCEDURE usp_Combo_ListaProductoTerminado
@IdTabla INT = 1111
AS BEGIN
   SET NOCOUNT ON
   SELECT TE.IdTablaElemento,
          TE.IdTabla,
		  TE.Abreviatura,
		  TE.DescTablaElemento,TE.IdTablaExterna,TE.Valor,TE.FlagEstado FROM TablaElemento TE
		  WHERE TE.IdTabla = @IdTabla;
   SET NOCOUNT OFF
   END
GO 



---- PRECIO_PRODUCTO TERMINADO 

CREATE TABLE CotizacionKIRATerminado (
    IdCotizacion INT IDENTITY(1,1) PRIMARY KEY,
    IdTablaElemento INT NOT NULL,
    Fecha DATE NOT NULL,
    CodigoProducto VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    Caracteristicas VARCHAR(500) NOT NULL,
    Imagen NVARCHAR(100),
    CostoProductos DECIMAL(18, 2) NULL, -- cambiar aqui
    TotalGastos DECIMAL(18, 2) NOT NULL,
    PrecioVenta DECIMAL(18, 2) NOT NULL,
    Moneda INT NOT NULL, -- Nuevo campo para la moneda
    FlagEstado BIT NOT NULL, -- Nueva columna agregada
    FOREIGN KEY (IdTablaElemento) REFERENCES TablaElemento (IdTablaElemento),
    FOREIGN KEY (Moneda) REFERENCES TablaElemento (IdTablaElemento) -- Relación con la tabla TablaElemento para la columna Moneda
);
GO



CREATE TABLE DetalleCotizacionTerminado (
    IdCotizacionDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdCotizacion INT NOT NULL,
    IdTablaElemento INT NULL,
    Item INT NULL,
    DescripcionGastos VARCHAR(255)  NULL,
    FlagAprobacion BIT  NULL,
    FlagEstado BIT  NULL, -- Nueva columna agregada
    Costo DECIMAL(18, 2)  NULL, -- Nueva columna agregada
    FOREIGN KEY (IdCotizacion) REFERENCES CotizacionKIRATerminado (IdCotizacion),
    FOREIGN KEY (IdTablaElemento) REFERENCES TablaElemento (IdTablaElemento)
);
GO


CREATE PROCEDURE usp_RegistrarCotizacionYDetalleProductosTerminados
(
    @IdTablaElemento INT,
    @Fecha DATE,
    @CodigoProducto VARCHAR(50),
    @Descripcion VARCHAR(255),
    @Caracteristicas VARCHAR(500),
    @Imagen NVARCHAR(100),
    @CostoProductos DECIMAL(18, 2), -- cambiar aqui
    @TotalGastos DECIMAL(18, 2),
    @PrecioVenta DECIMAL(18, 2),
    @Moneda INT, -- Nuevo parámetro para la moneda
    @DetalleCotizacion dbo.DetalleCotizacionType READONLY,
    @IdCotizacion INT OUTPUT,
    @FlagEstado BIT -- Nuevo parámetro para el FlagEstado de la Cotización
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar la cotización en la tabla "CotizacionKIRA"
    INSERT INTO CotizacionKIRATerminado (IdTablaElemento, Fecha, CodigoProducto, Descripcion, Caracteristicas, Imagen, CostoProductos, TotalGastos, PrecioVenta, Moneda, FlagEstado)
    VALUES (@IdTablaElemento, @Fecha, @CodigoProducto, @Descripcion, @Caracteristicas, @Imagen, @CostoProductos,@TotalGastos, @PrecioVenta, @Moneda, @FlagEstado)

    -- Obtener el ID de la cotización recién insertada
    SET @IdCotizacion = SCOPE_IDENTITY()

    -- Insertar los detalles de cotización desde la tabla estructurada a la tabla "DetalleCotizacion"
    INSERT INTO DetalleCotizacionTerminado (IdCotizacion, IdTablaElemento, Item, DescripcionGastos, FlagAprobacion, FlagEstado, Costo)
    SELECT @IdCotizacion, IdTablaElemento, Item, DescripcionGastos, FlagAprobacion, FlagEstado, Costo
    FROM @DetalleCotizacion
END

-- validar usp_RegistrarCotizacionYDetalleProductosTerminados
-- Declarar una variable para almacenar el IdCotizacion de salida
DECLARE @IdCotizacionResult INT;

-- Declarar una tabla para almacenar los detalles de cotización
DECLARE @DetalleCotizacionData AS dbo.DetalleCotizacionType;

-- Insertar datos en la tabla de detalles de cotización (puedes ajustar estos valores según tus necesidades)
INSERT INTO @DetalleCotizacionData (IdTablaElemento, Item, DescripcionGastos, FlagAprobacion, FlagEstado, Costo)
VALUES
    (754, 1, 'COSTO INC. IGV', 1, 1, 100.00),
    (755, 1, 'MOVILIDAD', 1, 1, 150.00),
    (756, 2, 'SERVICIOS ADICIONALES', 1, 1, 200.00);

-- Ejecutar el procedimiento almacenado
EXEC usp_RegistrarCotizacionYDetalleProductosTerminados
    @IdTablaElemento = 713,
    @Fecha = '2023-07-18',
    @CodigoProducto = 'PROD002',
    @Descripcion = 'MUEBLE BAR FLOTANTE (desde SQL)',
    @Caracteristicas = 'MUEBLE BAR FLOTANTE / ESTRUCTURA: MELAMINA PELIKANO ROVERE CON FONDO DE ESPEJO / PUERTAS: VIDRIO AHUMADO / ILUMINACIÓN: LED DICROICO LUZ CÁLIDA / MEDIDAS: 2.16m largo x 0.36m profundidad x 0.91m alto',
    @Imagen = 'imagen_producto.jpg',
    @CostoProductos = 800.00,
    @TotalGastos = 1751.50,
    @PrecioVenta = 2919.17,
    @Moneda = 5, -- Asignar el valor correspondiente para la moneda (5 para SOLES)
    @DetalleCotizacion = @DetalleCotizacionData, -- Datos de los detalles de cotización
    @IdCotizacion = @IdCotizacionResult OUTPUT, -- Variable de salida para el IdCotizacion
    @FlagEstado = 1; -- Valor para el nuevo parámetro FlagEstado (1 para activo)

-- Verificar el resultado mostrando el IdCotizacion generado
SELECT @IdCotizacionResult AS 'IdCotizacion';
GO
CREATE PROCEDURE usp_ListarCotizacionesproductos
AS

BEGIN
    SET NOCOUNT ON;
    SELECT
	    CK.IdCotizacion ,
        CK.CodigoProducto,
        CK.Descripcion,
        CK.CostoProductos,
        CK.TotalGastos,
        CK.PrecioVenta,
        CK.Fecha,
        TE.DescTablaElemento -- Agregamos la columna DescTablaElemento
    FROM CotizacionKIRATerminado CK
    INNER JOIN TablaElemento TE ON CK.IdTablaElemento = TE.IdTablaElemento -- Realizamos un INNER JOIN con la tabla TablaElemento
    WHERE CK.FlagEstado = 1; -- Filtrar solo los registros con FlagEstado igual a 1
	END
GO

CREATE PROCEDURE ObtenerDetallesCotizacion
    @IdTabla int,
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  dc.DescripcionGastos, dc.Costo
    FROM DetalleCotizacion dc
    INNER JOIN CotizacionKIRA c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    WHERE te.IdTabla = @IdTabla AND c.IdCotizacion = @IdCotizacion;
END;
GO

CREATE PROCEDURE ObtenerDetallesCotizacionprodcuto
    @IdTabla int,
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  dc.DescripcionGastos, dc.Costo
    FROM DetalleCotizacionTerminado dc
    INNER JOIN CotizacionKIRATerminado c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    WHERE te.IdTabla = @IdTabla AND c.IdCotizacion = @IdCotizacion;
END;
GO

--- Obtiene detalleCotizacion PESTAÑAS

CREATE PROCEDURE ObtenerDetallesCotizacionMateriales
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT te.IdTablaElemento ,dc.IdCotizacionDetalle, dc.IdCotizacion, t.DescTabla, DescripcionGastos, dc.Costo
    FROM DetalleCotizacion dc
    INNER JOIN CotizacionKIRA c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    INNER JOIN Tabla t ON te.IdTabla = t.IdTabla
    WHERE te.IdTabla = 106 AND c.IdCotizacion = @IdCotizacion;
END;
GO

CREATE PROCEDURE ObtenerDetallesCotizacionProductos
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT te.IdTablaElemento ,dc.IdCotizacionDetalle, dc.IdCotizacion, t.DescTabla, DescripcionGastos, dc.Costo
    FROM DetalleCotizacionTerminado dc
    INNER JOIN CotizacionKIRATerminado c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    INNER JOIN Tabla t ON te.IdTabla = t.IdTabla
    WHERE te.IdTabla = 1111 AND c.IdCotizacion = @IdCotizacion;
END;
GO


CREATE PROCEDURE ObtenerDetallesCotizacionIsumos
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

     SELECT te.IdTablaElemento ,dc.IdCotizacionDetalle, dc.IdCotizacion, t.DescTabla, DescripcionGastos, dc.Costo
    FROM DetalleCotizacion dc
    INNER JOIN CotizacionKIRA c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    INNER JOIN Tabla t ON te.IdTabla = t.IdTabla
    WHERE te.IdTabla = 107 AND c.IdCotizacion = @IdCotizacion;
END;
GO
CREATE PROCEDURE ObtenerDetallesCotizacionAccesorios
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;
	SELECT te.IdTablaElemento ,dc.IdCotizacionDetalle, dc.IdCotizacion, t.DescTabla, DescripcionGastos, dc.Costo
    FROM DetalleCotizacion dc
    INNER JOIN CotizacionKIRA c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    INNER JOIN Tabla t ON te.IdTabla = t.IdTabla
    WHERE te.IdTabla = 108 AND c.IdCotizacion = @IdCotizacion;
END;
GO
CREATE PROCEDURE ObtenerDetallesCotizacionManoObra
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT te.IdTablaElemento ,dc.IdCotizacionDetalle, dc.IdCotizacion, t.DescTabla, DescripcionGastos, dc.Costo
    FROM DetalleCotizacion dc
    INNER JOIN CotizacionKIRA c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    INNER JOIN Tabla t ON te.IdTabla = t.IdTabla
    WHERE te.IdTabla = 109 AND c.IdCotizacion = @IdCotizacion;
END;
GO
CREATE PROCEDURE ObtenerDetallesCotizacionMovilidad
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

   SELECT te.IdTablaElemento ,dc.IdCotizacionDetalle, dc.IdCotizacion, t.DescTabla, DescripcionGastos, dc.Costo
    FROM DetalleCotizacion dc
    INNER JOIN CotizacionKIRA c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    INNER JOIN Tabla t ON te.IdTabla = t.IdTabla
    WHERE te.IdTabla = 110 AND c.IdCotizacion = @IdCotizacion;
END;
GO
CREATE PROCEDURE ObtenerDetallesCotizacionEquipos
    @IdCotizacion int
AS
BEGIN
    SET NOCOUNT ON;

     SELECT te.IdTablaElemento ,dc.IdCotizacionDetalle, dc.IdCotizacion, t.DescTabla, DescripcionGastos, dc.Costo
    FROM DetalleCotizacion dc
    INNER JOIN CotizacionKIRA c ON dc.IdCotizacion = c.IdCotizacion
    INNER JOIN TablaElemento te ON dc.IdTablaElemento = te.IdTablaElemento
    INNER JOIN Tabla t ON te.IdTabla = t.IdTabla
    WHERE te.IdTabla = 111 AND c.IdCotizacion = @IdCotizacion;
END;
GO

CREATE TYPE dbo.NuevoDetalleCotizacionType AS TABLE
(
    IdCotizacion INT NOT NULL,
    IdCotizacionDetalle INT NOT NULL,
    DescripcionGastos VARCHAR(255) NOT NULL,
    Costo DECIMAL(18, 2) NOT NULL
);
GO
CREATE PROCEDURE usp_ActualizarCotizacionDetalle
(
    @NuevoDetalleCotizacionActualizado dbo.NuevoDetalleCotizacionType READONLY
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar los datos en la tabla "DetalleCotizacion" utilizando la nueva tabla estructurada
    UPDATE d
    SET
        d.DescripcionGastos = u.DescripcionGastos,
        d.Costo = u.Costo
    FROM DetalleCotizacion d
    INNER JOIN @NuevoDetalleCotizacionActualizado u ON d.IdCotizacion = u.IdCotizacion AND d.IdCotizacionDetalle = u.IdCotizacionDetalle;
END; 

CREATE PROCEDURE usp_ActualizarCotizacionDetalleProducto
(
    @NuevoDetalleCotizacionActualizado dbo.NuevoDetalleCotizacionType READONLY
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar los datos en la tabla "DetalleCotizacion" utilizando la nueva tabla estructurada
    UPDATE d
    SET
        d.DescripcionGastos = u.DescripcionGastos,
        d.Costo = u.Costo
    FROM DetalleCotizacionTerminado d
    INNER JOIN @NuevoDetalleCotizacionActualizado u ON d.IdCotizacion = u.IdCotizacion AND d.IdCotizacionDetalle = u.IdCotizacionDetalle;
END; 


---validar usp_ActualizarCotizacionDetalle
-- Crear la nueva tabla estructurada
DECLARE @UpdatedDetails dbo.NuevoDetalleCotizacionType;

INSERT INTO @UpdatedDetails (IdCotizacion, IdCotizacionDetalle, DescripcionGastos, Costo)
VALUES
    (3, 4, 'Nuevo Gasto 1', 120.0),
    (3, 5, 'Nuevo Gasto 2', 180.0);

-- Llamar al procedimiento almacenado para actualizar los detalles
EXEC usp_ActualizarCotizacionDetalle @UpdatedDetails;

-- Verificar que los detalles se hayan actualizado correctamente
SELECT * FROM DetalleCotizacion WHERE IdCotizacion = 2;
GO
CREATE PROCEDURE usp_EliminarDetalleCotizacion
(
    @IdCotizacionDetalle INT
)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM DetalleCotizacion WHERE IdCotizacionDetalle = @IdCotizacionDetalle;
END;
GO

CREATE PROCEDURE usp_EliminarDetalleCotizacionProducto
(
    @IdCotizacionDetalle INT
)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM DetalleCotizacionTerminado WHERE IdCotizacionDetalle = @IdCotizacionDetalle;
END;
GO

CREATE PROCEDURE usp_AgregarDetalleCotizacion
(
    @IdCotizacion INT,
	@IdTablaElemento INT, -- Agrega este parámetro
    @DescripcionGastos NVARCHAR(200),
    @Costo DECIMAL(18, 2)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO DetalleCotizacion (IdCotizacion,IdTablaElemento, DescripcionGastos, Costo)
    VALUES (@IdCotizacion,@IdTablaElemento, @DescripcionGastos, @Costo);
END;
-- Ejemplo de ejecución de usp_AgregarDetalleCotizacion
DECLARE @IdCotizacion INT = 2; -- Cambia el valor según la cotización a la que deseas agregar el detalle
DECLARE @IdTablaElemento INT = 715;
DECLARE @DescripcionGastos NVARCHAR(200) = 'Descripción de gastos de prueba';
DECLARE @Costo DECIMAL(18, 2) = 100.00; -- Cambia el costo según el valor deseado

EXEC usp_AgregarDetalleCotizacion @IdCotizacion, @IdTablaElemento, @DescripcionGastos, @Costo;
-- Consulta para verificar los detalles de cotización relacionados con una cotización
SELECT * FROM DetalleCotizacion WHERE IdCotizacion = @IdCotizacion;
GO


CREATE PROCEDURE usp_AgregarDetalleCotizacionProducto
(
    @IdCotizacion INT,
	@IdTablaElemento INT, -- Agrega este parámetro
    @DescripcionGastos NVARCHAR(200),
    @Costo DECIMAL(18, 2)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO DetalleCotizacionTerminado(IdCotizacion,IdTablaElemento, DescripcionGastos, Costo)
    VALUES (@IdCotizacion,@IdTablaElemento, @DescripcionGastos, @Costo);
END;

CREATE PROCEDURE usp_ObtenerUltimoDetalleCotizacion
(
    @IdCotizacion INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 IdCotizacionDetalle, IdCotizacion, IdTablaElemento, DescripcionGastos, Costo
    FROM DetalleCotizacion
    WHERE IdCotizacion = @IdCotizacion
    ORDER BY IdCotizacionDetalle DESC;
END;
GO

CREATE PROCEDURE usp_ObtenerUltimoDetalleCotizacionProducto
(
    @IdCotizacion INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 IdCotizacionDetalle, IdCotizacion, IdTablaElemento, DescripcionGastos, Costo
    FROM DetalleCotizacionTerminado
    WHERE IdCotizacion = @IdCotizacion
    ORDER BY IdCotizacionDetalle DESC;
END;
GO


exec  ObtenerDetallesCotizacionMateriales 1
exec ObtenerDetallesCotizacionIsumos 1
exec ObtenerDetallesCotizacionAccesorios 1
exec ObtenerDetallesCotizacionManoObra 1
exec ObtenerDetallesCotizacionMovilidad 1
exec ObtenerDetallesCotizacionEquipos 1
select * from CotizacionKIRA
EXEC ObtenerDetallesCotizacion 106 ,1
EXEC ObtenerDetallesCotizacion 107 ,1
EXEC ObtenerDetallesCotizacion 108 ,1
EXEC ObtenerDetallesCotizacion 109 ,1
EXEC ObtenerDetallesCotizacionProductos 7;
select * from CotizacionKIRA
where IdCotizacion = 5 ; 
select * from DetalleCotizacion
WHERE IdCotizacion = 5
exec usp_ObtenerCotizacionproductoPorId 2
-----

--DELETE FROM CotizacionKIRA;
--DBCC  CHECKIDENT ('DetalleCotizacion', RESEED, 0);
--MATERIALES  106
--INSUMOS     107
--ACCESORIOS  108
--MANO DE OBRA  109
--MOVILIDAD Y VIATICOS  110
--EQUIPOS Y HERRAMIENTAS 111
--PRODUCTO TERMINADO  1111


alter PROCEDURE usp_rptCotizacionKira
    @IdCotizacion INT
AS
BEGIN
    SELECT
        c.IdCotizacion,
        c.IdTablaElemento,
        c.Fecha,
        c.CodigoProducto,
        c.Descripcion,
        c.Caracteristicas,
        c.CostoMateriales,
        c.CostoInsumos,
        c.CostoAccesorios,
        c.CostoManoObra,
        c.CostoMovilidad,
        c.CostoEquipos,
        c.TotalGastos,
        c.PrecioVenta,
        c.Moneda as IdMoneda , -- Columna Moneda agregada
        ce.DescTablaElemento
    FROM CotizacionKIRA c
    INNER JOIN TablaElemento ce ON c.IdTablaElemento = ce.IdTablaElemento
    WHERE c.IdCotizacion = @IdCotizacion;
END;

exec usp_rptCotizacionKira 2

CREATE PROCEDURE usp_rptCotizacionKiraProductoTerminado
    @IdCotizacion INT
AS
BEGIN
    SELECT
        c.IdCotizacion,
        c.IdTablaElemento,
        c.Fecha,
        c.CodigoProducto,
        c.Descripcion,
        c.Caracteristicas,
        c.CostoProductos,
        c.TotalGastos,
        c.PrecioVenta,
        c.Moneda as IdMoneda , -- Columna Moneda agregada
        ce.DescTablaElemento
    FROM CotizacionKIRATerminado c
    INNER JOIN TablaElemento ce ON c.IdTablaElemento = ce.IdTablaElemento
    WHERE c.IdCotizacion = @IdCotizacion;
END;

usp_rptCotizacionKiraProductoTerminado 1