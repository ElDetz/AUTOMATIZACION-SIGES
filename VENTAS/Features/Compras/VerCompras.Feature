Feature: VerCompras



Visualizar compras

@VerCompras
#Búsqueda general y especifica con un campo
Scenario: Busqueda general y especifica con un campo
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Rango de busqueda '01/01/2025' y '01/02/2025'
    When Se realiza una busqueda con tipo 'BUSQUEDA GENERAL' y 'LAURENTE'

#Búsqueda específica múltiple con 2 campos
Scenario: Busqueda especifica multiple con 2 campos
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Rango de busqueda '01/01/2025' y '01/02/2025'
    When Busqueda especifica 'BUSQUEDA ESPECIFICA' y 'TIPO DOC., DOCUMENTO' y 'NC' y 'NC02 - 14' 
    When Exportar resultados

    #FECHA: valor que recibe '01/02/2025'
    #TIPO DOC: puede tomar valores como 'NC', ''FAC y ''BV'
    #DOCUMENTO: ingresar el identificador del documento: ejemplo 'NC02 - 14'
    #Para busquedas específicas, es decir FECHA, TIPO DOC. y DOCUMENTO utilizar el siguiente step:
        #When Se realiza una busqueda con tipo 'BUSQUEDA ESPECIFICA' y opcion 'FECHA' y criterio '01/02/2025'
    #Si se requiere exportar los resultados de la búsqueda añadir lo siguiente:
        #When Exportar resultados

Scenario: Registrar nueva venta desde la sección Ver Compras1
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Proveedor '71310154' Fecha '14/02/2025'
    #When Tipo Doc. 'BOLETA DE VENTA ELECTRONICA' Serie 'B001' Num. Doc.'10' Observacion 'Listo'
    #When Entrega 'INMEDIATA' Cant. Almacenes 'UNO' Rol 'Mercaderia' Almacen 'CA PRINCIPAL'
    #When Tipo de compra 'NG'
    #When Concepto '400000891' Importe '10'
    #When Tipo de pago 'CONTADO' 
    #When Medio de Pago 'DEPCU' y 'OK'
    #When Tipo de pago 'CREDITO CONFIGURADO'
    #When Registrar nuevo concepto '73201339' y 'MASCULINO'
    When Codigo '123456789' Sufijo 'DE 1" 1/2'

Scenario: Registrar nueva venta desde la sección Ver Compras3
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Proveedor '71310154' Fecha '14/02/2025'
    #When Tarifa 'CLIENTE FRECUENTE' Precio '11' y 'GUARDAR'
    When Registrar nueva familia 'XD'

Scenario: Registrar nueva venta desde la sección Ver Compras4
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Proveedor '71310154' Fecha '14/02/2025'
    When Registrar nueva familia 'BIEN' y 'XDDD' y 'SIN CATEGORIA' y 'NO'