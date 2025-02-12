Feature: Preparacion

A short summary of the feature

@Preparacion
Scenario: Preparacion de una orden
	Given Inicio de sesión con usuario 'admin@tintoymadero.com' y contraseña 'calidad'
	And Se ingresa al módulo 'Preparacion'
	And Se realiza la busqueda de la ultima orden registrada 10
	When Se ingresan los detalles de la factura:
	| TipoCliente | ValorCliente	| TipoComprobante				| Observacion	| MedioPago |
	| DNI         | 72935878		| NOTA DE VENTA (INTERNA)		| OBSERVACIÓN	| EF	    |

	Then Se procede a 'Preparar' la orden
