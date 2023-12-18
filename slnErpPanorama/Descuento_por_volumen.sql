--DELETE FROM PromocionVolumenDetalle;
--DBCC  CHECKIDENT ('PromocionVolumenDetalle', RESEED, 0);

--Creacion de las tablas 

-- Crear la tabla PromocionVolumen
CREATE TABLE PromocionVolumen (
    IdPromocionVolumen int IDENTITY (1,1)NOT NULL PRIMARY KEY,
    IdEmpresa int NULL,
    IdTipoCliente int NULL,
    IdFormaPago int NULL,
    IdTienda int NULL,
    IdTipoVenta int NULL,
    DescPromocionVolumen varchar(50) NULL,
    FechaInicio datetime NULL,
    FechaFin datetime NULL,
    FlagContado bit NULL,
    FlagCFrabricacion bit NULL, -- cambiar por C.fabricacion antes era FlagCredito
    FlagAplicaCombinacion bit NULL,  -- cambiar por aplicacombinacion antes era FlagConsignacion
    FlagAplicaxCodigo bit NULL,    -- cambiar por AplicaxCodigo antes era  FlagSeparacion
    FlagContraentrega bit NULL,
    FlagCopagan bit NULL,
    FlagObsequio bit NULL,
    FlagAsaf bit NULL,
    FlagClienteMayorista bit NULL,
    FlagClienteFinal bit NULL,
    FlagWeb bit NULL,
    FlagUcayali bit NULL,
    FlagAndahuaylas bit NULL,
    FlagPrescott bit NULL,
    FlagAviacion bit NULL,
    FlagMegaplaza bit NULL,
    FechaInicioImpresion datetime NULL,
    FechaFinImpresion datetime NULL,
    UsuarioRegistro varchar(20) NULL,
    FechaRegistro datetime NULL,
    FlagEstado bit NULL,
    FlagAviacion2 bit NULL,
    FlagSanMiguel bit NULL
);
GO
-- Crear la tabla PromocionVolumenDetalle
CREATE TABLE PromocionVolumenDetalle (
    IdPromocionVolumenDetalle int IDENTITY (1,1) NOT NULL PRIMARY KEY,
    IdPromocionVolumen int NULL,
    IdProducto int NULL,
	MontoUniXamas numeric null,-- se agrego
	MontoSoloXUni numeric null,-- se agrego
    Descuento numeric NULL,
    FechaRegistro datetime NULL,
    FlagEstado bit NULL,
    FOREIGN KEY (IdPromocionVolumen) REFERENCES PromocionVolumen(IdPromocionVolumen)
);
go
select * from PromocionVolumenDetalle
----
CREATE PROCEDURE [dbo].[usp_PromocionVolumen_ListaFecha]
(
	@pIdEmpresa int,
	@pFlagEstado bit,
	@pFechaDesde datetime,
	@pFechaHasta datetime
)
As
BEGIN

	SET NOCOUNT ON

	SELECT
		PR.IdPromocionVolumen,
		PR.IdEmpresa,
		E.RazonSocial,
		PR.DescPromocionVolumen,
		PR.IdTipoCliente,
		TC.DescTablaElemento AS DescTipoCliente,
		PR.IdFormaPago,
		FP.DescTablaElemento AS DescFormaPago,
		PR.IdTienda,
		ISNULL(TDA.DescTienda,'  *  ')AS DescTienda,
		PR.IdTipoVenta,
		TV.DescTablaElemento AS DescTipoVenta,
		PR.FechaInicio,
		PR.FechaFin,
		PR.FlagContado,
		PR.FlagCFrabricacion,
		PR.FlagAplicaCombinacion,
		PR.FlagAplicaxCodigo,
		PR.FlagContraentrega,
		PR.FlagCopagan,
		PR.FlagObsequio,
		PR.FlagAsaf,
		PR.FlagClienteMayorista,
		PR.FlagClienteFinal,
		PR.FlagUcayali,
		PR.FlagAndahuaylas,
		PR.FlagPrescott,
		PR.FlagAviacion,
		PR.FlagMegaplaza,
		PR.FlagWeb,
		PR.FechaInicioImpresion,
		PR.FechaFinImpresion,
		PR.FlagEstado,
		PR.FlagAviacion2,
		ISNULL(PR.FlagSanMiguel,0) AS  FlagSanMiguel
	FROM
		PromocionVolumen PR
	INNER JOIN
		Empresa E ON PR.IdEmpresa = E.IdEmpresa
	INNER JOIN
		TablaElemento FP ON FP.IdTablaElemento = PR.IdFormaPago
	INNER JOIN
		TablaElemento TC ON PR.IdTipoCliente = TC.IdTablaElemento
	LEFT JOIN 
		TablaElemento TV ON PR.IdTipoVenta = TV.IdTablaElemento
	LEFT JOIN 
		Tienda TDA ON PR.IdTienda = TDA.IdTienda
	WHERE
		PR.FechaInicio BETWEEN CONVERT(VARCHAR,@pFechaDesde,112) AND CONVERT(VARCHAR,@pFechaHasta,112) AND
		PR.FlagEstado = @pFlagEstado

	SET NOCOUNT OFF

END
GO

DECLARE @pFechaDesde datetime = CONVERT(datetime, '01/01/2023', 103); -- Cambia el formato si es necesario
DECLARE @pFechaHasta datetime = CONVERT(datetime, '31/12/2023', 103); -- Cambia el formato si es necesario
exec usp_PromocionVolumen_ListaFecha 1,1,@pFechaDesde,@pFechaHasta


DECLARE @pFechaDesde datetime = CONVERT(datetime, '01/01/2023', 103); -- Cambia el formato si es necesario
DECLARE @pFechaHasta datetime = CONVERT(datetime, '31/12/2023', 103); -- Cambia el formato si es necesario
exec usp_PromocionTemporal_ListaFecha 1,1,@pFechaDesde,@pFechaHasta



---	EXECUTE SP_HELPTEXT usp_PromocionTemporal_Inserta

CREATE PROCEDURE [dbo].[usp_PromocionVolumen_Inserta]
(
	@pIdPromocionVolumen int OUT,
	@pIdEmpresa int,
	@pDescPromocionVolumen varchar(50),
	@pIdTipoCliente int,
	@pIdFormaPago int,
	@pIdTienda int,
	@pIdTipoVenta int,
	@pFechaInicio datetime,
	@pFechaFin datetime,
	@pFlagContado bit,
	@pFlagCFrabricacion bit,
	@pFlagAplicaCombinacion bit,
	@pFlagAplicaxCodigo bit,
	@pFlagContraentrega bit,
	@pFlagCopagan bit,
	@pFlagObsequio bit,
	@pFlagAsaf bit,
	@pFlagClienteMayorista bit,
	@pFlagClienteFinal bit,
	@pFlagUcayali bit,
	@pFlagAndahuaylas bit,
	@pFlagPrescott bit,
	@pFlagAviacion bit,
	@pFlagMegaplaza bit,
	@pFlagWeb bit,
	@pFechaInicioImpresion datetime,
	@pFechaFinImpresion datetime,
	@pFlagEstado bit,
	@pUsuario varchar(15),
	@pMaquina varchar(20),
	@pFlagAviacion2 bit,
	@pFlagSanMiguel bit
)

As

