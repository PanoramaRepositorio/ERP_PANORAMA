ALTER PROCEDURE [dbo].[usp_rptListaTarjetaCaja]
(
	@pIdTienda int,
	@pIdCaja int,
	@pFechaDesde datetime,
	@pFechaHasta datetime
)
AS
BEGIN

	SET NOCOUNT ON
	
	IF(@pIdTienda=0)SELECT @pIdTienda = NULL
	IF(@pIdCaja=0)SELECT @pIdCaja = NULL

	SELECT
		TDA.DescTienda,
		C.DescCaja,
		MC.Fecha,
		MC.IdCondicionPago,
		CP.DescTablaElemento AS DescCondicionPago,
		MC.TipoTarjeta,
		SUM(ISNULL(MC.ImporteSoles,0)) AS ImporteSoles,
		CONVERT(numeric(10,2),0) Comision,
		CONVERT(numeric(10,2),0) ComBanco,
		CONVERT(numeric(10,2),0) IGV,
		CONVERT(numeric(10,2),0) PorCobrar
	INTO #TmpMovimientoCaja
	FROM 
		MovimientoCaja MC WITH(NOLOCK)
	INNER JOIN 
		Caja C WITH(NOLOCK)ON MC.IdCaja = C.IdCaja
	INNER JOIN 
		Tienda TDA WITH(NOLOCK)ON C.IdTienda = TDA.IdTienda
	INNER JOIN
		TipoDocumento TD WITH(NOLOCK)ON MC.IdTipoDocumento = TD.IdTipoDocumento
	INNER JOIN
		TablaElemento FP WITH(NOLOCK)ON MC.IdFormaPago = FP.IdTablaElemento
	INNER JOIN
		TablaElemento CP WITH(NOLOCK)ON MC.IdCondicionPago = CP.IdTablaElemento
	INNER JOIN
		TablaElemento M WITH(NOLOCK)ON MC.IdMoneda = M.IdTablaElemento
	WHERE 
		MC.Fecha BETWEEN CONVERT(VARCHAR,@pFechaDesde,112)  AND CONVERT(VARCHAR,@pFechaHasta,112) AND
		TDA.IdTienda = COALESCE(@pIdTienda, TDA.IdTienda) AND
		MC.IdCaja = COALESCE(@pIdCaja, MC.IdCaja) AND
		MC.IdCondicionPago NOT IN(98,194) AND
		MC.FlagEstado = 1
	GROUP BY 
		TDA.DescTienda,
		MC.IdCondicionPago,
		CP.DescTablaElemento,
		MC.TipoTarjeta,
		C.DescCaja,
		MC.Fecha

	--VISA
	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0299 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'D' 
	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0399 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'C'

	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0325 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'D' AND Fecha <'01/10/2017' --261017
	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0415 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'C' AND Fecha <'01/10/2017'

	UPDATE #TmpMovimientoCaja SET ComBanco = Comision *0.2 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'D'
	UPDATE #TmpMovimientoCaja SET ComBanco = Comision *0.2 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'C'

	UPDATE #TmpMovimientoCaja SET IGV = ComBanco *0.18 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'D'
	UPDATE #TmpMovimientoCaja SET IGV = ComBanco *0.18 WHERE IdCondicionPago = 99 AND TipoTarjeta = 'C'

	UPDATE #TmpMovimientoCaja SET PorCobrar = ImporteSoles - Comision - IGV WHERE IdCondicionPago = 99 
	UPDATE #TmpMovimientoCaja SET PorCobrar = ImporteSoles - Comision - IGV WHERE IdCondicionPago = 192 

	

	--master
	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.06 WHERE IdCondicionPago = 100
	UPDATE #TmpMovimientoCaja SET ComBanco = Comision *0.2 WHERE IdCondicionPago = 100
	UPDATE #TmpMovimientoCaja SET IGV = ComBanco *0.18 WHERE IdCondicionPago = 100
	UPDATE #TmpMovimientoCaja SET PorCobrar = ImporteSoles - Comision - IGV WHERE IdCondicionPago = 100 
	

	--American Express
	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.05 WHERE IdCondicionPago = 101
	UPDATE #TmpMovimientoCaja SET ComBanco = Comision *0.25 WHERE IdCondicionPago = 101
	UPDATE #TmpMovimientoCaja SET IGV = ComBanco *0.18 WHERE IdCondicionPago = 101
	UPDATE #TmpMovimientoCaja SET PorCobrar = ImporteSoles - Comision - IGV WHERE IdCondicionPago = 101 

	--Dinners
	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.05 WHERE IdCondicionPago = 22
	--UPDATE #TmpMovimientoCaja SET ComBanco = Comision *0.25 WHERE IdCondicionPago = 22
	--UPDATE #TmpMovimientoCaja SET IGV = ComBanco *0.18 WHERE IdCondicionPago = 22
	UPDATE #TmpMovimientoCaja SET IGV = Comision *0.18 WHERE IdCondicionPago = 22
	UPDATE #TmpMovimientoCaja SET PorCobrar = ImporteSoles - Comision - IGV WHERE IdCondicionPago = 22 

	--BBVA PROMOCION
	UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.05 WHERE IdCondicionPago = 716
	UPDATE #TmpMovimientoCaja SET ComBanco = Comision *0.05 WHERE IdCondicionPago = 716
	UPDATE #TmpMovimientoCaja SET IGV = ComBanco *0.18 WHERE IdCondicionPago = 716
	UPDATE #TmpMovimientoCaja SET PorCobrar = ImporteSoles - Comision - IGV WHERE IdCondicionPago = 716

	SELECT * FROM #TmpMovimientoCaja
	ORDER BY 
		DescTienda,
		Fecha,
		DescCaja,
		DescCondicionPago
		

	SET NOCOUNT OFF
