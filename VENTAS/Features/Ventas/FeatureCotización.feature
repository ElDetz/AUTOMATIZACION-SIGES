Feature: FeatureCotización

Realizar pedidos

@RealizarCotización

Scenario: Realizar una nueva cotización
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Click en nueva cotización
	And Seleccionar concepto "1010-3 | 1010-3 PISO PVC 18CM X 122CM X 4MM"
	And Ingresar la cantidad de concepto '2'
	And Con IGV 'SI'
	And Seleccionar el cliente 'DNI' '72380461'
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