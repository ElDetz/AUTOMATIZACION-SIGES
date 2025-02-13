Feature: AtencionSinMesa

A short summary of the feature

A short summary of the feature

@AtencionSinMesa
Scenario: Atencion de una orden sin mesa
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Atencion'
	When Se seleciona la mesa '10' las siguientes ordenes:


@tag1
Scenario: [scenario name]
	Given [context]
	When [action]
	Then [outcome]
