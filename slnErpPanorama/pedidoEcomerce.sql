--SE MODIFICO PROCEDIMIENTO 

ALTER PROCEDURE [dbo].[usp_Pedido_ListaContadoWeb]
(  	@pIdEmpresa int,
	@pIdTienda int,
	@pFecha datetime,
	@pIdSituacion int  )
AS
BEGIN
	SET NOCOUNT ON
	
	IF (@pIdEmpresa = 0) SELECT @pIdEmpresa = Null
	IF (@pIdTienda = 0) SELECT @pIdTienda = Null
	
	SELECT
		P.IdEmpresa,
		P.IdPedido,
		P.IdTienda,
		E.RazonSocial,
		P.Numero,
		P.IdCliente,
		C.IdTipoDocumento AS IdTipoDocumentoCliente,
		C.NumeroDocumento,
		P.DescCliente,
		ISNULL(CA.IdTipoDocumento,0) AS IdTipoDocumentoClienteAsociado,
		ISNULL(CA.NumeroDocumento,0) AS NumeroDocumentoAsociado,
		ISNULL(CA.DescCliente,'') As DescClienteAsociado,
		C.IdTipoCliente,
		TE.Abreviatura AS CodMoneda,
		P.Total,
		FP.DescTablaElemento AS DescFormaPago,
		V.ApeNom AS DescVendedor,
		P.Fecha,
		P.IdTipoDocumento,
		P.Despachar,
		P.FlagImpresionRus,
		P.IdAsesorExterno
	FROM
		Pedido P WITH(NOLOCK)  	LEFT JOIN 		Empresa E ON P.IdEmpresa = E.IdEmpresa
								LEFT JOIN 		Proforma PRF ON P.IdProforma = PRF.IdProforma
								LEFT JOIN	 	TipoDocumento TD ON P.IdTipoDocumento = TD.IdTipoDocumento
								LEFT JOIN		TablaElemento TE ON P.IdMoneda = TE.IdTablaElemento
								LEFT JOIN		TablaElemento FP ON P.IdFormaPago = FP.IdTablaElemento
								LEFT JOIN	   	(SELECT IdPersona, IdEmpresa, IdTienda, ApeNom 		FROM Persona WITH(NOLOCK)  		--WHERE
		--	IdCargo IN(35,37,44,120,15,225,243)AND --GESTOR DE CARTERA, ASESOR DE VENTAS SENIOR, ASESOR DE VENTAS JUNIOR, CAJERA)
		--	FlagEstado = 1 
			) V ON P.IdVendedor = V.IdPersona  	LEFT JOIN		TablaElemento S ON P.IdSituacion = S.IdTablaElemento
												INNER JOIN		Cliente C WITH(NOLOCK) ON P.IdCliente = C.IdCliente
												LEFT JOIN 		ClienteAsociado CA ON P.IdClienteAsociado = CA.IdClienteAsociado
												LEFT JOIN	tPrePedido PW On	P.IdPedido=PW.IdPedidoPanorama			
	WHERE
		P.IdEmpresa = Coalesce(@pIdEmpresa,P.IdEmpresa) AND
		P.IdTienda = Coalesce(@pIdTienda,P.IdTienda) AND
		P.IdFormaPago IN (68, 61)AND
		--P.IdFormaPago = 61 AND
		P.IdSituacion = 110 AND
	    --P.FlagImpresion IN (0, 1)AND
		P.FlagEstado=1 	  AND
	 	P.Ecommerce =1 
		AND PW.FlagPago=1

	ORDER BY 
		P.Numero

	SET NOCOUNT OFF
END



--select * from Pedido
--where Numero = '0120307'

--update pedido set IdSituacion = 110
--where Numero = '0120307'

--DECLARE @FechaHoy datetime = GETDATE()
--exec usp_Pedido_ListaContadoWeb 13, 1, @FechaHoy,110


--select * from pedido where numero = '0120340'
--select * from MovimientoPedido where IdPedido = 1251932

----


--SE CREA un nuevo procedimiento para movimientopedido

CREATE PROCEDURE [dbo].usp_MovimientoPedido_ActualizaSituacionWEB
(
	@pIdPedido int,
	@pIdSituacionAlmacen int,
	@pObservacion varchar(50),
	@pIdPersona int,
	@pConductor varchar(50),
	@pIdPersonaCredito int,
	@pUsuario varchar(30),
	@pMaquina varchar(30),
	@pFlagEstado bit
)
As

