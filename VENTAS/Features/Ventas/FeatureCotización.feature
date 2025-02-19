﻿Feature: FeatureCotización

Realizar ventas por cotización

@RealizarCotización

Scenario: Realizar una nueva cotización
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Click en nueva cotización
	And Agregar concepto para cotización '400001351'
	And Agregar la cantidad '2'
	And Ingresar el precio unitario '2.5'
	And Ingresar IGV 'SI'
	And Agregar tipo de cliente para cotización 'DNI' '72380461'
	And Ingresar la fecha de vencimiento '10/03/2025'
	Then Guardar pedido o cotización

Scenario: Realizar una nueva cotización para detalle unificado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Click en nueva cotización
	And Agregar conceptos para cotización:
    | value |
    | 400000891 |
    | 400000437 |
	And Agregar la cantidad '2'
	And Ingresar el precio unitario '2.5'
	And Ingresar IGV 'SI'
	And Agregar tipo de cliente para cotización 'DNI' '72380461'
	And Ingresar la fecha de vencimiento '10/03/2025'
	Then Guardar pedido o cotización

@PregenerarPedido     

Scenario: Pregenerar pedido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial '27/01/2025'
	And Digitar fecha final '17/02/2025'
	And Click en consultar pedidos
	And Buscar venta '0002 - 25613'
	And Click en pregenerar pedido
	Then Guardar pedido pregenerado

Scenario: Pregenerar pedido con cliente identificado o alias
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial '27/01/2025'
	And Digitar fecha final '17/02/2025'
	And Click en consultar pedidos
	And Buscar venta '0002 - 25620'
	And Click en pregenerar pedido
	And Identificar cliente 'DNI' '72380461'
	Then Guardar pedido o cotización

Scenario: Pregenerar pedido con detalle unificado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial '27/01/2025'
	And Digitar fecha final '17/02/2025'
	And Click en consultar pedidos
	And Buscar venta '0002 - 25613'
	And Click en pregenerar pedido
	And Seleccionar el DET.UNIF. 'SI'
	And Agregar tipo de cliente 'DNI' '72380461'
	Then Guardar pedido o cotización

@PregenerarVenta
Scenario: Pregenerar venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Cotización
	And Digitar fecha inicial '27/01/2025'
	And Digitar fecha final '12/02/2025'
	And Click en consultar pedidos
	And Buscar venta '0002 - 25613'
	And Click en pregenerar venta
	Then Guardar venta pregenerada