Begin
		Set Nocount On

		Insert Into PromocionVolumen
		(
			IdEmpresa,
			DescPromocionVolumen,
			IdTipoCliente,
			IdFormaPago,
			IdTienda,
			IdTipoVenta,
			FechaInicio,
			FechaFin,
			FlagContado,
			FlagCFrabricacion,
			FlagAplicaCombinacion,
			FlagAplicaxCodigo,
			FlagContraentrega,
			FlagCopagan,
			FlagObsequio,
			FlagAsaf,
			FlagClienteMayorista,
			FlagClienteFinal,
			FlagUcayali,
			FlagAndahuaylas,
			FlagPrescott,
			FlagAviacion,
			FlagMegaplaza,
			FlagWeb,
			FechaInicioImpresion,
			FechaFinImpresion,
			UsuarioRegistro,
			FechaRegistro,
			FlagEstado,
			FlagAviacion2,
			FlagSanMiguel
		)
		Values
		(
			@pIdEmpresa,
			@pDescPromocionVolumen,
			@pIdTipoCliente,
			@pIdFormaPago,
			@pIdTienda,
			@pIdTipoVenta,
			@pFechaInicio,
			@pFechaFin,
			@pFlagContado,
			@pFlagCFrabricacion,
			@pFlagAplicaCombinacion,
			@pFlagAplicaxCodigo,
			@pFlagContraentrega,
			@pFlagCopagan,
			@pFlagObsequio,
			@pFlagAsaf,
			@pFlagClienteMayorista,
			@pFlagClienteFinal,
			@pFlagUcayali,
			@pFlagAndahuaylas,
			@pFlagPrescott,
			@pFlagAviacion,
			@pFlagMegaplaza,
			@pFlagWeb,
			@pFechaInicioImpresion,
			@pFechaFinImpresion,
			@pUsuario,
			GETDATE(),
			@pFlagEstado,
			@pFlagAviacion2,
			@pFlagSanMiguel
		)
		Select @pIdPromocionVolumen= Ident_Current('PromocionVolumen')
		
		--Auditoria
		Declare @vValor varchar(2000)
		Set @vValor ='IdPromocionVolumen' + isnull(convert(varchar(10),@pIdPromocionVolumen),'null') + '||' + 
		'IdEmpresa=' + isnull(convert(varchar(10),@pIdEmpresa),'null') + '||' + 
		'DescPromocionVolumen=' + isnull(@pDescPromocionVolumen,'null') + '||' + 
		'IdTipoCliente=' + isnull(convert(varchar(10),@pIdTipoCliente),'null') + '||' + 
		'IdFormaPago=' + isnull(convert(varchar(10),@pIdFormaPago),'null') + '||' + 
		'FechaInicio=' + isnull(convert(varchar(10),@pFechaInicio),'null') + '||' + 
		'FechaFin=' + isnull(convert(varchar(10),@pFechaFin),'null') + '||' + 
		'FlagContado=' + isnull(convert(char(2),@pFlagContado),'null') + '||' + 
		'FlagCFrabricacion=' + isnull(convert(char(2),@pFlagCFrabricacion),'null') + '||' + 
		'FlagAplicaCombinacion=' + isnull(convert(char(2),@pFlagAplicaCombinacion),'null') + '||' + 
		'FlagAplicaxCodigo=' + isnull(convert(char(2),@pFlagAplicaxCodigo),'null') + '||' + 
		'FlagContraentrega=' + isnull(convert(char(2),@pFlagContraentrega),'null') + '||' + 
		'FlagCopagan=' + isnull(convert(char(2),@pFlagCopagan),'null') + '||' + 
		'FlagObsequio=' + isnull(convert(char(2),@pFlagObsequio),'null') + '||' + 
		'FlagAsaf=' + isnull(convert(char(2),@pFlagAsaf),'null') + '||' + 
		'FlagClienteMayorista=' + isnull(convert(char(2),@pFlagClienteMayorista),'null') + '||' + 
		'FlagClienteFinal=' + isnull(convert(char(2),@pFlagClienteFinal),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@pFlagEstado),'null')
		 
		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_inserta @pIdEmpresa,'PromocionVolumen', 'INSERT', @FechaActual, @pMaquina, @pUsuario, @vValor, ''

End
GO

CREATE PROCEDURE [dbo].[usp_PromocionVolumenDetalle_Inserta] -- agregar modificar SP con nuevos campos m.min y m.max
(
	@pIdPromocionVolumenDetalle int OUT,
	@pIdPromocionVolumen int,
	@pIdProducto int,
	@pDescuento numeric(5,2),
	@pMontoUniXamas numeric(5,2),
	@pMontoSoloXUni numeric(5,2),
	@pFlagEstado bit,
	@pUsuario varchar(15),
	@pMaquina varchar(20)
)

As

Begin
		Set Nocount On

		Insert Into PromocionVolumenDetalle
		(
			IdPromocionVolumen,
			IdProducto,
			Descuento,
			MontoUniXamas,
			MontoSoloXUni,
			FlagEstado
		)
		Values
		(
			@pIdPromocionVolumen,
			@pIdProducto,
			@pDescuento,
			@pMontoUniXamas,
			@pMontoSoloXUni,
			@pFlagEstado
		)
		Select @pIdPromocionVolumenDetalle= Ident_Current('PromocionVolumenDetalle')
		
		--Auditoria
		Declare @vValor varchar(2000)
		Set @vValor ='IdPromocionVolumenDetalle' + isnull(convert(varchar(10),@pIdPromocionVolumenDetalle),'null') + '||' + 
		'IdPromocionVolumen=' + isnull(convert(varchar(10),@pIdPromocionVolumen),'null') + '||' + 
		'IdProducto=' + isnull(convert(varchar(10),@pIdProducto),'null') + '||' + 
		'Descuento=' + isnull(convert(varchar(10),@pDescuento),'null') + '||' + 
		'MontoUniXamas=' + isnull(convert(varchar(10),@pMontoUniXamas),'null') + '||' + 
		'MontoSoloXUni=' + isnull(convert(varchar(10),@pMontoSoloXUni),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@pFlagEstado),'null')

		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_inserta 13,'PromocionVolumenDetalle', 'INSERT', @FechaActual, @pMaquina, @pUsuario, @vValor, ''

End
GO

CREATE PROCEDURE [dbo].[usp_PromocionVolumen_Actualiza]
(
	@pIdPromocionVolumen int,
	@pIdEmpresa int,
	@pDescPromocionVolumen varchar(50),
	@pIdTipoCliente int,
	@pIdFormaPago int,
	@pIdTienda int,
	@pIdTipoVenta int,
	@pFechaInicio datetime,
	@pFechaFin datetime,
	@pFlagContado bit,
	@pFlagCFrabricacion bit,
	@pFlagAplicaCombinacion bit,
	@pFlagAplicaxCodigo bit,
	@pFlagContraentrega bit,
	@pFlagCopagan bit,
	@pFlagObsequio bit,
	@pFlagAsaf bit,
	@pFlagClienteMayorista bit,
	@pFlagClienteFinal bit,
	@pFlagUcayali bit,
	@pFlagAndahuaylas bit,
	@pFlagPrescott bit,
	@pFlagAviacion bit,
	@pFlagMegaplaza bit,
	@pFlagWeb bit,
	@pFechaInicioImpresion datetime,
	@pFechaFinImpresion datetime,
	@pFlagEstado bit,
	@pUsuario varchar(15),
	@pMaquina varchar(20) ,
	@pFlagAviacion2 bit	,
	@pFlagSanMiguel bit
)

