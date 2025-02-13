Feature: FeatureVerVentas

Ver ventas y comprobar sus acciones

@CanjearComprobante

Scenario: Canjear comprobante
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "11/02/2025"
	And Click en consultar ventas
	And Buscar venta 'NV02-46'
	And Activar canje
	And Seleccionar venta
	And Click en el botón canjear
	And Seleccionar el tipo de comprobante "BOLETA DE VENTA ELECTRONICA"
	And Click en el botón aceptar
	Then Ver comprobante canjeada 'NV02-47'

@NotaDebito

Scenario: Emitir una nota de débito con aumento en el valor
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "12/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27905'
	And Ver venta buscada
	And Elegir tipo de nota 'DÉBITO'
	And Seleccionar el tipo de nota "AUMENTO EN EL VALOR"
	And Seleccionar el documento "NOTA DE DEBITO"
	And Escribir el motivo de la nota "Aumentó el valor"
	And Ingresar el aumento de valor de la nota '60'
	And Guardar nota
	Then Ver la nota emitida 'B002-27905'

Scenario: Emitir una nota de débito con interés por mora
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "12/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27901'
	And Ver venta buscada
	And Elegir tipo de nota 'DÉBITO'
	And Seleccionar el tipo de nota "INTERESES POR MORA"
	And Seleccionar el documento "NOTA DE DEBITO"
	And Escribir el motivo de la nota "Interés por mora"
	And Ingresar el interés total '50'
	And Guardar nota
	Then Ver la nota emitida 'B002-27901'

@NotaCredito

Scenario: Emitir una nota de crédito por anulación de la operación
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "12/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27900'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "ANULACIÓN DE LA OPERACIÓN"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Anulación"
	And Guardar nota
	Then Ver la nota emitida 'B002-27900'

Scenario: Emitir una nota de crédito por descuento global
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "12/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27903'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DESCUENTO GLOBAL"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Descuento"
	And Ingresar el descuento global '30'
	And Guardar nota
	Then Ver la nota emitida 'B002-27903'

Scenario: Emitir una nota de crédito por descuento por Item
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "12/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27899'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DESCUENTO POR ÍTEM"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Descuento"
	And Ingresar el total de descuento '1'
	And Guardar nota
	Then Ver la nota emitida 'B002-27899'

Scenario: Emitir una nota de crédito por devolución total
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "12/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27898'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DEVOLUCIÓN TOTAL"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Devolución total"
	And Guardar nota
	Then Ver la nota emitida 'B002-27898'

Scenario: Emitir una nota de crédito por devolución por Item
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "12/02/2025"
	And Click en consultar ventas
	And Buscar venta 'F002-8174'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DEVOLUCIÓN POR ÍTEM"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Devolución por ítem"
	And Ingresar la cantidad '1'
	And Guardar nota
	Then Ver la nota emitida

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