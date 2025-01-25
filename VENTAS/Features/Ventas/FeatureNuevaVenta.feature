Feature: NuevaVenta

Registrar una venta

@NuevaVenta
Scenario: Registro de una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Click en venta luego nueva venta
	And Agregar concepto por codigo de barra '1010-3'
	And Seleccionar familia 'ABRA', concepto '400001352' y cantidad '5' 
	And Ingresar dni '72380461' y activar IGV
	And Tipo documento 'FACTURA'
	And Medio de pago 'BBVA  CONTINENTAL' y 'MASTER CARD' y '20005-205'
	Then Guardar venta