As

Begin
		Set Nocount On

		--Variables donde se guardan los valores anteriores y posteriores
		Declare @vValorAnterior varchar(2000)
		Declare @vValorPosterior varchar(2000)
		--Obtener valores anteriores
		declare @aIdPromocionVolumen int
		declare @aIdEmpresa int
		declare @aDescPromocionVolumen varchar(50)
		declare @aIdTipoCliente int
		declare @aIdFormaPago int
		declare @aFechaInicio datetime
		declare @aFechaFin datetime
		declare @aFlagContado bit
		declare @aFlagCFrabricacion bit
		declare @aFlagAplicaCombinacion bit
		declare @aFlagAplicaxCodigo bit
		declare @aFlagContraentrega bit
		declare @aFlagCopagan bit
		declare @aFlagObsequio bit
		declare @aFlagAsaf bit
		declare @aFlagClienteMayorista bit
		declare @aFlagClienteFinal bit
		declare @aFlagEstado bit
		 
		Select  
		@aIdEmpresa= IdEmpresa,
		@aDescPromocionVolumen= DescPromocionVolumen,
		@aIdTipoCliente= IdTipoCliente,
		@aIdFormaPago= IdFormaPago,
		@aFechaInicio= FechaInicio,
		@aFechaFin= FechaFin,
		@aFlagContado= FlagContado,
		@aFlagCFrabricacion= FlagCFrabricacion,
		@aFlagAplicaCombinacion= FlagAplicaCombinacion,
		@aFlagAplicaxCodigo= FlagAplicaxCodigo,
		@aFlagContraentrega= FlagContraentrega,
		@aFlagCopagan= FlagCopagan,
		@aFlagObsequio= FlagObsequio,
		@aFlagAsaf= FlagAsaf,
		@aFlagClienteMayorista= FlagClienteMayorista,
		@aFlagClienteFinal= FlagClienteFinal,
		@aFlagEstado= FlagEstado
		From  PromocionVolumen
		Where IdPromocionVolumen = @pIdPromocionVolumen
		 
		Set @vValorAnterior ='IdPromocionVolumen' + isnull(convert(varchar(10),@aIdPromocionVolumen),'null') + '||' + 
		'IdEmpresa=' + isnull(convert(varchar(10),@aIdEmpresa),'null') + '||' + 
		'DescPromocionVolumen=' + isnull(@aDescPromocionVolumen,'null') + '||' + 
		'IdTipoCliente=' + isnull(convert(varchar(10),@aIdTipoCliente),'null') + '||' + 
		'IdFormaPago=' + isnull(convert(varchar(10),@aIdFormaPago),'null') + '||' + 
		'FechaInicio=' + isnull(convert(varchar(10),@aFechaInicio),'null') + '||' + 
		'FechaFin=' + isnull(convert(varchar(10),@aFechaFin),'null') + '||' + 
		'FlagContado=' + isnull(convert(char(2),@aFlagContado),'null') + '||' + 
		'FlagCFrabricacion=' + isnull(convert(char(2),@aFlagCFrabricacion),'null') + '||' + 
		'FlagAplicaCombinacion=' + isnull(convert(char(2),@aFlagAplicaCombinacion),'null') + '||' + 
		'FlagAplicaxCodigo=' + isnull(convert(char(2),@aFlagAplicaxCodigo),'null') + '||' + 
		'FlagContraentrega=' + isnull(convert(char(2),@aFlagContraentrega),'null') + '||' + 
		'FlagCopagan=' + isnull(convert(char(2),@aFlagCopagan),'null') + '||' + 
		'FlagObsequio=' + isnull(convert(char(2),@aFlagObsequio),'null') + '||' + 
		'FlagAsaf=' + isnull(convert(char(2),@aFlagAsaf),'null') + '||' + 
		'FlagClienteMayorista=' + isnull(convert(char(2),@aFlagClienteMayorista),'null') + '||' + 
		'FlagClienteFinal=' + isnull(convert(char(2),@aFlagClienteFinal),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@aFlagEstado),'null')
		 
		Update PromocionVolumen Set
			IdEmpresa= @pIdEmpresa,
			DescPromocionVolumen= @pDescPromocionVolumen,
			IdTipoCliente= @pIdTipoCliente,
			IdFormaPago= @pIdFormaPago,
			IdTienda= @pIdTienda,
			IdTipoVenta= @pIdTipoVenta,
			FechaInicio= @pFechaInicio,
			FechaFin= @pFechaFin,
			FlagContado= @pFlagContado,
			FlagCFrabricacion= @pFlagCFrabricacion,
			FlagAplicaCombinacion= @pFlagAplicaCombinacion,
			FlagAplicaxCodigo= @pFlagAplicaxCodigo,
			FlagContraentrega= @pFlagContraentrega,
			FlagCopagan= @pFlagCopagan,
			FlagObsequio= @pFlagObsequio,
			FlagAsaf= @pFlagAsaf,
			FlagClienteMayorista= @pFlagClienteMayorista,
			FlagClienteFinal= @pFlagClienteFinal,
			FlagUcayali= @pFlagUcayali,
			FlagAndahuaylas= @pFlagAndahuaylas,
			FlagPrescott= @pFlagPrescott,
			FlagAviacion= @pFlagAviacion,
			FlagMegaplaza= @pFlagMegaplaza,
			FlagWeb= @pFlagWeb,
			FechaInicioImpresion = @pFechaInicioImpresion,
			FechaFinImpresion = @pFechaFinImpresion,
			FlagEstado= @pFlagEstado,
			FlagAviacion2= @pFlagAviacion2,
			FlagSanMiguel=@pFlagSanMiguel
		Where IdPromocionVolumen = @pIdPromocionVolumen
		 
		Set @vValorPosterior ='IdPromocionVolumen' + isnull(convert(varchar(10),@pIdPromocionVolumen),'null') + '||' + 
		'IdEmpresa=' + isnull(convert(varchar(10),@pIdEmpresa),'null') + '||' + 
		'DescPromocionVolumen=' + isnull(@aDescPromocionVolumen,'null') + '||' + 
		'IdTipoCliente=' + isnull(convert(varchar(10),@pIdTipoCliente),'null') + '||' + 
		'IdFormaPago=' + isnull(convert(varchar(10),@pIdFormaPago),'null') + '||' + 
		'FechaInicio=' + isnull(convert(varchar(10),@pFechaInicio),'null') + '||' + 
		'FechaFin=' + isnull(convert(varchar(10),@pFechaFin),'null') + '||' + 
		'FlagContado=' + isnull(convert(char(2),@pFlagContado),'null') + '||' + 
		'FlagCFrabricacion=' + isnull(convert(char(2),@pFlagCFrabricacion),'null') + '||' + 
		'FlagAplicaCombinacion=' + isnull(convert(char(2),@pFlagAplicaCombinacion),'null') + '||' + 
		'FlagAplicaxCodigo=' + isnull(convert(char(2),@pFlagAplicaxCodigo),'null') + '||' + 
		'FlagContraentrega=' + isnull(convert(char(2),@pFlagContraentrega),'null') + '||' + 
		'FlagCopagan=' + isnull(convert(char(2),@pFlagCopagan),'null') + '||' + 
		'FlagObsequio=' + isnull(convert(char(2),@pFlagObsequio),'null') + '||' + 
		'FlagAsaf=' + isnull(convert(char(2),@pFlagAsaf),'null') + '||' + 
		'FlagClienteMayorista=' + isnull(convert(char(2),@pFlagClienteMayorista),'null') + '||' + 
		'FlagClienteFinal=' + isnull(convert(char(2),@pFlagClienteFinal),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@pFlagEstado),'null')
		 
		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_inserta @pIdEmpresa,'PromocionVolumen', 'UPDATE', @FechaActual, @pMaquina, @pUsuario, @vValorAnterior, @vValorPosterior

		Set Nocount Off

