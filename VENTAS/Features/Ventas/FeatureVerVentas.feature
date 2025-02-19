Feature: FeatureVerVentas

Ver ventas y comprobar sus acciones

@CanjearComprobante

Scenario: Canjear comprobante
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "19/02/2025"
	And Click en consultar ventas
	And Buscar venta 'NV02-46'
	And Activar canje
	And Seleccionar venta
	And Click en el botón canjear
	And Seleccionar el tipo de comprobante "BOLETA DE VENTA ELECTRONICA"
	And Click en el botón aceptar
	Then Ver comprobante

@NotaDebito

Scenario: Emitir una nota de débito con aumento en el valor
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "19/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27905'
	And Ver venta buscada
	And Elegir tipo de nota 'DÉBITO'
	And Seleccionar el tipo de nota "AUMENTO EN EL VALOR"
	And Seleccionar el documento "NOTA DE DEBITO"
	And Escribir el motivo de la nota "Aumentó el valor"
	And Ingresar el aumento de valor de la nota '60'
	And Guardar nota
	Then Ver comprobante

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
	Then Ver comprobante

@NotaCredito

Scenario: Emitir una nota de crédito por anulación de la operación
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "19/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27922'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "ANULACIÓN DE LA OPERACIÓN"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Anulación"
	And Seleccionar el tipo de entrega 'DIFERIDA'
	And Guardar nota
	Then Ver comprobante

Scenario: Emitir una nota de crédito por descuento global
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "19/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27903'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DESCUENTO GLOBAL"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Descuento"
	And Ingresar el descuento global '0.1'
	And Guardar nota
	Then Ver comprobante

Scenario: Emitir una nota de crédito por descuento por Item
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "19/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27899'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DESCUENTO POR ÍTEM"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Descuento"
	And Ingresar el total de descuento '1'
	And Guardar nota
	Then Ver comprobante

Scenario: Emitir una nota de crédito por devolución por Item
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "19/02/2025"
	And Click en consultar ventas
	And Buscar venta 'F002-8174'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DEVOLUCIÓN POR ÍTEM"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Devolución por ítem"
	And Ingresar la cantidad '1'
	And Guardar nota
	Then Ver comprobante

Scenario: Emitir una nota de crédito por devolución total
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "19/02/2025"
	And Click en consultar ventas
	And Buscar venta 'F002-8175'
	And Ver venta buscada
	And Elegir tipo de nota 'CRÉDITO'
	And Seleccionar el tipo de nota "DEVOLUCIÓN TOTAL"
	And Seleccionar el documento "NOTA DE CREDITO"
	And Escribir el motivo de la nota "Devolución total"
	And Seleccionar el tipo de entrega 'DIFERIDA'
	And Guardar nota
	Then Ver comprobante

@InvalidarComprobante

Scenario: Invalidar un comprobante 
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "13/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27909'
	And Ver venta buscada
	And Click en el botón invalidar
	And Ingresar la observación "Error en el monto"
	And Click en opción sí para invalidar documento
	Then Ver comprobante

@ClonarVenta

Scenario: Clonar una venta
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "13/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27909'
	And Ver venta buscada
	And Click en el botón clonar
	Then Guardar venta

@ImprimirComprobante

Scenario: Imprimir comprobante
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "13/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27909'
	And Ver venta buscada
	Then Click en el botón imprimir

@DescargarComprobante

Scenario: Descargar comprobante
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "13/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27909'
	And Ver venta buscada
	Then Seleccionar el tipo de descarga 'pdf'

@EnviarComprobante

Scenario: Enviar comprobante
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Ver Ventas"
	And Ingresar fecha inicial "27/01/2025"
	And Ingresar fecha final "13/02/2025"
	And Click en consultar ventas
	And Buscar venta 'B002-27909'
	And Ver venta buscada
	And Click en el botón enviar
	And Ingresar correo 'kevinsanchezcabrerakevin@gmail.com' 
	And Click en el botón agregar el correo
	Then Enviar comprobante de venta