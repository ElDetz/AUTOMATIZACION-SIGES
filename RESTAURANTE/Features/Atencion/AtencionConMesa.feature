Feature: AtencionConMesa

A short summary of the feature
	And Se seleciona la mesa '6'
@AtencionConMesa
Scenario: Atencion de una orden con mesa
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Atencion'
	And Se selecciona el ambiente 'PRINCIPAL'
	And Se seleciona la mesa '6'
	When Se guarda el pedido de la mesa 6 - Atendido por 'JAVIER STANLY CISNEROS SANCHEZ':
	| Orden		| Concepto										| Cantidad	| Anotacion			|
	| CODIGO	| CARTA LOMO FINO A LA CHORRILLANA				| 2			|  					|

	Then [outcome]

@AtencionConMesa
Scenario: Seleccion de una Mesa
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Atencion'
	And Se seleciona la mesa '6'

	Then [outcome]
