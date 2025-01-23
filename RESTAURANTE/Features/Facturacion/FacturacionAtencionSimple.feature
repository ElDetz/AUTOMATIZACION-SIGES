Feature: Factura Atencion Simple

Se realiza la factura de una atención en modo simple

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Ingresar a Modulo Caja
	When Datos de la factura
	Then Factura exitoso