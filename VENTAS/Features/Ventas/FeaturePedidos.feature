Feature: FeaturePedidos

Realizar pedidos

@RealizarPedido

Scenario: Realizar un nuevo pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Click en nuevo pedido
	And Seleccionar concepto "1010-3 | 1010-3 PISO PVC 18CM X 122CM X 4MM"
	And Ingresar la cantidad de concepto '2'
	And Con IGV 'SI'
	And Con Detalle Unificado 'NO'
	And Seleccionar el cliente 'DNI' '72380461'
	And Seleccionar el comprobante "BOLETA"
	And Seleccionar el tipo de entrega 'INMEDIATA'
	Then Guardar pedido

@ConfirmarPedido

Scenario: Confirmar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "12/02/2025"
	And Click en consultar pedidos
	And Buscar pedido '0001-20088'
	And Click en confirmar pedido
	Then Guardar pedido

@InvalidarPedido
Scenario: Invalidar pedido
	When Seleccionar Pedido
	And Seleccionar ver pedido
	And Digitar fecha inicial "27/01/2025"
	And Digitar fecha final "12/02/2025"
	And Click en consultar pedidos
	And Buscar pedido '0001-20088'
	And Click en invalidar pedido
	And Ingresar la observación de invalidación "observación"
	Then Click en aceptar invalidación

@EditarPedido

Scenario: Editar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