End
GO

CREATE PROCEDURE [dbo].[usp_PromocionVolumenDetalle_Actualiza]
(
	@pIdPromocionVolumenDetalle int,
	@pIdPromocionVolumen int,
	@pIdProducto int,
	@pDescuento numeric(5,2),
	@pMontoUniXamas numeric(5,2),
	@pMontoSoloXUni numeric(5,2),
	@pFlagEstado bit,
	@pUsuario varchar(15),
	@pMaquina varchar(20)
)

As

Begin
		Set Nocount On

		--Variables donde se guardan los valores anteriores y posteriores
		Declare @vValorAnterior varchar(2000)
		Declare @vValorPosterior varchar(2000)
		--Obtener valores anteriores
		declare @aIdPromocionVolumenDetalle int
		declare @aIdPromocionVolumen int
		declare @aIdProducto int
		declare @aDescuento numeric(5,2)
		declare @aMontoUniXamas numeric(5,2)
		declare @aMontoSoloXUni numeric(5,2)
		declare @aFechaRegistro datetime
		declare @aFlagEstado bit
		 
		Select  
		@aIdPromocionVolumen= IdPromocionVolumen,
		@aIdProducto= IdProducto,
		@aDescuento= Descuento,
		@aMontoUniXamas = MontoUniXamas,
		@aMontoSoloXUni = MontoSoloXUni,
		@aFechaRegistro= FechaRegistro,
		@aFlagEstado= FlagEstado
		From  PromocionVolumenDetalle
		Where IdPromocionVolumenDetalle = @pIdPromocionVolumenDetalle
		 
		Set @vValorAnterior ='IdPromocionVolumenDetalle' + isnull(convert(varchar(10),@pIdPromocionVolumenDetalle),'null') + '||' + 
		'IdPromocionVolumen=' + isnull(convert(varchar(10),@aIdPromocionVolumen),'null') + '||' + 
		'IdProducto=' + isnull(convert(varchar(10),@aIdProducto),'null') + '||' + 
		'Descuento=' + isnull(convert(varchar(10),@aDescuento),'null') + '||' + 
		'MontoUniXamas=' + isnull(convert(varchar(10),@aMontoUniXamas),'null') + '||' + 
		'MontoSoloXUni=' + isnull(convert(varchar(10),@aMontoSoloXUni),'null') + '||' + 
		'FechaRegistro=' + isnull(convert(varchar(10),@aFechaRegistro),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@aFlagEstado),'null')
		 
		Update PromocionVolumenDetalle Set
			--IdPromocionTemporal= @pIdPromocionTemporal,
			--IdProducto= @pIdProducto,
			Descuento= @pDescuento,
			MontoUniXamas = @pMontoUniXamas,
			MontoSoloXUni = @pMontoSoloXUni
			--FlagEstado= @pFlagEstado
		Where 
			IdPromocionVolumen= @pIdPromocionVolumen AND
			IdProducto = @pIdProducto
		--IdPromocionTemporalDetalle = @pIdPromocionTemporalDetalle

		--IF(@pFlagWeb = 1)
		--BEGIN 
		--	DECLARE @SQL VARCHAR(2000)
		--	SET @SQL = 'sp_refreshview vw_ListadoProductoPrecioWeb'
		--	EXECUTE sp_sqlexec @SQL
		--END
		
		 
		Set @vValorPosterior ='IdPromocionVolumenDetalle' + isnull(convert(varchar(10),@pIdPromocionVolumenDetalle),'null') + '||' + 
		'IdPromocionVolumen=' + isnull(convert(varchar(10),@pIdPromocionVolumen),'null') + '||' + 
		'IdProducto=' + isnull(convert(varchar(10),@pIdProducto),'null') + '||' + 
		'Descuento=' + isnull(convert(varchar(10),@pDescuento),'null') + '||' + 
		'MontoUniXamas=' + isnull(convert(varchar(10),@pMontoUniXamas),'null') + '||' + 
		'MontoSoloXUni=' + isnull(convert(varchar(10),@pMontoSoloXUni),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@pFlagEstado),'null')
		 
		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_inserta 13,'PromocionVolumenDetalle', 'UPDATE', @FechaActual, @pMaquina, @pUsuario, @vValorAnterior, @vValorPosterior

		Set Nocount Off

End
GO

