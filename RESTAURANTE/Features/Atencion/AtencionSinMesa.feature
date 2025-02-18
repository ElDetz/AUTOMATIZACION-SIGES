Feature: AtencionSinMesa

A short summary of the feature
| Orden		| Concepto										| Cantidad	| Anotacion			|
| CODIGO	| 7												| -			| -					|
| ITEM		| ADICIONAL 1/2 PORCIÓN DE CANCHITA					| 2			| -					|
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
	| ITEM		| 167\|VINO FRONTERA BOTELLA 1 UN						| 1			|					|
	| CODIGO	| 7														| 			| 					|
	| ITEM		| 167\|VINO FRONTERA BOTELLA 1 UN						| 2			|					|
	| CODIGO	| 17													| 			| 					|
	| ITEM		| 167\|VINO FRONTERA BOTELLA 1 UN						| 3			|					|

	And Se realiza la accion de 'Guardar' la Orden
	Then Orden Tomada