Begin
		Set Nocount On
		
		If Exists(SELECT IdPedido FROM MovimientoPedido WITH(NOLOCK) WHERE IdPedido = @pIdPedido)	
		BEGIN
			
--Pedido Aprobado	-- tb pedido
			Update MovimientoPedido Set 
				Aprobado = 1,
				FechaAprobado = GETDATE(),
				IdPersonaCredito = @pIdPersonaCredito -- Credito
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 --AND Aprobado IS NULL


--recibido
			Update MovimientoPedido Set
				Recibido = 1,
				FechaRecibido = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 AND Recibido IS NULL
--preparacion			
			Update MovimientoPedido Set
				Preparacion = 1,
				FechaPreparacion = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 AND Preparacion IS NULL

--chequeo
			Update MovimientoPedido Set
				Chequeo = 1,
				FechaChequeo = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 AND Chequeo IS NULL


-- En PT Manual
			Update MovimientoPedido Set
				EnPT = 1,
				FechaPT = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 AND  EnPT IS NULL

--Recepción de Doc.
			Update MovimientoPedido Set
				RecepcionDocumento = 1,
				FechaRD = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 AND RecepcionDocumento IS NULL
				

--despachado de almacen por mov
			Update MovimientoPedido Set 
				Despachado = 1,
				FechaDespachado = GETDATE()
			where  
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 AND Despachado IS NULL

				
			Update MovimientoPedido Set
				--FechaAnulado =GETDATE() ,
				Observacion = (CASE WHEN @pObservacion=''THEN Observacion ELSE @pObservacion END),
				IdPersona= (CASE WHEN @pIdPersona=''THEN IdPersona ELSE @pIdPersona END),
				Conductor= (CASE WHEN @pConductor=''THEN Conductor ELSE @pConductor END),
				Usuario= @pUsuario,
				Maquina= @pMaquina,
				FlagEstado = @pFlagEstado			
			where 
				IdPedido = @pIdPedido 		
		END
		ELSE
		BEGIN
			Insert into MovimientoPedido (IdPedido,FlagEstado)Values(@pIdPedido,1) --Agrega si no existe
			
			Update MovimientoPedido Set --pED
				Aprobado = 1,
				FechaAprobado = GETDATE(),
				IdPersonaCredito = @pIdPersonaCredito -- Credito
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110

			Update MovimientoPedido Set
				Recibido = 1,
				FechaRecibido = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110 			
			
			Update MovimientoPedido Set
				Preparacion = 1,
				FechaPreparacion = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110
				
			Update MovimientoPedido Set
				Chequeo = 1,
				FechaChequeo = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110
				
			Update MovimientoPedido Set
				EnPT = 1,
				FechaPT = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110				

			Update MovimientoPedido Set
				RecepcionDocumento = 1,
				FechaRD = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110
				
			Update MovimientoPedido Set
				Despachado = 1,
				FechaDespachado = GETDATE()
			where 
				IdPedido = @pIdPedido AND @pIdSituacionAlmacen = 110

			Update MovimientoPedido Set
				--FechaAnulado = GETDATE(),
				Observacion = @pObservacion,
				IdPersona= @pIdPersona,
				Conductor= @pConductor,
				Chequeado = 1,
				FechaChequeado = GETDATE(),
				Usuario= @pUsuario,
				Maquina= @pMaquina,
				FlagEstado = @pFlagEstado			
			where 
				IdPedido = @pIdPedido 		
			
		END
		Set Nocount Off
End





-- Se modificó procedimiento agregando EL new procedimiento usp_MovimientoPedido_ActualizaSituacionWEB.
																	   
  ALTER PROCEDURE [dbo].[usp_PedidoWEB_Inserta]
