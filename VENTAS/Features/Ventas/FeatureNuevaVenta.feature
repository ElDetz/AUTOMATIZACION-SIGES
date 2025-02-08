Feature: NuevaVenta

Registrar una venta

@NuevaVenta

Scenario: Registro de una nueva venta con pago al contado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'seleccion' y valor '88010-1'
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

Scenario: Registro de una nueva venta con pago al crédito rápido
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Seleccionar tipo de pago "credito rapido"
	Then Guardar venta

Scenario: Registro de una nueva venta con pago al crédito configurado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Nueva Venta"
	And Agregar concepto por 'barra' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Nueva Venta"
	And Ingresar el número de documento '10'
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
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar un punto de venta 'PRINCIPAL'
	And Seleccionar un vendedor 'KETHY'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta Modo Caja"
	And Seleccionar tipo de pago "credito rapido"
	Then Guardar venta

Scenario: Registro de una venta modo caja con pago al crédito configurado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Modo Caja"
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar un punto de venta 'PRINCIPAL'
	And Seleccionar un vendedor 'KETHY'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta Modo Caja"
	And Ingresar el número de documento '10'
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
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
	And Seleccionar tipo de cliente 'DNI' '72380461'
	And Ingresar fecha de emisión de la venta '30/01/2025'
	And Seleccionar tipo de comprobante 'NOTA' en el módulo de "Venta por Contingencia"
	And Ingresar el número de documento 'B002-10'
	And Seleccionar tipo de pago "credito rapido"
	Then Guardar venta

Scenario: Registro de una venta por contigencia con pago al crédito configurado
	Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
	When Seleccionar Venta y luego "Venta Por Contingencia"
	And Agregar concepto por 'seleccion' y valor '88010-1'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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
	And Agregar concepto por 'seleccion' y valor '1010-3'
	And Ingresar cantidad '5'
	And Ingresar precio unitario '30'
	And Activar IGV 'SI'
	And Activar Detalle Unificado 'SI'
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

