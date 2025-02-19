Feature: FeaturePedidos

Realizar ventas por pedidos

@RealizarPedido

Scenario: Realizar un nuevo pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Click en nuevo pedido
	And Agregar concepto '400001351'
	And Agregar cantidad '2'
	And Agregar precio unitario '3.40'
	And Seleccionar IGV 'no'
	And Seleccionar DET.UNIF. 'SI'
	And Agregar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante "NOTA DE VENTA (INTERNA)"
	And Elegir tipo de entrega 'DIFERIDA'
	Then Guardar pedido o cotización

Scenario: Realizar un nuevo pedido con con detalle unificado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Click en nuevo pedido
	And Agregar conceptos para pedido:
    | value |
    | 400000891 |
    | 400000437 |
	And Agregar cantidad '2'
	And Agregar precio unitario '3.40'
	And Seleccionar IGV 'no'
	And Seleccionar DET.UNIF. 'SI'
	And Agregar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante "NOTA DE VENTA (INTERNA)"
	And Elegir tipo de entrega 'DIFERIDA'
	Then Guardar pedido o cotización

@ConfirmarPedido

Scenario: Confirmar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Digitar fecha inicial '27/01/2025'
	And Digitar fecha final '14/02/2025'
	And Click en consultar pedidos
	And Buscar venta '0001-20103'
	And Click en confirmar pedido
	Then Guardar pedido o cotización

@InvalidarPedido
Scenario: Invalidar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Digitar fecha inicial '27/01/2025'
	And Digitar fecha final '16/02/2025'
	And Click en consultar pedidos
	And Buscar venta '0001-20093'
	And Click en invalidar pedido
	And Ingresar la observación de invalidación "observación"
	Then Click en aceptar invalidación
