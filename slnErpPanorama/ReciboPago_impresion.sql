 alter PROCEDURE [dbo].[usp_DocumentoVenta_Inserta]    
(    
 @pIdDocumentoVenta int OUT,    
 @pIdEmpresa int,    
 @pIdTienda int,    
 @pIdPedido int,    
 @pPeriodo int,    
 @pMes tinyint,    
 @pIdTipoDocumento int,    
 @pSerie varchar(4),    
 @pNumero varchar(8),    
 @pIdDocumentoReferencia int,    
    
 @pFecha datetime,    
 @pFechaVencimiento datetime,    
 @pIdCliente int,    
 @pNumeroDocumento varchar(15),    
 @pDescCliente varchar(150),    
 @pDireccion varchar(200),    
 @pIdMoneda int,    
 @pTipoCambio numeric(5,2),    
 @pIdFormaPago int,    
 @pIdVendedor int,    
    
 @pTotalCantidad int,    
 @pSubTotal numeric(10,2),    
 @pPorcentajeDescuento numeric(10,2),    
 @pDescuento numeric(10,2),    
 @pPorcentajeImpuesto numeric(10,2),    
 @pIgv numeric(10,2),    
 @pIcbper numeric(10,2),    
 @pTotal numeric(10,2),    
 @pTotalBruto numeric(10,2),    
 @pObservacion varchar(100),    
    
 @pIdSituacion int,    
 @pIdPromocionProxima int,    
 @pFlagPromocionProxima bit,    
 @pCodigoNC char(2),    
 @pIdUbigeo int,    
 @pIdUbigeoOrigen int,    
 @pFechaTraslado datetime,    
 @pMotivoTraslado char(2) ,    
 @pModalildadTraslado char(2) ,    
    
 @pNumeroBultos int,    
    
 @pPesoBultos int,    
 @pIdTipoIdentidadTra char(1),    
 @pNumeroDocTra varchar(15),    
 @pRazonSocialTra varchar(50),    
 @pNumeroPlaca varchar(8),    
 @pIdPersonaRegistro int,    
 @pFlagCumpleanios bit=null,  
 @pTotalDscCumpleanios numeric(10,2)=null,  
 @pFlagEstado bit,    
 @pUsuario varchar(15),    
 @pMaquina varchar(20),    
 @pIdComercioAmigo int,

 @pIdTiendaDestinoGuia int,
 @pMarca Varchar(10),
 @pLicenciaConducir varchar(12) )    
As    
    
