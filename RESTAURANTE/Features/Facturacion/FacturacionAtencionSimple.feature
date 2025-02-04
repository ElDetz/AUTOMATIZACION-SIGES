Feature: Factura Atencion Simple

	FACTURA ELECTRONICA Necesita RUC
	BOLETA DE VENTA ELECTRONICA
	NOTA DE VENTA (INTERNA)

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple - CP0001
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'SIMPLE'
	When Ingresa el cliente 'DNI' '72935878'
    And Selecciona el tipo de comprobante 'NOTA DE VENTA (INTERNA)'
	And Ingresa alguna observacion 'OBSERVACION'
	And Selecciona el modo de pago 'DEPCU'
	And Se ingresa datos del pago '' ''
	Then Factura exitoso

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple - CP0004
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'SIMPLE'
	When Ingresa el cliente 'DNI' '72935878'
	And Selecciona el tipo de comprobante 'BOLETA DE VENTA ELECTRONICA'
	And Ingresa alguna observacion 'OBSERVACION'
	And Selecciona el modo de pago 'TCRE'
	And Se ingresa datos del pago '' '' ''
	Then Factura exitoso

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple - CP0010
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'SIMPLE'
	When Ingresa el cliente 'RUC' '20602394060'
	And Ingresa alguna observacion 'OBSERVACION'
    And Selecciona el tipo de comprobante 'BOLETA DE VENTA ELECTRONICA'
	And Selecciona el modo de pago 'EF'
	Then Factura exitoso

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple - CP0008
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'SIMPLE'
	When Ingresa el cliente 'DNI' '72935878'
	And Ingresa alguna observacion 'OBSERVACION'
    And Selecciona el tipo de comprobante 'FACTURA ELECTRONICA'
	And Selecciona el modo de pago 'EF'
	Then Factura exitoso