(
	@pIdPedido int OUT,
	@pIdEmpresa int,
	@pIdTienda int,
	@pIdCampana int,
	@pPeriodo int,
	@pMes tinyint,
	@pIdProforma int,
	@pIdTipoDocumento int,
	@pSerie char(3),
	@pNumero char(7),
	@pIdPedidoReferencia int,
	@pFecha date,
	@pFechaVencimiento date,
	@pFechaCancelacion date,
	@pIdCliente int,
	@pNumeroDocumento varchar(15),
	@pDescCliente varchar(150),
	@pDireccion varchar(200),
	@pIdClienteAsociado int,--ad		
	@pIdMoneda int,
	@pTipoCambio numeric(5,2),
	@pIdFormaPago int,
	@pIdVendedor int,
	@pTotalCantidad int,
	@pSubTotal numeric(10,2),
	@pPorcentajeDescuento numeric(5,2),
	@pDescuento numeric(10,2),
	@pPorcentajeImpuesto numeric(10,2),
	@pIgv numeric(10,2),
	@pTotal numeric(10,2),
	@pTotalBruto numeric(10,2),
	@pObservacion varchar(200),
	@pIdCombo int,
	@pDespachar varchar(20),
	@pIdSituacion int,
	@pIdTipoVenta int,
	@pIdMotivo int,
	@pIdAsesor int,
	@pIdAsesorExterno int,
	@pFlagPreventa bit,
	@pFlagImpresionRus bit,
	@pIdContratoFabricacion int,
	@pIdProyectoServicio int,
	@pIdNovioRegalo int,
	@pFlagEstado bit,
	@pUsuario varchar(15),
	@pMaquina varchar(20),
	@pIdPedidoWeb int)
