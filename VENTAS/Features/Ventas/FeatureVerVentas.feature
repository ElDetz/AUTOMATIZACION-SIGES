Feature: FeatureVerVentas

Ver ventas y comprobar sus acciones

@ActivarCanje

Scenario: Activar canje
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Activar canje
	And Seleccionar venta
	And Click en el botón canjear
	And Seleccionar el tipo de comprobante ''
	And Click en el botón aceptar
	Then Ver venta canjeada

@NotaDebito

Scenario: Emitir una nota de débito con aumento en el valor
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en nota de débito
	And Seleccionar el tipo de nota de débito ''
	And Seleccionar el documento ''
	And Escribir el motivo de la nota ' '
	And Ingresar el aumento de valor de la nota ' '
	And Seleccionar tipo de pago "contado"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Ver Ventas"
	And Guardar nota de débito
	Then Ver la nota de débito emitida

Scenario: Emitir una nota de débito con interés por mora
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en nota de débito
	And Seleccionar el tipo de nota de débito ''
	And Seleccionar el documento ''
	And Escribir el motivo de la nota ' '
	And Ingresar el interés total ' '
	And Seleccionar tipo de pago "contado"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Ver Ventas"
	And Guardar nota de débito
	Then Ver la nota de débito emitida

@NotaCredito

Scenario: Emitir una nota de crédito por anulación de la operación
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en nota de crédito
	And Seleccionar el tipo de nota de crédito ''
	And Seleccionar el documento ''
	And Escribir el motivo de la nota ' '
	And Guardar nota de crédito
	Then Ver la nota de crédito emitida

Scenario: Emitir una nota de crédito por descuento global
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en nota de crédito
	And Seleccionar el tipo de nota de crédito ''
	And Seleccionar el documento ''
	And Escribir el motivo de la nota ' '
	And Ingresar el descuento global ' '
	And Guardar nota de crédito
	Then Ver la nota de crédito emitida

Scenario: Emitir una nota de crédito por descuento por Item
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en nota de crédito
	And Seleccionar el tipo de nota de crédito ''
	And Seleccionar el documento ''
	And Escribir el motivo de la nota ' '
	And Ingresar el total de descuento ''
	And Guardar nota de crédito
	Then Ver la nota de crédito emitida

Scenario: Emitir una nota de crédito por devolución total
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en nota de crédito
	And Seleccionar el tipo de nota de crédito ''
	And Seleccionar el documento ''
	And Escribir el motivo de la nota ' '
	And Guardar nota de crédito
	Then Ver la nota de crédito emitida

Scenario: Emitir una nota de crédito por devolución por Item
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en nota de crédito
	And Seleccionar el tipo de nota de crédito ''
	And Seleccionar el documento ''
	And Escribir el motivo de la nota ' '
	And Guardar nota de crédito
	Then Ver la nota de crédito emitida

@InvalidarVenta

Scenario: Invalidar una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en el botón invalidar
	And Ingresar la observación ' '
	And Click en opción sí
	Then Ver venta invalidada

@ClonarVenta

Scenario: Clonar una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en el botón clonar
	Then Guardar Venta

@ImprimirVenta

Scenario: Imprimir una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	Then Click en el botón imprimir

@DescargarVenta

Scenario: Descargar una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	Then Click en el botón descargar

@EnviarVenta

Scenario: Enviar documento de una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial ''
	And Ingresar fecha final ''
	And Click en consultar ventas
	And Buscar venta ''
	And Ver venta buscada
	And Click en el botón enviar
	And Ingresar correo ' ' 
	And Click en el botón agregar correo
	Then Enviar documento de venta