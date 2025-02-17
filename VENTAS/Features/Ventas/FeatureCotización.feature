Feature: FeatureCotización

Realizar pedidos

@RealizarCotización

Scenario: Realizar una nueva cotización
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Click en nueva cotización
	And Agregar concepto "400000891"
	And Agregar tipo de cliente 'DNI' '72380461'
	And Ingresar la fecha de vencimiento ' '
	Then Guardar cotización

@PregenerarPedido

Scenario: Pregenerar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "12/02/2025"
	And Click en consultar cotizaciones
	And Buscar cotización '0002 - 25612'
	And Click en pregenerar pedido
	Then Guardar pedido cotizado

@PregenerarVenta
Scenario: Pregenerar cotización
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "12/02/2025"
	And Click en consultar cotizaciones
	And Buscar cotización '0002 - 25612'
	And Click en pregenerar venta
	Then Guardar venta cotizada