Feature: Reportes - Compras



Visualizar reportes

@Reportes

Scenario: Reportes
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Ingresar a Compras - Reportes
    #Los reportes pueden ser: COMPROBANTE o CONCEPTO
    #When Reporte por 'CONCEPTO' Fecha Inicial '01/01/2025' Fecha Final '01/02/2025'
    #Utilizar la siguiente línea cuando se quiere reportes detallados por tipo de comprobante
    #Opciones para tipo de comprobante: TODOS, TRIBUNALES, 'NO TRIBUNALES'
    When Reporte por Tipo, Tipo de comprobante 'NO TRIBUNALES' Fecha Inicial '01/01/2025' Fecha Final '01/02/2025'
    Then Generar reporte por 'TIPO'