Feature: NuevaVenta

Registrar una venta
And Ingresar fecha de emisión de la venta '30/01/2025'

@NuevaVenta
Scenario: Registro de una venta con pago al contado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA'
	And Seleccionar tipo de pago "Credito configurado"
	And Ingresar monto inicial '20'
	And Ingresar el número de coutas '3'
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556'
	Then Guardar venta

Scenario: Registro de una venta con crédito rápido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA'
	And Seleccionar tipo de pago "credito rapido"
	And Ingresar monto inicial '20'
	Then Guardar venta
