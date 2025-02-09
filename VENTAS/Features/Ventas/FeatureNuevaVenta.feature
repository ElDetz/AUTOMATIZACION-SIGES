Feature: NuevaVenta

Registrar una venta

@NuevaVenta

Scenario: Registro de una nueva venta con pago al contado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Seleccionar tipo de pago "contado"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Nueva Venta"
	Then Guardar venta

Scenario: Registro de una nueva venta con pago al crédito rápido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Seleccionar tipo de pago "credito rapido"
	And Ingresar monto inicial de crédito rapido '20' en el módulo de "Nueva Venta"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Nueva Venta"
	Then Guardar venta

Scenario: Registro de una nueva venta con pago al crédito rápido sin inicial
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Seleccionar tipo de pago "credito rapido"
	Then Guardar venta

Scenario: Registro de una nueva venta con pago al crédito configurado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Seleccionar tipo de pago "credito configurado"
	And Ingresar monto inicial '20'
	And Ingresar el número de coutas '3'
	And Ingresar fecha '1 de cada mes'
	And Click en generar coutas
	And Click en Aceptar
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Nueva Venta"
	Then Guardar venta

Scenario: Registro de una nueva venta con pago al crédito configurado sin inicial
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Seleccionar tipo de pago "credito configurado"
	And Ingresar el número de coutas sin inicial '3'
	And Ingresar fecha '1 de cada mes'
	And Click en generar coutas 
	And Click en Aceptar
	Then Guardar venta

@VentaModoCaja

Scenario: Registro de una venta modo caja con pago al contado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Modo Caja"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '2'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar un punto de venta 'PRINCIPAL'
	And Seleccionar un vendedor 'KETHY'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta Modo Caja"
	And Seleccionar tipo de pago "contado"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Venta Modo Caja"
	Then Guardar venta

Scenario: Registro de una venta modo caja con pago al crédito rápido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Modo Caja"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '2'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar un punto de venta 'PRINCIPAL'
	And Seleccionar un vendedor 'KETHY'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta Modo Caja"
	And Seleccionar tipo de pago "credito rapido"
	And Ingresar monto inicial de crédito rapido '20' en el módulo de "Venta Modo Caja"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Venta Modo Caja"
	Then Guardar venta

Scenario: Registro de una venta modo caja con pago al crédito rápido sin inicial
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Modo Caja"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '2'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar un punto de venta 'PRINCIPAL'
	And Seleccionar un vendedor 'KETHY'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta Modo Caja"
	And Seleccionar tipo de pago "credito rapido"
	Then Guardar venta

Scenario: Registro de una venta modo caja con pago al crédito configurado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Modo Caja"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '2'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar un punto de venta 'PRINCIPAL'
	And Seleccionar un vendedor 'KETHY'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta Modo Caja"
	And Seleccionar tipo de pago "credito configurado"
	And Ingresar monto inicial '20'
	And Ingresar el número de coutas '3'
	And Ingresar fecha '1 de cada mes'
	And Click en generar coutas
	And Click en Aceptar
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Venta Modo Caja"
	Then Guardar venta

	Scenario: Registro de una modo caja con pago al crédito configurado sin inicial
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Modo Caja"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '2'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar un punto de venta 'PRINCIPAL'
	And Seleccionar un vendedor 'KETHY'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta Modo Caja"
	And Seleccionar tipo de pago "credito configurado"
	And Ingresar el número de coutas sin inicial '3'
	And Ingresar fecha '1 de cada mes'
	And Click en generar coutas 
	And Click en Aceptar
	Then Guardar venta

@VentaContingencia

Scenario: Registro de una venta por contigencia con pago al contado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Ingresar fecha de emisión de la venta '30/01/2025'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta por Contingencia"
	And Ingresar el número de documento 'B002-10'
	And Seleccionar tipo de pago "contado"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Venta por Contingencia"
	Then Guardar venta

Scenario: Registro de una venta por contigencia con pago al crédito rápido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Ingresar fecha de emisión de la venta '1/01/2025'
	And Seleccionar tipo de comprobante 'BOLETA' en el módulo de "Venta por Contingencia"
	And Ingresar el número de documento '10'
	And Seleccionar tipo de pago "credito rapido"
	And Ingresar monto inicial de crédito rapido '20' en el módulo de "Venta por Contingencia"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Venta por Contingencia"
	Then Guardar venta

Scenario: Registro de una venta por contigencia con pago al crédito rápido sin inicial
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Ingresar fecha de emisión de la venta '30/01/2025'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta por Contingencia"
	And Ingresar el número de documento 'B002-10'
	And Seleccionar tipo de pago "credito rapido"
	Then Guardar venta

Scenario: Registro de una venta por contigencia con pago al crédito configurado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Ingresar fecha de emisión de la venta '30/01/2025'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta por Contingencia"
	And Ingresar el número de documento '10'
	And Seleccionar tipo de pago "credito configurado"
	And Ingresar monto inicial '20'
	And Ingresar el número de coutas '3'
	And Ingresar fecha '1 de cada mes'
	And Click en generar coutas
	And Click en Aceptar
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Venta por Contingencia"
	Then Guardar venta

Scenario: Registro de una venta por contigencia con pago al crédito configurado sin inicial
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Ingresar fecha de emisión de la venta '30/01/2025'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta por Contingencia"
	And Ingresar el número de documento '10'
	And Seleccionar tipo de pago "credito configurado"
	And Ingresar el número de coutas sin inicial '3'
	And Ingresar fecha '1 de cada mes'
	And Click en generar coutas 
	And Click en Aceptar
	Then Guardar venta

@VentaGuiaRemisión

Scenario: Registro de una venta con guía de remisión
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'barra' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'NO'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Click en el botón Guía
	And Ingresar la fecha de inicio de traslado ' '
	And Ingresar el peso bruto total ' '
	And Ingresar el número de bultos ' '
	And Ingresar el RUC del transportista ' '
	And Seleccionar la modalidad del transporte
	And Ingresar el ubigeo de la dirección de origen ' '
	And Ingresar el Detalle de la dirección de origen ' '
	And Ingresar el ubigeo de la dirección de destino ' '
	And Ingresar el Detalle de la dirección de destino ' '
	And Click en el botón aceptar 
	And Seleccionar tipo de pago "contado"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Nueva Venta"
	Then Guardar venta

@VentaDetalleUnificado

Scenario: Registro de una venta con detalle unificado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	When Agregar los siguientes conceptos:
    | barra  | valor   |
    | 1010-3 | 2000    |
    | 1020-4 | 1500    |
    | 1030-5 | 3000    |
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Seleccionar tipo de pago "contado"
	And Seleccionar el medio de pago 'TDEB'
	And Rellene datos de la tarjeta 'BBVA' , 'MASTER' y '206556' en el módulo de "Nueva Venta"
	Then Guardar venta