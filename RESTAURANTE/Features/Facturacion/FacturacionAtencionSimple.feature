Feature: Factura Atencion Simple

	FACTURA ELECTRONICA Necesita RUC
	BOLETA DE VENTA ELECTRONICA
	NOTA DE VENTA (INTERNA)

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple - EFECTIVO
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Caja'
	And Se selecciona el tipo de factura 'SIMPLE'
	
	When Se ingresan los detalles de la factura:
	| TipoCliente | ValorCliente	| TipoComprobante				| Observacion	| MedioPago |
	| DNI         | 72935878		| NOTA DE VENTA (INTERNA)		| OBSERVACIÓN	| EF	    |

	Then Se realiza la facturación

	
Scenario: Factura de Atencion Simple - TDEB
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Caja'
	And Se selecciona el tipo de factura 'SIMPLE'
	
	When Se ingresan los detalles de la factura:
	| TipoCliente | ValorCliente	| TipoComprobante				| Observacion	| MedioPago |
	| DNI         | 72935878		| BOLETA DE VENTA ELECTRONICA	| OBSERVACIÓN	| TDEB	    |

	And Se ingresan datos del pago 'INTERBANK' 'AMERICAN EXPRESS' '10001'
	Then Se realiza la facturación
	

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple - TARJETA
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'SIMPLE'
	When Ingresar detalles de la factura 'DNI' '72935878' 'FACTURA ELECTRONICA' 'OBSERVACION' 'TDEB'
    And Selecciona el tipo de comprobante 'NOTA DE VENTA (INTERNA)'
	And Ingresa alguna observacion 'OBSERVACION'
	And Selecciona el modo de pago 'TDEB'
		And Se ingresan los datos del pago:
	| Banco_Cuenta         | TipoTarjeta       | MontoRecibido | Informacion |
	| 001103180100023457   | -                 | -		       | 10012       |
	Then Realizar facturacion


