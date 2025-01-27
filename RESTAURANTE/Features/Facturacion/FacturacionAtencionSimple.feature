Feature: Factura Atencion Simple

Se realiza la factura de una atención en modo simple
 Then El sistema no habilita el botón 'Facturar'
    And Muestra el mensaje de error 'El monto ingresado debe ser mayor a 0'

	FACTURA ELECTRONICA Necesita RUC
	BOLETA DE VENTA ELECTRONICA
	NOTA DE VENTA (INTERNA)

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple ALIAS
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'Simple'
	When Se ingresa los datos de la factura 'ALIAS' 'DEIBY'
    And Selecciona el tipo de factura 'NOTA DE VENTA (INTERNA)'
	And Selecciona el modo de pago 'TRANFON'
	Then Factura exitoso

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple DNI
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'Simple'
	When Se ingresa los datos de la factura 'DNI' '72935878'
    And Selecciona el tipo de factura 'FACTURA ELECTRONICA'
	And Selecciona el modo de pago 'TDEB'
	And Datos de pago 'BBVA  CONTINENTAL' 'MASTER CARD' '20005-205'
	Then Factura exitoso