CREATE PROCEDURE [dbo].[usp_PromocionVolumenDetalle_ListaTodosActivo]
(
	@pIdPromocionVolumen int
)
As
BEGIN
	SET NOCOUNT ON	
	--ListaPrecio
	if not exists (select * from tempdb..sysobjects where id = object_id('tempdb..#TmpListaPrecioDetalle'))
	select IdProducto,PrecioCD,Descuento INTO #TmpListaPrecioDetalle from ListaPrecioDetalle WITH(NOLOCK) where FlagEstado =1 and IdListaPrecio = 1
	--Stock
	if not exists (select * from tempdb..sysobjects where id = object_id('tempdb..#TmpStock'))
	SELECT DISTINCT IdAlmacen,IdProducto,Cantidad INTO #TmpStock FROM Stock WITH(NOLOCK) WHERE IdAlmacen IN(1,2,5,12,15,17,18,23,24) AND IdEmpresa = 13
	--Producto
	if not exists (select * from tempdb..sysobjects where id = object_id('tempdb..#TmpProducto'))
	select IdEmpresa,idproducto, CodigoProveedor,NombreProducto,IdUnidadMedida,IdFamiliaProducto,IdLineaProducto,IdSubLineaProducto,IdModeloProducto,IdMaterial,Fecha,FlagNacional,FlagEstado INTO #TmpProducto from Producto WITH(NOLOCK)	
	--Compra
	if not exists (select * from tempdb..sysobjects where id = object_id('tempdb..#TmpFactura'))
	select IdProducto,SUM(FCD.Cantidad)as CantidadToTal,AVG(PrecioUnitario)AS PrecioPromedio, max(FC.FechaCompra)FechaCompra INTO #TmpFactura from FacturaCompra FC WITH(NOLOCK)
	INNER JOIN FacturaCompraDetalle FCD WITH(NOLOCK) ON FC.IdFacturaCompra = FCD.IdFacturaCompra AND FCD.FlagEstado = 1
	where 
		IdEmpresa = 13
	GROUP BY IdProducto

	--SELECT DISTINCT S.IdAlmacen,A.DescAlmacen,IdProducto,Cantidad INTO #TmpStock FROM Stock S INNER JOIN Almacen A ON S.IdAlmacen = A.IdAlmacen  WHERE S.IdAlmacen IN(1,2,4,5,7,12,15) AND S.IdEmpresa = 13
	UPDATE #TmpStock SET Cantidad = 0 WHERE Cantidad < 0
	UPDATE #TmpStock SET Cantidad = 0 WHERE IdProducto in (select IdProducto from Producto WITH(NOLOCK) where IdTipoProducto = 269)

	SELECT * INTO #TmpPromocionTemporalDetalle FROM PromocionVolumenDetalle WITH(NOLOCK) WHERE IdPromocionVolumen = @pIdPromocionVolumen AND FlagEstado = 1

	SELECT
		PBD.IdPromocionVolumen,
		PBD.IdPromocionVolumenDetalle,
		PBD.IdProducto,
		P.CodigoProveedor,
		P.NombreProducto,
		PBD.MontoUniXamas,
		PBD.MontoSoloXUni,
		LP.DescLineaProducto,
		SLP.DescSubLineaProducto,
		(CASE WHEN P.FlagNacional = 1 THEN  ROUND(T.PrecioCD * (1-(PBD.Descuento/100)),2) * V.TipoCambioMinoristaNacional ELSE ROUND(T.PrecioCD * (1-(PBD.Descuento/100)),2) * V.TipoCambioMinorista END) AS Precio,
	---	T.PrecioCD AS Precio,
		T.Descuento DescuentoActual,
		PBD.Descuento,
		--ROUND(T.PrecioCD * (1-(PBD.Descuento/100)),2) Precio2,
	    (CASE WHEN P.FlagNacional = 1 THEN  ROUND(T.PrecioCD * (1-(PBD.Descuento/100)),2) * V.TipoCambioMinoristaNacional ELSE ROUND(T.PrecioCD * (1-(PBD.Descuento/100)),2) * V.TipoCambioMinorista END) AS Precio2,
		P.Fecha,
		ISNULL(FC.CantidadToTal,0) AS CantidadCompra,
		ISNULL(ST.Cantidad,0) AS AlmacenCentral,
		ISNULL(ST2.Cantidad,0) AS AlmacenTienda,
		ISNULL(ST3.Cantidad,0) AS AlmacenAndahuaylas,
		ISNULL(ST5.Cantidad,0) AS AlmacenPrescott,
		ISNULL(ST6.Cantidad,0) AS AlmacenAviacion,
		ISNULL(ST7.Cantidad,0) AS AlmacenMegaPlaza,
		ISNULL(ST8.Cantidad,0) AS AlmacenAviacion2,

		ISNULL(ST9.Cantidad,0) AS AlmacenSanMiguel,

		P.FlagNacional,
		PBD.FlagEstado
--		ISNULL(ST8.Cantidad,0) AS AlmacenAviacion2
	FROM
		#TmpPromocionTemporalDetalle PBD		INNER JOIN 		#TmpProducto P ON PBD.IdProducto = P.IdProducto
												INNER JOIN		UnidadMedida UM ON P.IdUnidadMedida = UM.IdUnidadMedida
												INNER JOIN		#TmpListaPrecioDetalle T ON PBD.IdProducto = T.IdProducto
												INNER JOIN 		LineaProducto LP WITH(NOLOCK) ON P.IdLineaProducto = LP.IdLineaProducto
												LEFT JOIN 		SubLineaProducto SLP WITH(NOLOCK) ON P.IdSubLineaProducto = SLP.IdSubLineaProducto 
												LEFT JOIN 		#TmpStock ST ON P.IdProducto = ST.IdProducto AND ST.IdAlmacen = 1 --Central
												LEFT JOIN 		#TmpStock ST2 ON P.IdProducto = ST2.IdProducto AND ST2.IdAlmacen = 2 -- Tienda
												LEFT JOIN 		#TmpStock ST3 ON P.IdProducto = ST3.IdProducto AND ST3.IdAlmacen = 5 -- Anda
												LEFT JOIN 		#TmpStock ST5 ON P.IdProducto = ST5.IdProducto AND ST5.IdAlmacen = 15 --Prescott	
												LEFT JOIN 		#TmpStock ST6 ON P.IdProducto = ST6.IdProducto AND ST6.IdAlmacen = 17 --Avia	
												LEFT JOIN 		#TmpStock ST7 ON P.IdProducto = ST7.IdProducto AND ST7.IdAlmacen = 18 --Mega
												LEFT JOIN 		#TmpStock ST8 ON P.IdProducto = ST8.IdProducto AND ST8.IdAlmacen = 23 --Aviacion 2
												LEFT JOIN 		#TmpStock ST9 ON P.IdProducto = ST9.IdProducto AND ST9.IdAlmacen = 24 --San Miguel
												LEFT JOIN 		#TmpFactura FC ON P.IdProducto = FC.IdProducto
												LEFT JOIN		Variables V WITH(NOLOCK) ON P.IdEmpresa = V.IdEmpresa
	WHERE
		PBD.IdPromocionVolumen = @pIdPromocionVolumen AND
		PBD.FlagEstado=1
	--ORDER BY
	--	CD.IdPromocionTemporalDetalle

	DROP TABLE #TmpStock
	DROP TABLE #TmpListaPrecioDetalle
	DROP TABLE #TmpProducto
	DROP TABLE #TmpPromocionTemporalDetalle

	SET NOCOUNT OFF
	
END
GO

CREATE PROCEDURE [dbo].[usp_PromocionVolumenDetalle_EliminaTodo]
(
	@pIdPromocionVolumen int, 
	@pIdEmpresa int,
	@pUsuario varchar(15),
	@pMaquina varchar(20)
)

As

Begin
		Set Nocount On

		DELETE FROM PromocionVolumenDetalle
		Where 
			IdPromocionVolumen = @pIdPromocionVolumen
		 
		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_inserta @pIdEmpresa,'PromocionVolumenDetalle', 'DELETETODO', @FechaActual, @pMaquina, @pUsuario, '', ''

		Set Nocount Off

End
GO

CREATE PROCEDURE [dbo].[usp_PromocionVolumen_Elimina]
(
	@pIdPromocionVolumen int, 
	@pIdEmpresa int,
	@pUsuario varchar(15),
	@pMaquina varchar(20)
)

As

