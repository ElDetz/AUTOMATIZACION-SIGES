Feature: AtencionSinMesa

A short summary of the feature
| Orden		| Concepto										| Cantidad	| Anotacion			|
| CODIGO	| 7												| -			| -					|
| ITEM		| ADICIONAL 1/2 PORCIÓN DE CANCHITA					| 2			| -					|

@AtencionSinMesa
Scenario: Atencion de una orden sin mesa - DELIVERY
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Atencion'
	And Se seleciona el tipo de atencion 'SIN MESA' 
	And Se seleciona el modo 'DELIVERY'
	And Se ingresa el cliente 'LEONARDO'
	And Se selecciona el mozo 'JAVIER STANLY CISNEROS SANCHEZ'
	When Se ingresa las siguientes ordenes: 
	| Orden		| Concepto												| Cantidad	| Anotacion			|
	| ITEM		| 8\|CARTA ANTICUCHO A LA PARRILLA						| 1			| Anotacion 1		|
	| CODIGO	| 9\|CARTA MOLLEJAS A LA PARRILLA						| 1			|					|
	| ITEM		| 23\|CARTA MILANESA DE POLLO							| 2			|					|
	| CODIGO	| 8\|CARTA ANTICUCHO A LA PARRILLA						| 1			| Anotacion 3		|
	| ITEM		| 17\|CARTA TEQUEÑOS EN SALSA DE HUACAMOLE				| 2			| Anotacion 4		|

	And Se realiza la siguiente modificacion a la orden:
	| Accion			| Concepto								| Cantidad | Anotacion			|
	| Agregar anotacion | CARTA MOLLEJAS A LA PARRILLA			| 1        | Anotacion 2	    |
	| Eliminar			| CARTA MILANESA DE POLLO				| 2        |					|

	Then Se procede a 'Guardar' la orden

@AtencionSinMesa
Scenario: Atencion de una orden sin mesa - AL PASO
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Atencion'
	And Se seleciona el tipo de atencion 'SIN MESA' 
	And Se seleciona el modo 'AL PASO'
	And Se ingresa el cliente 'LEONARDO'
	And Se selecciona el mozo 'JAVIER STANLY CISNEROS SANCHEZ'
	When Se ingresa las siguientes ordenes: 
	| Orden		| Concepto												| Cantidad	| Anotacion			|
	| ITEM		| 8\|CARTA ANTICUCHO A LA PARRILLA						| 1			| Sin ensalada		|
	| CODIGO	| 9\|CARTA MOLLEJAS A LA PARRILLA						| 1			|					|
	| ITEM		| 8\|CARTA ANTICUCHO A LA PARRILLA						| 4			| Sin ensalada		|

	Then Se procede a 'Guardar' la orden

@AtencionSinMesa
Scenario: Buscar orden
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Atencion'
	And Se seleciona el tipo de atencion 'SIN MESA' 
	And Se selecciona el siguiente pedido:
	| Alias				| Modo			| Total			|
	| LEONARDO			| DELIVERY		| 246.00		|
	And Se realiza la accion de 'Atender'