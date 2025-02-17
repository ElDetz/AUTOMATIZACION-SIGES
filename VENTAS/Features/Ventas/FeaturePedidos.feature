Feature: FeaturePedidos

Realizar pedidos
	And Agregar concepto por 'barra' y valor '400001351'
	And Ingresar la cantidad '2'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Agregar documento "72380461"
	And Seleccionar el tipo de entrega 'DIFERIDA'
	And Seleccionar comprobante "NOTA DE VENTA (INTERNA)"
@RealizarPedido

Scenario: Realizar un nuevo pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Click en nuevo pedido
	And Agregar concepto "400000891"
	And Agregar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante "NOTA DE VENTA (INTERNA)"
	And Elegir tipo de entrega 'DIFERIDA'
	Then Guardar pedido

@ConfirmarPedido

Scenario: Confirmar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "14/02/2025"
	And Click en consultar pedidos
	And Buscar venta '0001-20094'
	And Click en confirmar pedido
	Then Guardar pedido

@InvalidarPedido
Scenario: Invalidar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "16/02/2025"
	And Click en consultar pedidos
	And Buscar venta '0001-20093'
	And Click en invalidar pedido
	And Ingresar la observación de invalidación "observación"
	Then Click en aceptar invalidación

@EditarPedido

Scenario: Editar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
