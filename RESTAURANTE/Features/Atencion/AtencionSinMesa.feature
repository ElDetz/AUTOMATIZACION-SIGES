Feature: AtencionSinMesa

A short summary of the feature
| Orden		| Concepto										| Cantidad	| Anotacion			|
| CODIGO	| 7												| -			| -					|
| ITEM		| CARTA LOMO FINO A LA CHORRILLANA				| 2			| -					|
@AtencionSinMesa
Scenario: Atencion de una orden sin mesa
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Atencion'
	And Se seleciona el tipo de atencion 'SIN MESA' 
	And Se seleciona el modo 'DELIVERY'
	And Se ingresa el cliente 'LEONARDO'
	And Se selecciona el mozo 'JAVIER STANLY CISNEROS SANCHEZ'
	When Se ingresa las siguientes ordenes: 
	| Orden		| Concepto												| Cantidad	| Anotacion			|
	| ITEM		| ADICIONAL 1/2 PORCIÓN DE CANCHITA						| 2			|					|
	| CODIGO	| 7														| -			| -					|

	Then [outcome]