Feature: NuevaVenta

Registrar una venta
And Selecionar tipo de pago 'Rapido'

@NuevaVenta
Scenario: Registro de una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto Agregar concepto por codigo de barra '1010-3'
	And Agregar concepto por seleccion '88008'
	And Ingresar cantidad '5'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'REGISTRADO' '72380461'
	And Seleccionar tipo de comprobante 'BOLETA'
	And Seleccionar medio de pago 'TRANFON'
	And Elige su banco 'BBVA  CONTINENTAL' y 'MASTER CARD' y '20005-205'
	Then Guardar venta