Begin    
  Set Nocount On    
       
  Declare @pTipoDocId INT = 1 --DNI    
  Declare @IdPedidoEcommerce int    
  --Declare @pModalildadTraslado int    
  --  set @pModalildadTraslado=''    
  Set @IdPedidoEcommerce=(Select isnull(IdPedidoWeb,0) as IdPedidoWeb From Pedido where IdPedido=@pIdPedido)    
    
  IF(LEN(@pNumeroDocumento)=11) SELECT @pTipoDocId = 6 --RUC    
    
  Declare @OperacionGratuita Decimal(10,2)--Operacion Gratuita    
  IF(@pIdFormaPago = 130)    
  BEGIN    
    SET @OperacionGratuita= @pSubTotal    
    SET @pSubTotal= 0    
    SET @pPorcentajeDescuento= 0    
    SET @pDescuento= 0    
    SET @pPorcentajeImpuesto= 0    
    SET @pIgv= 0    
    SET @pTotal= 0    
    SET @pTotalBruto= 0    
  END    
      
       
  Insert Into DocumentoVenta    
  (    
   IdEmpresa,    
   IdTienda,    
   IdPedido,    
   Periodo,    
   Mes,    
   IdTipoDocumento,    
   Serie,    
   Numero,    
   IdDocumentoReferencia,    
   Fecha,    
    
   FechaVencimiento,    
   IdCliente,    
   IdTipoIdentidad,    
   NumeroDocumento,    
   DescCliente,    
   Direccion,    
   IdMoneda,    
   TipoCambio,    
   IdFormaPago,    
   IdVendedor,    
    
   TotalCantidad,    
   SubTotal,    
   PorcentajeDescuento,    
   Descuento,    
   TotalDsctoGlobal,    
   OperacionGratuita,    
   PorcentajeImpuesto,    
   Igv,    
   TotalICBPER,    
   Total,    
    
   TotalBruto,    
   Observacion,    
   IdSituacion,    
   IdPromocionProxima,    
   FlagPromocionProxima,    
   CodigoNC,    
   IdUbigeo,    
   IdUbigeoOrigen,    
   FechaTraslado,    
   MotivoTraslado,    
    
   ModalildadTraslado,    
   NumeroBultos,    
   PesoBultos,    
   IdTipoIdentidadTra,    
   NumeroDocTra,    
   RazonSocialTra,    
   NumeroPlaca,    
   IdPersonaRegistro,    
   FlagCumpleanios,  
   TotalDscCumpleanios,  
   FlagEstado,    
   UserCreate,
IdTiendaDestinoGuia,
Marca,
LicenciaConducir      
  )    
  Values    
  (    
   @pIdEmpresa,    
   @pIdTienda,    
   @pIdPedido,    
   @pPeriodo,    
   @pMes,    
   @pIdTipoDocumento,    
   @pSerie,    
   @pNumero,    
   @pIdDocumentoReferencia,    
   Cast(@pFecha as Date),    
    
   Cast(@pFechaVencimiento as Date),    
   @pIdCliente,    
   @pTipoDocId,    
   @pNumeroDocumento,    
   @pDescCliente,    
   @pDireccion,    
   @pIdMoneda,    
   @pTipoCambio,    
   @pIdFormaPago,    
   @pIdVendedor,    
    
   @pTotalCantidad,    
   @pSubTotal,    
   @pPorcentajeDescuento,    
   @pDescuento,    
   @pDescuento,    
   @OperacionGratuita,    
   @pPorcentajeImpuesto,    
   @pIgv,    
   @pIcbper,    
   @pTotal,    
    
   @pTotalBruto,    
   @pObservacion,    
   @pIdSituacion,    
   @pIdPromocionProxima,    
   0,    
   @pCodigoNC,    
   @pIdUbigeo,    
   @pIdUbigeoOrigen,    
   @pFechaTraslado,    
   @pMotivoTraslado,    
    
   @pModalildadTraslado,    
   @pNumeroBultos,    
   @pPesoBultos,    
   @pIdTipoIdentidadTra,    
   @pNumeroDocTra,    
   @pRazonSocialTra,    
   @pNumeroPlaca,    
   @pIdPersonaRegistro,    
   @pFlagCumpleanios,  
   @pTotalDscCumpleanios,  
   --IdUsuario,    
   @pFlagEstado,    
   @pUsuario,

    @pIdTiendaDestinoGuia,
	@pMarca,
	@pLicenciaConducir )    
      
  --Select @pIdDocumentoVenta= Ident_Current('DocumentoVenta')    
  Select @pIdDocumentoVenta= scope_identity()    
      
  --------------------------------------------------------    
  --- Insertamos la venta en la tabla del comercio amigo    
  --------------------------------------------------------    
  Update CuponComercio Set    
    IdDocumentoVenta = @pIdDocumentoVenta,    
    IdFormaPago   = @pIdFormaPago,    
    TipoCambio   =   @pTipoCambio,    
    IdTipoDocumentos  = @pIdTipoDocumento,    
    Total    = @pTotal    
  Where IdComercio = @pIdComercioAmigo    
  --------------------------------------------------------    
      
  --Auditoria    
  Declare @vValor varchar(2000)    
  Set @vValor ='IdDocumentoVenta' + isnull(convert(varchar(10),@pIdDocumentoVenta),'null') + '||' +     
  'IdEmpresa=' + isnull(convert(varchar(10),@pIdEmpresa),'null') + '||' +     
  'IdTienda=' + isnull(convert(varchar(10),@pIdTienda),'null') + '||' +     
  'IdPedido=' + isnull(convert(varchar(10),@pIdPedido),'null') + '||' +     
  'Periodo=' + isnull(convert(varchar(10),@pPeriodo),'null') + '||' +     
  'Mes=' + isnull(convert(varchar(10),@pMes),'null') + '||' +     
  'IdTipoDocumento=' + isnull(convert(varchar(10),@pIdTipoDocumento),'null') + '||' +     
  'Serie=' + isnull(@pSerie,'null') + '||' +     
  'Numero=' + isnull(@pNumero,'null') + '||' +     
  'IdDocumentoReferencia=' + isnull(convert(varchar(10),@pIdDocumentoReferencia),'null') + '||' +     
  'Fecha=' + isnull(convert(varchar(10),@pFecha),'null') + '||' +     
  'FechaVencimiento=' + isnull(convert(varchar(10),@pFechaVencimiento),'null') + '||' +     
  'IdCliente=' + isnull(convert(varchar(10),@pIdCliente),'null') + '||' +     
  'NumeroDocumento=' + isnull(@pNumeroDocumento,'null') + '||' +     
  'DescCliente=' + isnull(@pDescCliente,'null') + '||' +     
  'Direccion=' + isnull(@pDireccion,'null') + '||' +     
  'IdMoneda=' + isnull(convert(varchar(10),@pIdMoneda),'null') + '||' +     
  'TipoCambio=' + isnull(convert(varchar(10),@pTipoCambio),'null') + '||' +     
  'IdFormaPago=' + isnull(convert(varchar(10),@pIdFormaPago),'null') + '||' +     
  'IdVendedor=' + isnull(convert(varchar(10),@pIdVendedor),'null') + '||' +     
  'TotalCantidad=' + isnull(convert(varchar(10),@pTotalCantidad),'null') + '||' +     
  'SubTotal=' + isnull(convert(varchar(10),@pSubTotal),'null') + '||' +     
  'PorcentajeDescuento=' + isnull(convert(varchar(10),@pPorcentajeDescuento),'null') + '||' +     
  'Descuento=' + isnull(convert(varchar(10),@pDescuento),'null') + '||' +     
  'PorcentajeImpuesto=' + isnull(convert(varchar(10),@pPorcentajeImpuesto),'null') + '||' +     
  'Igv=' + isnull(convert(varchar(10),@pIgv),'null') + '||' +     
  'Total=' + isnull(convert(varchar(10),@pTotal),'null') + '||' +     
  'Observacion=' + isnull(@pObservacion,'null') + '||' +     
  'IdSituacion=' + isnull(convert(varchar(10),@pIdSituacion),'null') + '||' +     
  'FlagCumpleanios=' + isnull(convert(varchar(10),@pFlagCumpleanios),'null') + '||' +     
  'TotalDscCumpleanios=' + isnull(convert(varchar(10),@pTotalDscCumpleanios),'null') + '||' +     
  'FlagEstado=' + isnull(convert(char(5),@pFlagEstado),'null')    
      
   update Pedido    
   set IdSituacion = 111    
   where IdPedido = @pIdPedido    
    
  --Insertar en Auditoria    
  Declare @FechaActual datetime    
  Set @FechaActual = getdate()    
  EXEC usp_Auditoria_Inserta @pIdEmpresa,'DocumentoVenta', 'INSERT', @FechaActual, @pMaquina, @pUsuario, @vValor, ''    
    
  Update tPrePedido Set    
    IdSituacion = 111     
  Where  IdPPedido = @IdPedidoEcommerce     
    