END











alter PROCEDURE [dbo].[usp_rptListaTarjetaCaja_IziPay]          
(          
 @pIdTienda int,          
 @pIdCaja int,          
 @pFechaDesde datetime,          
 @pFechaHasta datetime        
 --@pTipoReporte int        
)          
AS          
BEGIN          
          
 SET NOCOUNT ON          
           
 IF(@pIdTienda=0)SELECT @pIdTienda = NULL          
 IF(@pIdCaja=0)SELECT @pIdCaja = NULL          
          
 SELECT          
  TDA.DescTienda,          
  MC.IdCaja,        
  C.DescCaja,          
  MC.Fecha,          
  MC.IdCondicionPago,          
  CP.DescTablaElemento AS DescCondicionPago,          
  MC.TipoTarjeta,          
  SUM(ISNULL(MC.ImporteSoles,0)) AS ImporteSoles,          
  CONVERT(numeric(10,2),0) Comision,          
  CONVERT(numeric(10,2),0) IGV,          
  CONVERT(numeric(10,2),0) PorCobrar          
 INTO #TmpMovimientoCaja          
 FROM           
 MovimientoCaja MC WITH(NOLOCK)          
 INNER JOIN           
  Caja C WITH(NOLOCK)ON MC.IdCaja = C.IdCaja          
 INNER JOIN           
  Tienda TDA WITH(NOLOCK)ON C.IdTienda = TDA.IdTienda          
 INNER JOIN          
  TipoDocumento TD WITH(NOLOCK)ON MC.IdTipoDocumento = TD.IdTipoDocumento          
 INNER JOIN          
  TablaElemento FP WITH(NOLOCK)ON MC.IdFormaPago = FP.IdTablaElemento          
 INNER JOIN          
  TablaElemento CP WITH(NOLOCK)ON MC.IdCondicionPago = CP.IdTablaElemento          
 INNER JOIN          
  TablaElemento M WITH(NOLOCK)ON MC.IdMoneda = M.IdTablaElemento          
 WHERE           
  MC.Fecha BETWEEN CONVERT(VARCHAR,@pFechaDesde,112)  AND CONVERT(VARCHAR,@pFechaHasta,112) AND          
  TDA.IdTienda = COALESCE(@pIdTienda, TDA.IdTienda) AND          
  MC.IdCaja = COALESCE(@pIdCaja, MC.IdCaja) AND          
  MC.IdCondicionPago NOT IN(98,194) AND          
  MC.FlagEstado = 1          
 GROUP BY        
  TDA.DescTienda,          
  MC.IdCondicionPago,          
  CP.DescTablaElemento,          
  MC.TipoTarjeta,          
  MC.IdCaja,        
  C.DescCaja,          
  MC.Fecha          
        
 --DELETE FROM #TmpMovimientoCaja WHERE IdCaja = 21 --ECOM    //comentamos esta linea   
        
 --TIPO DE TARJETAS          
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0215 WHERE IdCondicionPago = 99  AND TipoTarjeta = 'D'  --Visa        
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0215 WHERE IdCondicionPago = 100 AND TipoTarjeta = 'D'  --Mastercard        
        
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0275 WHERE IdCondicionPago = 99  AND TipoTarjeta = 'C'  --Visa        
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0275 WHERE IdCondicionPago = 100 AND TipoTarjeta = 'C'  --Mastercard        
      
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0395 WHERE IdCondicionPago = 101 --American Express  2.75      
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0395 WHERE IdCondicionPago = 22  --Dinners       2.75   
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0395 WHERE IdCondicionPago = 420  --Foraneas        
      
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0275 WHERE IdCondicionPago = 192  --Visa vida           //Ecm 20221907      
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0275 WHERE IdCondicionPago = 193  --Mastercard vida     //Ecm 20221907  
     
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0395 WHERE IdCondicionPago = 573  --Tarjetas Foraneas   //Ecm 20221907      
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0500 WHERE IdCondicionPago = 572  --Dinerclub PROMOCI�N //Ecm 20221907      
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0500 WHERE IdCondicionPago = 716 --BBVA PROMOCION --- SE AGREGO SOLO ESTA LINEA 
     
 --------
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0210 WHERE IdCondicionPago = 99  AND TipoTarjeta = 'D' and Month(Fecha)>3 and  year(Fecha)=2023  --Visa        
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0210 WHERE IdCondicionPago = 100 AND TipoTarjeta = 'D' and Month(Fecha)>3 and  year(Fecha)=2023 --Mastercard        
        
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0210 WHERE IdCondicionPago = 99  AND TipoTarjeta = 'C' and Month(Fecha)>3 and  year(Fecha)=2023 --Visa        
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0210 WHERE IdCondicionPago = 100 AND TipoTarjeta = 'C' and Month(Fecha)>3 and  year(Fecha)=2023 --Mastercard   

 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0275 WHERE IdCondicionPago = 101 and Month(Fecha)>3 and  year(Fecha)=2023 --American Express  2.75      
 UPDATE #TmpMovimientoCaja SET Comision = ImporteSoles *0.0275 WHERE IdCondicionPago = 22  and Month(Fecha)>3 and  year(Fecha)=2023 --Dinners       2.75  
 --------


 UPDATE #TmpMovimientoCaja SET IGV = Comision * 0.18        
 UPDATE #TmpMovimientoCaja SET PorCobrar = ImporteSoles - Comision - IGV     
 
 --//Ecm 20221907  
 UPDATE #TmpMovimientoCaja SET   
 ImporteSoles = ImporteSoles * (-1),  
 PorCobrar    = PorCobrar* (-1),  
 Comision     = Comision * (-1),  
 IGV          = IGV      * (-1)    
 where IdCaja = 11 -- CAJA GERENCIA    
        
 SELECT         
  DescTienda,          
  DescCaja,          
  Fecha,          
  IdCondicionPago,          
  DescCondicionPago,          
  TipoTarjeta,          
  ImporteSoles,          
  Comision,          
  IGV,          
  PorCobrar         
 FROM #TmpMovimientoCaja          
 ORDER BY           
  DescTienda,          
  Fecha,          
  DescCaja,          
  DescCondicionPago,        
  TipoTarjeta        
          
 SET NOCOUNT OFF          
