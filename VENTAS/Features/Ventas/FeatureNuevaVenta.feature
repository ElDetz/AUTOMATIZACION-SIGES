Feature: NuevaVenta

Registrar una venta

@NuevaVenta
Scenario: Registro de una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	And Rellenar detalles de concepto
	Then Concepto pasa a facturación