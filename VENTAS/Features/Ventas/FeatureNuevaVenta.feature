Feature: NuevaVenta

Registrar una venta

@NuevaVenta
Scenario: Registro de una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Modo Caja"
	And Agregar concepto por 'seleccion' y valor '88008-1'
	And Ingresar cantidad '5'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'BOLETA'
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556'
	Then Guardar venta