END 

---Recibo pagos (punto 7)

alter PROCEDURE [dbo].[usp_Pagos_ListaTodosActivo]
(
	@pIdEmpresa int,
	@pIdCaja int,
	@pFecha datetime,
	@pFechaHasta datetime,
	@pIdTipoDocumento int
)
AS
BEGIN

	SET NOCOUNT ON
	
	IF(@pIdCaja = 0)SELECT @pIdCaja = NULL

	SELECT 
		PG.IdEmpresa,
		PG.IdPago,
		PG.IdPedido,
		P.Numero AS NumeroPedido,
		CL.DescCliente,
		MP.Abreviatura AS CodMonedaPedido,
		ISNULL(P.Total,0) AS Total,
		TDA.DescTienda,
		PG.IdCaja,
		C.DescCaja,
		PG.Fecha,
		PG.IdTipoDocumento,
		TD.CodTipoDocumento,
		PG.NumeroDocumento,
		PG.IdCondicionPago,
		CP.DescTablaElemento AS DescCondicionPago,
		PG.Concepto,
		PG.IdMoneda,
		M.Abreviatura AS CodMoneda,
		PG.TipoCambio,
		PG.ImporteSoles,
		PG.ImporteDolares,
		PG.TipoMovimiento,
		PG.IdVendedor,
		ISNULL(PER.ApeNom,'') AS DescVendedor,
		PG.IdDis_ProyectoServicio,
		ISNULL(DPS.Numero,'') AS NumeroProyectoServicio,
		PG.IdDis_ContratoFabricacion,
		ISNULL(DCF.Numero,'') AS NumeroContrato,
		PG.IdCliente,
		ISNULL(TCL.DescTablaElemento,'') AS TipoCliente,
		PG.FlagEstado,
		ISNULL(CodigoGiftCard, '') AS CodigoGiftCard
	FROM 
		Pagos PG
	LEFT JOIN
		Pedido P ON PG.IdPedido = P.IdPedido	
	LEFT JOIN
		TablaElemento MP ON P.IdMoneda = MP.IdTablaElemento
	LEFT JOIN
		Caja C ON PG.IdCaja = C.IdCaja
	LEFT JOIN 
		Tienda TDA ON C.IdTienda = TDA.IdTienda
	LEFT JOIN
		TipoDocumento TD ON PG.IdTipoDocumento = TD.IdTipoDocumento
	LEFT JOIN
		TablaElemento CP ON PG.IdCondicionPago = CP.IdTablaElemento
	LEFT JOIN
		TablaElemento M ON PG.IdMoneda = M.IdTablaElemento
	LEFT JOIN 
		Persona PER ON PG.IdVendedor = PER.IdPersona 
	LEFT JOIN 
		Cliente CL ON PG.IdCliente = CL.IdCliente 
	LEFT JOIN
		TablaElemento TCL ON CL.IdTipoCliente = TCL.IdTablaElemento
	LEFT JOIN 
		Dis_ProyectoServicio DPS ON PG.IdDis_ProyectoServicio = DPS.IdDis_ProyectoServicio
	LEFT JOIN
		Dis_ContratoFabricacion DCF ON PG.IdDis_ContratoFabricacion = DCF.IdDis_ContratoFabricacion
	WHERE 
		PG.IdEmpresa = @pIdEmpresa AND
		PG.IdCaja = Coalesce(@pIdCaja,PG.IdCaja) AND
		PG.Fecha BETWEEN convert(varchar,@pFecha,112) AND convert(varchar,@pFechaHasta,112) AND
		PG.IdTipoDocumento = @pIdTipoDocumento 
		--AND PG.FlagEstado = 1 

	SET NOCOUNT OFF
END
