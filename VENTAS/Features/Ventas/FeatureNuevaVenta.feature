Feature: NuevaVenta

Registrar una venta

@NuevaVenta
Scenario: Registro de una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por codigo de barra '1010-3'
	And Seleccionar familia 'ABRA', concepto '400001352' y cantidad '5' 
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Ingresar documento 'DNI' valor '72380461'
	And Tipo comprobante 'FACTURA'
	And Tipo de Pago 'CO'
	And Medio de pago 'BBVA  CONTINENTAL' y 'MASTER CARD' y '20005-205'
	Then Guardar venta