AS
Begin
		Set Nocount On
		Insert Into Pedido
		(	IdEmpresa,
			IdTienda,
			IdCampana,
			Periodo,
			Mes,
			IdProforma,
			IdTipoDocumento,
			Serie,
			Numero,
			IdPedidoReferencia,
			Fecha,
			FechaVencimiento,
			FechaCancelacion,
			IdCliente,
			NumeroDocumento,
			DescCliente,
			Direccion,
			IdClienteAsociado,
			IdMoneda,
			TipoCambio,
			IdFormaPago,
			IdVendedor,
			TotalCantidad,
			SubTotal,
			PorcentajeDescuento,
			Descuento,
			PorcentajeImpuesto,
			Igv,
			Total,
			TotalBruto,
			Observacion,
			IdCombo,
			Despachar,
			IdSituacion,
			IdSituacionAlmacen,
			IdTipoVenta,
			IdMotivo,
			IdAsesor,
			IdAsesorExterno,
			FlagPreVenta,
			FlagImpresionRus,
			IdContratoFabricacion,
			IdProyectoServicio,
			IdNovioRegalo,
			FlagAuditado,
			FlagEstado,
			Ecommerce,
			IdPedidoWeb,
			add_user
		)
		Values
		(
			@pIdEmpresa,
			@pIdTienda,
			@pIdCampana,
			@pPeriodo,
			@pMes,
			@pIdProforma,
			@pIdTipoDocumento,
			@pSerie,
			@pNumero,
			@pIdPedidoReferencia,
			CAST(@pFecha AS DATE),
			CAST(@pFechaVencimiento AS DATE),
			@pFechaCancelacion,
			@pIdCliente,
			@pNumeroDocumento,
			@pDescCliente,
			@pDireccion,
			@pIdClienteAsociado,
			@pIdMoneda,
			@pTipoCambio,
			@pIdFormaPago,
			@pIdVendedor,
			@pTotalCantidad,
			@pSubTotal,
			@pPorcentajeDescuento,
			@pDescuento,
			@pPorcentajeImpuesto,
			@pIgv,
			@pTotal,
			@pTotalBruto,
			@pObservacion,
			@pIdCombo,
			@pDespachar,
			110, --GENERADO
			153, --Situacion Almacen
			@pIdTipoVenta,
			@pIdMotivo,
			@pIdAsesor,
			@pIdAsesorExterno,
			@pFlagPreventa,
			@pFlagImpresionRus,
			@pIdContratoFabricacion,
			@pIdProyectoServicio,
			@pIdNovioRegalo,
			0,
			@pFlagEstado,
			1,
			@pIdPedidoWeb,
			@pUsuario
		)
		
		Select @pIdPedido= Ident_Current('Pedido')
		
		--Auditoria
		Declare @vValor varchar(2000)
		Set @vValor ='IdPedido' + isnull(convert(varchar(10),@pIdPedido),'null') + '||' + 
		'IdEmpresa=' + isnull(convert(varchar(10),@pIdEmpresa),'null') + '||' + 
		'IdTienda=' + isnull(convert(varchar(10),@pIdTienda),'null') + '||' + 
		'IdCampana=' + isnull(convert(varchar(10),@pIdCampana),'null') + '||' + 
		'Periodo=' + isnull(convert(varchar(10),@pPeriodo),'null') + '||' + 
		'Mes=' + isnull(convert(varchar(10),@pMes),'null') + '||' + 
		'IdTipoDocumento=' + isnull(convert(varchar(10),@pIdTipoDocumento),'null') + '||' + 
		'Serie=' + isnull(@pSerie,'null') + '||' + 
		'Numero=' + isnull(@pNumero,'null') + '||' + 
		'Fecha=' + isnull(convert(varchar(10),@pFecha),'null') + '||' + 
		'FechaVencimiento=' + isnull(convert(varchar(10),@pFechaVencimiento),'null') + '||' + 
		'FechaCancelacion=' + isnull(convert(varchar(10),@pFechaCancelacion),'null') + '||' + 
		'IdCliente=' + isnull(convert(varchar(10),@pIdCliente),'null') + '||' + 
		'NumeroDocumento=' + isnull(@pNumeroDocumento,'null') + '||' + 
		'DescCliente=' + isnull(@pDescCliente,'null') + '||' + 
		'Direccion=' + isnull(@pDireccion,'null') + '||' + 
		'IdMoneda=' + isnull(convert(varchar(10),@pIdMoneda),'null') + '||' + 
		'TipoCambio=' + isnull(convert(varchar(10),@pTipoCambio),'null') + '||' + 
		'IdFormaPago=' + isnull(convert(varchar(10),@pIdFormaPago),'null') + '||' + 
		'IPendedor=' + isnull(convert(varchar(10),@pIdVendedor),'null') + '||' + 
		'TotalCantidad=' + isnull(convert(varchar(10),@pTotalCantidad),'null') + '||' + 
		'SubTotal=' + isnull(convert(varchar(10),@pSubTotal),'null') + '||' + 
		'PorcentajeDescuento=' + isnull(convert(varchar(10),@pPorcentajeDescuento),'null') + '||' + 
		'Descuento=' + isnull(convert(varchar(10),@pDescuento),'null') + '||' + 
		'PorcentajeImpuesto=' + isnull(convert(varchar(10),@pPorcentajeImpuesto),'null') + '||' + 
		'Igv=' + isnull(convert(varchar(10),@pIgv),'null') + '||' + 
		'Total=' + isnull(convert(varchar(10),@pTotal),'null') + '||' + 
		'Observacion=' + isnull(@pObservacion,'null') + '||' + 
		'IdCombo=' + isnull(convert(varchar(10),@pIdCombo),'null') + '||' + 
		'Despachar=' + isnull(@pDespachar,'null') + '||' + 
		'IdSituacion=' + isnull(convert(varchar(10),@pIdSituacion),'null') + '||' + 
		'FlagEstado=' + isnull(convert(char(5),@pFlagEstado),'null')
		
		--Insertar en Auditoria
		Declare @FechaActual datetime
		Set @FechaActual = getdate()
		EXEC usp_Auditoria_Inserta @pIdEmpresa,'Pedido', 'INSERT', @FechaActual, @pMaquina, @pUsuario, @vValor, ''
		
		--Insertar en ADS
		--EXEC usp_Pedido_Inserta_ADS @pIdPedido
		
		--Insertar en Movimiento Pedido (SE EDITO usp_MovimientoPedido_ActualizaSituacionWEB)
		EXEC usp_MovimientoPedido_ActualizaSituacionWEB @pIdPedido, 110,'',0,'','','','',1
		--Insert into MovimientoPedido (IdPedido,FlagEstado)Values(@pIdPedido,1) --Agrega si no existe (Cód x Agregar)

		Update 	tPrePedido Set 	
							 IdPedidoPanorama=@pIdPedido
							,Numero	=@pNumero
							, FecPedPanorama= @pFecha
							,FlagProcesado=1
							,IdSituacion=110
		where IdPPedido=@pIdPedidoWeb
		
End


select * from DocumentoVenta


--Se creo un procedimiento almacenado

create PROCEDURE usp_IdDocumentoVenta
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdDocumentoVenta,IdVendedor
    FROM DocumentoVenta
    WHERE IdPedido = @IdPedido;
END;


exec usp_IdDocumentoVenta 1252941

select * from MovimientoCaja
where IdDocumentoVenta = 1933354

--exec usp_EstadoCuentaCliente_Inserta 

--EstadoCuentaClienteDL

--revisar en DocumentoVentaBL.cs linea 888 Inserta