Begin
		Set Nocount On

		--Eliminando el Tabla especificado
		--Variables donde se guardan los valores anteriores y posteriores
		Declare @vValorAnterior varchar(2000)
		Declare @vValorPosterior varchar(2000)
		--Obtener valores anteriores
		declare @aIdPromocionVolumen int
		declare @aIdEmpresa int
		declare @aDescPromocionVolumen varchar(50)
		declare @aIdTipoCliente int
		declare @aIdFormaPago int
		declare @aFechaInicio datetime
		declare @aFechaFin datetime
		declare @aFlagContado bit
		declare @aFlagCFrabricacion bit
		declare @aFlagAplicaCombinacion bit
		declare @aFlagAplicaxCodigo bit
		declare @aFlagContraentrega bit
		declare @aFlagCopagan bit
		declare @aFlagObsequio bit
		declare @aFlagAsaf bit
		declare @aFlagClienteMayorista bit
		declare @aFlagClienteFinal bit
		declare @aFlagEstado bit
		 
		Select  
		@aIdEmpresa= IdEmpresa,
		@aDescPromocionVolumen= DescPromocionVolumen,
		@aIdTipoCliente= IdTipoCliente,
		@aIdFormaPago= IdFormaPago,
		@aFechaInicio= FechaInicio,
		@aFechaFin= FechaFin,
		@aFlagContado= FlagContado,
		@aFlagCFrabricacion= FlagCFrabricacion,
		@aFlagAplicaCombinacion= FlagAplicaCombinacion,
		@aFlagAplicaxCodigo= FlagAplicaxCodigo,
		@aFlagContraentrega= FlagContraentrega,
		@aFlagCopagan= FlagCopagan,
		@aFlagObsequio= FlagObsequio,
		@aFlagAsaf= FlagAsaf,
		@aFlagClienteMayorista= FlagClienteMayorista,
		@aFlagClienteFinal= FlagClienteFinal,
		@aFlagEstado= FlagEstado
		From  PromocionVolumen
		Where IdPromocionVolumen = @pIdPromocionVolumen
		And IdEmpresa = @pIdEmpresa
		Set @vValorAnterior ='IdPromocionVolumen' + isnull(convert(varchar(10),@aIdPromocionVolumen),'null') + '||' + 
		'IdEmpresa=' + isnull(convert(varchar(10),@aIdEmpresa),'null') + '||' + 
		'DescPromocionVolumen=' + isnull(@aDescPromocionVolumen,'null') + '||' + 
		'IdTipoCliente=' + isnull(convert(varchar(10),@aIdTipoCliente),'null') + '||' + 
		'IdFormaPago=' + isnull(convert(varchar(10),@aIdFormaPago),'null') + '||' + 
		'FechaInicio=' + isnull(convert(varchar(10),@aFechaInicio),'null') + '||' + 
		'FechaFin=' + isnull(convert(varchar(10),@aFechaFin),'null') + '||' + 
		'FlagContado=' + isnull(convert(char(2),@aFlagContado),'null') + '||' + 
		'FlagCFrabricacion=' + isnull(convert(char(2),@aFlagCFrabricacion),'null') + '||' + 
		'FlagAplicaCombinacion=' + isnull(convert(char(2),@aFlagAplicaCombinacion),'null') + '||' + 
		'FlagAplicaxCodigo=' + isnull(convert(char(2),@aFlagAplicaxCodigo),'null') + '||' + 
		'FlagContraentrega=' + isnull(convert(char(2),@aFlagContraentrega),'null') + '||' + 
		'FlagCopagan=' + isnull(convert(char(2),@aFlagCopagan),'null') + '||' + 
		'FlagObsequio=' + isnull(convert(char(2),@aFlagObsequio),'null') + '||' + 
		'FlagAsaf=' + isnull(convert(char(2),@aFlagAsaf),'null') + '||' + 
		'FlagClienteMayorista=' + isnull(convert(char(2),@aFlagClienteMayorista),'null') + '||' + 
		'FlagClienteFinal=' + isnull(convert(char(2),@aFlagClienteFinal),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@aFlagEstado),'null')
		 
		Update PromocionVolumen Set
			FlagEstado = 0 
		Where IdPromocionVolumen = @pIdPromocionVolumen
		And IdEmpresa = @pIdEmpresa
		 
		Select  
		@aIdEmpresa= IdEmpresa,
		@aDescPromocionVolumen= DescPromocionVolumen,
		@aIdTipoCliente= IdTipoCliente,
		@aIdFormaPago= IdFormaPago,
		@aFechaInicio= FechaInicio,
		@aFechaFin= FechaFin,
		@aFlagContado= FlagContado,
		@aFlagCFrabricacion= FlagCFrabricacion,
		@aFlagAplicaCombinacion= FlagAplicaCombinacion,
		@aFlagAplicaxCodigo= FlagAplicaxCodigo,
		@aFlagContraentrega= FlagContraentrega,
		@aFlagCopagan= FlagCopagan,
		@aFlagObsequio= FlagObsequio,
		@aFlagAsaf= FlagAsaf,
		@aFlagClienteMayorista= FlagClienteMayorista,
		@aFlagClienteFinal= FlagClienteFinal,
		@aFlagEstado= FlagEstado
		From  PromocionVolumen
		Where IdPromocionVolumen = @pIdPromocionVolumen
		And IdEmpresa = @pIdEmpresa
		 
		Set @vValorPosterior ='IdPromocionVolumen' + isnull(convert(varchar(10),@pIdPromocionVolumen),'null') + '||' + 
		'IdEmpresa=' + isnull(convert(varchar(10),@aIdEmpresa),'null') + '||' + 
		'DescPromocionVolumen=' + isnull(@aDescPromocionVolumen,'null') + '||' + 
		'IdTipoCliente=' + isnull(convert(varchar(10),@aIdTipoCliente),'null') + '||' + 
		'IdFormaPago=' + isnull(convert(varchar(10),@aIdFormaPago),'null') + '||' + 
		'FechaInicio=' + isnull(convert(varchar(10),@aFechaInicio),'null') + '||' + 
		'FechaFin=' + isnull(convert(varchar(10),@aFechaFin),'null') + '||' + 
		'FlagContado=' + isnull(convert(char(2),@aFlagContado),'null') + '||' + 
		'FlagCFrabricacion=' + isnull(convert(char(2),@aFlagCFrabricacion),'null') + '||' + 
		'FlagAplicaCombinacion=' + isnull(convert(char(2),@aFlagAplicaCombinacion),'null') + '||' + 
		'FlagAplicaxCodigo=' + isnull(convert(char(2),@aFlagAplicaxCodigo),'null') + '||' + 
		'FlagContraentrega=' + isnull(convert(char(2),@aFlagContraentrega),'null') + '||' + 
		'FlagCopagan=' + isnull(convert(char(2),@aFlagCopagan),'null') + '||' + 
		'FlagObsequio=' + isnull(convert(char(2),@aFlagObsequio),'null') + '||' + 
		'FlagAsaf=' + isnull(convert(char(2),@aFlagAsaf),'null') + '||' + 
		'FlagClienteMayorista=' + isnull(convert(char(2),@aFlagClienteMayorista),'null') + '||' + 
		'FlagClienteFinal=' + isnull(convert(char(2),@aFlagClienteFinal),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@aFlagEstado),'null')
		 
		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_inserta @pIdEmpresa,'PromocionVolumen', 'DELETE', @FechaActual, @pMaquina, @pUsuario, @vValorAnterior, @vValorPosterior

		Set Nocount Off

End
GO

CREATE PROCEDURE [dbo].[usp_PromocionVolumenDetalle_Elimina]
(
	@pIdPromocionVolumenDetalle int, 
	@pIdEmpresa int,
	@pUsuario varchar(15),
	@pMaquina varchar(20)
)

As