End    



---		EXECUTE sp_helptext usp_Talon_SeleccionaCajaDocumento

--	usp_Talon_SeleccionaCajaDocumento 19, 19,  33, 12

CREATE PROCEDURE [dbo].[usp_Talon_SeleccionaCajaDocumento]
(  	@pIdEmpresa int,
	@pIdTienda int,
	@pIdCaja int,
	@pIdTipoDocumento int)
AS
BEGIN
	SET NOCOUNT ON	
	Declare @vTienda int
	Declare @vCaja int

	if @pIdEmpresa=3		  --- CORONA IMPORTADORES E.I.R.L.
		Begin
			if 	@pIdCaja=3
				begin 
						Set   @vTienda=14
						Set	  @vCaja=29
						SELECT
						T.IdEmpresa,
						E.RazonSocial,
						E.Ruc,
						T.IdTalon,		
						@pIdCaja As 'IdCaja',
						C.DescCaja,
						@pIdTienda as 'IdTienda',
						TI.DescTienda,
						T.IdTipoDocumento,
						TD.CodTipoDocumento,
						T.IdTipoFormato,
						TE.DescTablaElemento As DescTipoFormato,
						T.IdTamanoHoja,
						TH.DescTablaElemento AS DescTamanoHoja,
						T.NumeroSerie,
						T.NombreComercial,
						T.NumeroAutoriza,
						T.SerieImpresora,
						ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
						ISNULL(T.PaginaWeb,'') AS PaginaWeb,
						ISNULL(T.Impresora,'') AS Impresora,
						T.FlagAbrirCajon,
						T.FlagEstado
					FROM
						Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
												left JOIN		Caja C					ON C.IdCaja = T.IdCaja
												left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
												left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
												left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
												left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
					WHERE
						T.IdEmpresa = @pIdEmpresa AND
						C.IdTienda	=@vTienda AND
						T.IdCaja	= @vCaja AND
						T.IdTipoDocumento= @pIdTipoDocumento AND
						T.FlagEstado=1	
				end
		End
	Else if @pIdEmpresa=19	  --- TAPIA HUAMAN NELLY BETHSABE
		Begin
			if 	@pIdCaja=33
				begin 
						Set   @vTienda=13
						Set	  @vCaja=26
						SELECT
						T.IdEmpresa,
						E.RazonSocial,
						E.Ruc,
						T.IdTalon,		
						@pIdCaja As 'IdCaja',
						C.DescCaja,
						@pIdTienda as 'IdTienda',
						TI.DescTienda,
						T.IdTipoDocumento,
						TD.CodTipoDocumento,
						T.IdTipoFormato,
						TE.DescTablaElemento As DescTipoFormato,
						T.IdTamanoHoja,
						TH.DescTablaElemento AS DescTamanoHoja,
						T.NumeroSerie,
						T.NombreComercial,
						T.NumeroAutoriza,
						T.SerieImpresora,
						ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
						ISNULL(T.PaginaWeb,'') AS PaginaWeb,
						ISNULL(T.Impresora,'') AS Impresora,
						T.FlagAbrirCajon,
						T.FlagEstado
					FROM
						Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
												left JOIN		Caja C					ON C.IdCaja = T.IdCaja
												left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
												left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
												left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
												left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
					WHERE
						T.IdEmpresa = @pIdEmpresa AND
						C.IdTienda	=@vTienda AND
						T.IdCaja	= @vCaja AND
						T.IdTipoDocumento= @pIdTipoDocumento AND
						T.FlagEstado=1	
				end
		  else 	 if 	@pIdCaja=3
				begin 
						Set   @vTienda=13
						Set	  @vCaja=27
						SELECT
						T.IdEmpresa,
						E.RazonSocial,
						E.Ruc,
						T.IdTalon,		
						@pIdCaja As 'IdCaja',
						C.DescCaja,
						@pIdTienda as 'IdTienda',
						TI.DescTienda,
						T.IdTipoDocumento,
						TD.CodTipoDocumento,
						T.IdTipoFormato,
						TE.DescTablaElemento As DescTipoFormato,
						T.IdTamanoHoja,
						TH.DescTablaElemento AS DescTamanoHoja,
						T.NumeroSerie,
						T.NombreComercial,
						T.NumeroAutoriza,
						T.SerieImpresora,
						ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
						ISNULL(T.PaginaWeb,'') AS PaginaWeb,
						ISNULL(T.Impresora,'') AS Impresora,
						T.FlagAbrirCajon,
						T.FlagEstado
					FROM
						Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
												left JOIN		Caja C					ON C.IdCaja = T.IdCaja
												left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
												left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
												left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
												left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
					WHERE
						T.IdEmpresa = @pIdEmpresa AND
						C.IdTienda	=@vTienda AND
						T.IdCaja	= @vCaja AND
						T.IdTipoDocumento= @pIdTipoDocumento AND
						T.FlagEstado=1	
				end
		  else 	 if 	@pIdCaja=7
				begin 
						Set   @vTienda=13
						Set	  @vCaja=28
						SELECT
						T.IdEmpresa,
						E.RazonSocial,
						E.Ruc,
						T.IdTalon,		
						@pIdCaja As 'IdCaja',
						C.DescCaja,
						@pIdTienda as 'IdTienda',
						TI.DescTienda,
						T.IdTipoDocumento,
						TD.CodTipoDocumento,
						T.IdTipoFormato,
						TE.DescTablaElemento As DescTipoFormato,
						T.IdTamanoHoja,
						TH.DescTablaElemento AS DescTamanoHoja,
						T.NumeroSerie,
						T.NombreComercial,
						T.NumeroAutoriza,
						T.SerieImpresora,
						ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
						ISNULL(T.PaginaWeb,'') AS PaginaWeb,
						ISNULL(T.Impresora,'') AS Impresora,
						T.FlagAbrirCajon,
						T.FlagEstado
					FROM
						Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
												left JOIN		Caja C					ON C.IdCaja = T.IdCaja
												left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
												left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
												left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
												left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
					WHERE
						T.IdEmpresa = @pIdEmpresa AND
						C.IdTienda	=@vTienda AND
						T.IdCaja	= @vCaja AND
						T.IdTipoDocumento= @pIdTipoDocumento AND
						T.FlagEstado=1	
				end
		End
	Else if @pIdEmpresa=21	 --- Liliana Tapia
		Begin
				Set   @vTienda=12
				Set	  @vCaja=25
				SELECT
				T.IdEmpresa,
				E.RazonSocial,
				E.Ruc,
				T.IdTalon,		
				@pIdCaja As 'IdCaja',
				C.DescCaja,
				@pIdTienda as 'IdTienda',
				TI.DescTienda,
				T.IdTipoDocumento,
				TD.CodTipoDocumento,
				T.IdTipoFormato,
				TE.DescTablaElemento As DescTipoFormato,
				T.IdTamanoHoja,
				TH.DescTablaElemento AS DescTamanoHoja,
				T.NumeroSerie,
				T.NombreComercial,
				T.NumeroAutoriza,
				T.SerieImpresora,
				ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
				ISNULL(T.PaginaWeb,'') AS PaginaWeb,
				ISNULL(T.Impresora,'') AS Impresora,
				T.FlagAbrirCajon,
				T.FlagEstado
			FROM
				Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
										left JOIN		Caja C					ON C.IdCaja = T.IdCaja
										left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
										left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
										left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
										left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
			WHERE
				T.IdEmpresa = @pIdEmpresa AND
				C.IdTienda	=@vTienda AND
				T.IdCaja	= @vCaja AND
				T.IdTipoDocumento= @pIdTipoDocumento AND
				T.FlagEstado=1	
		End
	Else 	if @pIdEmpresa=23  --- Eleazar Tapia
		Begin
				Set   @vTienda=16
				Set	  @vCaja=30
				SELECT
				T.IdEmpresa,
				E.RazonSocial,
				E.Ruc,
				T.IdTalon,		
				@pIdCaja As 'IdCaja',
				C.DescCaja,
				@pIdTienda as 'IdTienda',
				TI.DescTienda,
				T.IdTipoDocumento,
				TD.CodTipoDocumento,
				T.IdTipoFormato,
				TE.DescTablaElemento As DescTipoFormato,
				T.IdTamanoHoja,
				TH.DescTablaElemento AS DescTamanoHoja,
				T.NumeroSerie,
				T.NombreComercial,
				T.NumeroAutoriza,
				T.SerieImpresora,
				ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
				ISNULL(T.PaginaWeb,'') AS PaginaWeb,
				ISNULL(T.Impresora,'') AS Impresora,
				T.FlagAbrirCajon,
				T.FlagEstado
			FROM
				Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
										left JOIN		Caja C					ON C.IdCaja = T.IdCaja
										left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
										left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
										left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
										left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
			WHERE
				T.IdEmpresa = @pIdEmpresa AND
				C.IdTienda	=@vTienda AND
				T.IdCaja	= @vCaja AND
				T.IdTipoDocumento= @pIdTipoDocumento AND
				T.FlagEstado=1	
		End
	Else 	if @pIdEmpresa=8  --- Amalia Huaman
		Begin
				Set   @vTienda=17
				Set	  @vCaja=31
				SELECT
				T.IdEmpresa,
				E.RazonSocial,
				E.Ruc,
				T.IdTalon,		
				@pIdCaja As 'IdCaja',
				C.DescCaja,
				@pIdTienda as 'IdTienda',
				TI.DescTienda,
				T.IdTipoDocumento,
				TD.CodTipoDocumento,
				T.IdTipoFormato,
				TE.DescTablaElemento As DescTipoFormato,
				T.IdTamanoHoja,
				TH.DescTablaElemento AS DescTamanoHoja,
				T.NumeroSerie,
				T.NombreComercial,
				T.NumeroAutoriza,
				T.SerieImpresora,
				ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
				ISNULL(T.PaginaWeb,'') AS PaginaWeb,
				ISNULL(T.Impresora,'') AS Impresora,
				T.FlagAbrirCajon,
				T.FlagEstado
			FROM
				Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
										left JOIN		Caja C					ON C.IdCaja = T.IdCaja
										left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
										left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
										left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
										left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
			WHERE
				T.IdEmpresa = @pIdEmpresa AND
				C.IdTienda	=@vTienda AND
				T.IdCaja	= @vCaja AND
				T.IdTipoDocumento= @pIdTipoDocumento AND
				T.FlagEstado=1	
		End
	Else 	if @pIdEmpresa=20  --- TAPIA HUAMAN ROXANA INES
		Begin
				Set   @vTienda=18
				Set	  @vCaja=32
				SELECT
				T.IdEmpresa,
				E.RazonSocial,
				E.Ruc,
				T.IdTalon,		
				@pIdCaja As 'IdCaja',
				C.DescCaja,
				@pIdTienda as 'IdTienda',
				TI.DescTienda,
				T.IdTipoDocumento,
				TD.CodTipoDocumento,
				T.IdTipoFormato,
				TE.DescTablaElemento As DescTipoFormato,
				T.IdTamanoHoja,
				TH.DescTablaElemento AS DescTamanoHoja,
				T.NumeroSerie,
				T.NombreComercial,
				T.NumeroAutoriza,
				T.SerieImpresora,
				ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
				ISNULL(T.PaginaWeb,'') AS PaginaWeb,
				ISNULL(T.Impresora,'') AS Impresora,
				T.FlagAbrirCajon,
				T.FlagEstado
			FROM
				Talon T WITH(NOLOCK)   	left JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
										left JOIN		Caja C					ON C.IdCaja = T.IdCaja
										left JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
										left JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
										left JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
										left JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
			WHERE
				T.IdEmpresa = @pIdEmpresa AND
				C.IdTienda	=@vTienda AND
				T.IdCaja	= @vCaja AND
				T.IdTipoDocumento= @pIdTipoDocumento AND
				T.FlagEstado=1	
		End
	Else
	 Begin 

			SELECT
				T.IdEmpresa,
				E.RazonSocial,
				T.IdTalon,		
				T.IdCaja,
				C.DescCaja,
				C.IdTienda,
				TI.DescTienda,
				T.IdTipoDocumento,
				TD.CodTipoDocumento,
				T.IdTipoFormato,
				TE.DescTablaElemento As DescTipoFormato,
				T.IdTamanoHoja,
				TH.DescTablaElemento AS DescTamanoHoja,
				T.NumeroSerie,
				T.NombreComercial,
				T.NumeroAutoriza,
				T.SerieImpresora,
				ISNULL(T.DireccionFiscal,'') AS DireccionFiscal,
				ISNULL(T.PaginaWeb,'') AS PaginaWeb,
				ISNULL(T.Impresora,'') AS Impresora,
				T.FlagAbrirCajon,
				T.FlagEstado
			FROM
				Talon T WITH(NOLOCK)   	INNER JOIN		Empresa E				ON T.IdEmpresa = E.IdEmpresa
										INNER JOIN		Caja C					ON C.IdCaja = T.IdCaja
										INNER JOIN		Tienda TI				ON C.IdTienda = TI.IdTienda AND T.IdEmpresa = TI.IdEmpresa
										INNER JOIN		TipoDocumento TD		ON T.IdTipoDocumento = TD.IdTipoDocumento
										INNER JOIN		TablaElemento TE		ON T.IdTipoFormato = TE.IdTablaElemento
										INNER JOIN 		TablaElemento TH		ON T.IdTamanoHoja = TH.IdTablaElemento
			WHERE
				T.IdEmpresa = @pIdEmpresa AND
				C.IdTienda	=@pIdTienda  AND
				T.IdCaja	= @pIdCaja  AND
				T.IdTipoDocumento= @pIdTipoDocumento AND
				T.FlagEstado=1	
	  End
	SET NOCOUNT OFF
END

select * from Caja
select * from Tienda
select * from TipoDocumento
exec usp_Talon_SeleccionaCajaDocumento 13,1,21,49;
select * from Talon