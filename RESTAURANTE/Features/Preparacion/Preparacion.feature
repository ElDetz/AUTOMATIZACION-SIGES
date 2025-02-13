Feature: Preparacion

A short summary of the feature

@Preparacion
Scenario: Preparacion de varias ordenes
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Preparacion'
	When Se procede a 'Preparar' las siguientes ordenes:
	| ORDEN				| ITEM										|
	| C001 - 125340		| SALCHIPAPA SALCHIPAPA ESPECIAL			|
	| C001 - 125340		| CARTA MOLLEJAS A LA PARRILLA				|
	| C001 - 125340		| CARTA PIQUEO DE LOMO FINO					|
	| C001 - 125339		| CARTA BROCHETA DE LOMO					|

	Then 

@Preparacion
Scenario: Preparacion de todos los items de una orden
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Preparacion'
	When Se procede a 'Preparar' todos los items de la orden 'C001 - 125340'
	Then 