Begin
		Set Nocount On

		--Eliminando el Tabla especificado
		--Variables donde se guardan los valores anteriores y posteriores
		Declare @vValorAnterior varchar(2000)
		Declare @vValorPosterior varchar(2000)
		--Obtener valores anteriores
		declare @aIdPromocionVolumenDetalle int
		declare @aIdPromocionVolumen int
		declare @aIdProducto int
		declare @aDescuento numeric(5,2)
		declare @aFechaRegistro datetime
		declare @aFlagEstado bit
		 
		Select  
		@aIdPromocionVolumen= IdPromocionVolumen,
		@aIdProducto= IdProducto,
		@aDescuento= Descuento,
		@aFechaRegistro= FechaRegistro,
		@aFlagEstado= FlagEstado
		From  PromocionVolumenDetalle
		Where IdPromocionVolumenDetalle = @pIdPromocionVolumenDetalle

		Set @vValorAnterior ='IdPromocionVolumenDetalle' + isnull(convert(varchar(10),@aIdPromocionVolumenDetalle),'null') + '||' + 
		'IdPromocionVolumen=' + isnull(convert(varchar(10),@aIdPromocionVolumen),'null') + '||' + 
		'IdProducto=' + isnull(convert(varchar(10),@aIdProducto),'null') + '||' + 
		'Descuento=' + isnull(convert(varchar(10),@aDescuento),'null') + '||' + 
		'FechaRegistro=' + isnull(convert(varchar(10),@aFechaRegistro),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@aFlagEstado),'null')
		 
		Update PromocionVolumenDetalle Set
			FlagEstado = 0 
		Where IdPromocionVolumenDetalle = @pIdPromocionVolumenDetalle

		 
		Select  
		@aIdPromocionVolumen= IdPromocionVolumen,
		@aIdProducto= IdProducto,
		@aDescuento= Descuento,
		@aFechaRegistro= FechaRegistro,
		@aFlagEstado= FlagEstado
		From  PromocionVolumenDetalle
		Where IdPromocionVolumenDetalle = @pIdPromocionVolumenDetalle

		 
		Set @vValorPosterior ='IdPromocionVolumenDetalle' + isnull(convert(varchar(10),@aIdPromocionVolumenDetalle),'null') + '||' + 
		'IdPromocionVolumen=' + isnull(convert(varchar(10),@aIdPromocionVolumen),'null') + '||' + 
		'IdProducto=' + isnull(convert(varchar(10),@aIdProducto),'null') + '||' + 
		'Descuento=' + isnull(convert(varchar(10),@aDescuento),'null') + '||' + 
		'FechaRegistro=' + isnull(convert(varchar(10),@aFechaRegistro),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@aFlagEstado),'null')
		 
		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_inserta @pIdEmpresa,'PromocionTemporalDetalle', 'DELETE', @FechaActual, @pMaquina, @pUsuario, @vValorAnterior, @vValorPosterior

		Set Nocount Off

End
GO


CREATE PROCEDURE [dbo].[usp_PromocionTemporal_ListaFecha]
(
	@pIdEmpresa int,
	@pFlagEstado bit,
	@pFechaDesde datetime,
	@pFechaHasta datetime
)
As
BEGIN

	SET NOCOUNT ON

	SELECT
		PR.IdPromocionTemporal,
		PR.IdEmpresa,
		E.RazonSocial,
		PR.DescPromocionTemporal,
		PR.IdTipoCliente,
		TC.DescTablaElemento AS DescTipoCliente,
		PR.IdFormaPago,
		FP.DescTablaElemento AS DescFormaPago,
		PR.IdTienda,
		ISNULL(TDA.DescTienda,'  *  ')AS DescTienda,
		PR.IdTipoVenta,
		TV.DescTablaElemento AS DescTipoVenta,
		PR.FechaInicio,
		PR.FechaFin,
		PR.FlagContado,
		PR.FlagCredito,
		PR.FlagConsignacion,
		PR.FlagSeparacion,
		PR.FlagContraentrega,
		PR.FlagCopagan,
		PR.FlagObsequio,
		PR.FlagAsaf,
		PR.FlagClienteMayorista,
		PR.FlagClienteFinal,
		PR.FlagUcayali,
		PR.FlagAndahuaylas,
		PR.FlagPrescott,
		PR.FlagAviacion,
		PR.FlagMegaplaza,
		PR.FlagWeb,
		PR.FechaInicioImpresion,
		PR.FechaFinImpresion,
		PR.FlagEstado,
		PR.FlagAviacion2,
		ISNULL(PR.FlagSanMiguel,0) AS  FlagSanMiguel
	FROM
		PromocionTemporal PR
	INNER JOIN
		Empresa E ON PR.IdEmpresa = E.IdEmpresa
	INNER JOIN
		TablaElemento FP ON FP.IdTablaElemento = PR.IdFormaPago
	INNER JOIN
		TablaElemento TC ON PR.IdTipoCliente = TC.IdTablaElemento
	LEFT JOIN 
		TablaElemento TV ON PR.IdTipoVenta = TV.IdTablaElemento
	LEFT JOIN 
		Tienda TDA ON PR.IdTienda = TDA.IdTienda
	WHERE
		PR.FechaInicio BETWEEN CONVERT(VARCHAR,@pFechaDesde,112) AND CONVERT(VARCHAR,@pFechaHasta,112) AND
		PR.FlagEstado = @pFlagEstado

	SET NOCOUNT OFF

END
go
--*

exec usp_PromocionTemporalDetalle_SeleccionaTipoClienteFormapago 13,86,61,1,394,9266,0
exec usp_PromocionVolumenDetalle_SeleccionaTipoClienteFormapago  13,86,61,1,394,16197,0
  
CREATE PROCEDURE [dbo].[usp_PromocionVolumenDetalle_SeleccionaTipoClienteFormapago]    
(    
 @pIdEmpresa int,    
 @pIdTipoCliente int,    
 @pIdFormaPago int,    
 @pIdTienda int,    
 @pIdTipoVenta int,    
 @pIdProducto int,  
 @pTraerIdTemDet bit= 0  
)    
As    
BEGIN    
    
 SET NOCOUNT ON    
    
 --ListaPrecioDetalle    
 if not exists (select * from tempdb..sysobjects where id = object_id('tempdb..#TmpListaPrecioDetalle'))    
 SELECT IdProducto,PrecioAB,PrecioCD,Descuento into #TmpListaPrecioDetalle FROM ListaPrecioDetalle WITH(NOLOCK) where IdListaPrecio = 1 AND IdProducto = @pIdProducto AND FlagEstado = 1    
    
 Declare @Select as varchar(2500)=''     
 Declare @FormaPago as varchar(30)    
 Declare @TipoCliente as varchar(30)    
 Declare @Tienda as varchar(30)    
    
 SELECT @FormaPago = DescTablaElemento FROM TablaElemento WITH(NOLOCK) WHERE IdTablaElemento = @pIdFormaPago    
 SELECT @TipoCliente = REPLACE(DescTablaElemento,' ','')  FROM TablaElemento WITH(NOLOCK) WHERE IdTablaElemento = @pIdTipoCliente    
 SELECT @Tienda = DescTienda FROM Tienda WHERE IdTienda = @pIdTienda    
    
    
 SET @Select += '    
 SELECT    
  0 IdPromocionVolumen, '   
 SET @Select += iif (@pTraerIdTemDet=1 , 'PBD.IdPromocionVolumenDetalle,' ,' 0 IdPromocionVolumenDetalle,  ')  
 SET @Select += '0 IdProducto,    
  '''' CodigoProveedor,    
  '''' NombreProducto,    
  '''' Abreviatura,    
  '''' DescLineaProducto,    
  T.PrecioCD as Precio,    
  0 DescuentoActual,    
  MAX(PBD.Descuento) AS Descuento,    
  ROUND(T.PrecioCD * (1-(MAX(PBD.Descuento)/100)),2) Precio2,    
  ''01/01/2000'' Fecha, --P.Fecha,    
  PBD.FlagEstado    
 FROM  PromocionVolumen PB WITH(NOLOCK)     
 INNER JOIN  PromocionVolumenDetalle PBD WITH(NOLOCK) ON PB.IdPromocionVolumen = PBD.IdPromocionVolumen AND PBD.FlagEstado = 1    
 INNER JOIN     #TmpListaPrecioDetalle T ON PBD.IdProducto = T.IdProducto    
 WHERE     
  PB.IdEmpresa = '+ str(@pIdEmpresa) +' AND '+    
  'PB.Flag' + @TipoCliente +' = 1 AND '+    
  'PB.Flag' + @FormaPago +' = 1 AND '+    
  'PB.Flag' + @Tienda +' = 1 AND '+    
  --'PB.IdTienda IN(' + convert(varchar(2), @pIdTienda) +',0) AND '+     
  'PB.IdTipoVenta IN(' + convert(varchar(4), @pIdTipoVenta) +',0) AND '+    
  'PBD.IdProducto = ' + convert(varchar(10), @pIdProducto) + ' AND '+    
  'getdate() BETWEEN FechaInicio AND FechaFin AND    
  PB.FlagWeb = 0 AND    
  PB.FlagEstado = 1     
 GROUP BY '  
   
  SET @Select += iif (@pTraerIdTemDet=1 , 'PBD.IdPromocionVolumenDetalle,' ,' ')  
  SET @Select +='PBD.IdProducto,T.PrecioCD,PBD.FlagEstado'    
  SET @Select += iif (@pTraerIdTemDet=1 , ' order by Descuento asc' ,' ')  
    
 EXEC (@Select)    
    
 SET NOCOUNT OFF    
     
