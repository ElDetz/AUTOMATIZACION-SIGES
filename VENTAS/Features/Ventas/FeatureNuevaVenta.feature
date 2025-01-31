Feature: NuevaVenta

Registrar una venta
And Click en Cliente registrado '72380461'
And Agregar concepto por seleccion '88008'
And Selecionar tipo de pago 'Rapido'
And Seleccionar credito rapido
And Agregar concepto Agregar concepto por codigo de barra '1010-3'

@NuevaVenta
Scenario: Registro de una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'seleccion' y valor '88008-1'
	And Ingresar cantidad '5'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'BOLETA'
	And Seleccionar el medio de pago 'PTS'
	And Rellene datos de la tarjeta '' , '' y ''
	Then Guardar venta

