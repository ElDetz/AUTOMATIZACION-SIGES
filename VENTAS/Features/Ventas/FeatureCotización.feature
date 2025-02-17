Feature: FeatureCotización

Realizar pedidos

@RealizarCotización

Scenario: Realizar una nueva cotización
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Click en nueva cotización
	And Agregar concepto para cotización "400000891"
	And Agregar tipo de cliente para cotización 'DNI' '72380461'
	And Ingresar la fecha de vencimiento '10/03/2025'
	Then Guardar pedido o cotización

@PregenerarPedido

Scenario: Pregenerar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "17/02/2025"
	And Click en consultar pedidos
	And Buscar venta '0002 - 25614'
	And Click en pregenerar pedido
	Then Guardar pedido pregenerado

@PregenerarVenta
Scenario: Pregenerar venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "12/02/2025"
	And Click en consultar pedidos
	And Buscar venta '0002 - 25613'
	And Click en pregenerar venta
	Then Guardar venta pregenerada