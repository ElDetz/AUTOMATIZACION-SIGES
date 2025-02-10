Feature: Factura Atencion Cuenta Dividida
And Se especifica que la factura será dividida en '3' cuentas 

@FacturaAtencionCuentaDividida
Scenario: Facturación con Cuenta Dividida - 001
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Caja'
	And Se selecciona el tipo de factura 'CUENTA DIVIDIDA'
	And Se especifica que la factura será dividida en '3' cuentas 
	When Se ingresan los detalles de la factura:
	| TipoCliente | ValorCliente	| TipoComprobante				| Observacion	| MedioPago |
	| ALIAS       | 72935878		| FACTURA ELECTRONICA			| OBSERVACIÓN1	| DEPCU     |
	| ALIAS		  | CHIQUI			| NOTA DE VENTA (INTERNA)		| OBSERVACIÓN2	| TDEB	    |

	And Se ingresan los datos del pago:
	| Banco_Cuenta         | TipoTarjeta       | MontoRecibido | Informacion |
	| 001103180100023457   | -                 | -		       | -           |
	| INTERBANK			   | AMERICAN EXPRESS  | -		       | 10010       |

	Then Se realiza la facturación

