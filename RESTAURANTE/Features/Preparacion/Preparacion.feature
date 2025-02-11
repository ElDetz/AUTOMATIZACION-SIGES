Feature: Preparacion

A short summary of the feature

@Preparacion
Scenario: Preparacion de una orden
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Preparacion'
	And Se realiza la busqueda de la ultima orden registrada 10
	When Preparar Orden
	Then Servir ordens