END 
go

-- Crear el procedimiento almacenado

CREATE PROCEDURE usp_ValidarPromocion
    @IdPromocionVolumen int
AS
BEGIN
    DECLARE @FlagAplicaCombinacion bit
    DECLARE @FlagAplicaxCodigo bit
    DECLARE @MontoUniXamas numeric
    DECLARE @MontoSoloXUni numeric

    -- Obtener FlagAplicaCombinacion y FlagAplicaxCodigo de la tabla PromocionVolumen
    SELECT @FlagAplicaCombinacion = pv.FlagAplicaCombinacion, @FlagAplicaxCodigo = pv.FlagAplicaxCodigo
    FROM PromocionVolumen pv
    WHERE pv.IdPromocionVolumen = @IdPromocionVolumen and pv.FlagEstado = 1

     -- Obtener MontoUniXamas y MontoSoloXUni de un producto asociado al IdPromocionVolumen
    SELECT TOP 1 @MontoUniXamas = pvd.MontoUniXamas, @MontoSoloXUni = pvd.MontoSoloXUni
    FROM PromocionVolumenDetalle pvd
    WHERE pvd.IdPromocionVolumen = @IdPromocionVolumen and pvd.FlagEstado = 1

    -- Contar cuántos productos están asociados al IdPromocionVolumen
    DECLARE @NumProductos int
    SELECT @NumProductos = COUNT(*)
    FROM PromocionVolumenDetalle pvd
    WHERE pvd.IdPromocionVolumen = @IdPromocionVolumen and pvd.FlagEstado = 1

    -- Devolver resultados
    SELECT @NumProductos AS CantidadProductos, @FlagAplicaCombinacion AS FlagCombinacion, @FlagAplicaxCodigo AS FlagAplicaxCodigo, @MontoUniXamas AS MontoTotalUniXamas, @MontoSoloXUni AS MontoTotalSoloXUni
END
GO

EXEC usp_ValidarPromocion 2

CREATE PROCEDURE usp_ValidarPromocion_IDProducto
    @IdProducto int
AS
BEGIN
    DECLARE @FlagAplicaCombinacion bit
    DECLARE @FlagAplicaxCodigo bit
    DECLARE @MontoUniXamas numeric
    DECLARE @MontoSoloXUni numeric

    -- Obtener FlagAplicaCombinacion y FlagAplicaxCodigo de la tabla PromocionVolumen
    SELECT @FlagAplicaCombinacion = pv.FlagAplicaCombinacion, @FlagAplicaxCodigo = pv.FlagAplicaxCodigo
    FROM PromocionVolumenDetalle pvd  inner join PromocionVolumen pv on pvd.IdPromocionVolumen = pv.IdPromocionVolumen
    WHERE pvd.IdProducto = @IdProducto and pv.FlagEstado = 1

     -- Obtener MontoUniXamas y MontoSoloXUni de un producto asociado al IdPromocionVolumen
    SELECT TOP 1 @MontoUniXamas = pvd.MontoUniXamas, @MontoSoloXUni = pvd.MontoSoloXUni
    FROM PromocionVolumenDetalle pvd
    WHERE pvd.IdProducto = @IdProducto and pvd.FlagEstado = 1

    -- Contar cuántos productos están asociados al IdProducto
    DECLARE @NumProductos int
    SELECT @NumProductos = COUNT(*)
    FROM PromocionVolumenDetalle pvd
    WHERE pvd.IdProducto = @IdProducto and pvd.FlagEstado = 1

    -- Devolver resultados
    SELECT @NumProductos AS Cantidad_MismoCodigo, @FlagAplicaCombinacion AS FlagCombinacion, @FlagAplicaxCodigo AS FlagAplicaxCodigo, @MontoUniXamas AS MontoTotalUniXamas, @MontoSoloXUni AS MontoTotalSoloXUni
END
GO

EXEC usp_ValidarPromocion_IDProducto 65703;
EXEC usp_ValidarPromocion_IDProducto 16197;
EXEC usp_ValidarPromocion_IDProducto 7240;
EXEC usp_ValidarPromocion_IDProducto 7245;
GO

-- Crear el procedimiento almacenado
CREATE PROCEDURE usp_ObtenerProductosPorDetalle
    @IdPromocionVolumen int
AS
BEGIN
    -- Seleccionar los IdProducto asociados al IdPromocionVolumenDetalle
    SELECT IdProducto
    FROM PromocionVolumenDetalle
    WHERE IdPromocionVolumen = (SELECT IdPromocionVolumen FROM PromocionVolumen WHERE IdPromocionVolumen = @IdPromocionVolumen) and FlagEstado = 1
END
go

exec usp_ObtenerProductosPorDetalle 2
GO

CREATE PROCEDURE usp_ObtenerIdPromocionPorIdproducto
    @IdProducto int
AS
BEGIN
    -- Seleccionar los IdProducto asociados al IdPromocionVolumenDetalle
    SELECT IdPromocionVolumen
    FROM PromocionVolumenDetalle
    WHERE IdProducto =  @IdProducto and FlagEstado = 1
END
go

--///////////
exec usp_ObtenerIdPromocionPorIdproducto 7245
exec usp_ObtenerProductosPorDetalle 2
--//////////

select * from TempListaPrecioDetalle


select IdAlmacen, DescAlmacen from Almacen

    SELECT IdPromocionVolumen
    FROM PromocionVolumenDetalle
    WHERE IdProducto = 65703 and FlagEstado = 1


