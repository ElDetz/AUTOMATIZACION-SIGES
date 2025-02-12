Feature: NuevaVenta

Nueva Venta con tipo de pago CO

@NuevaVenta
Scenario: Registrar venta con CO
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Datos de la venta '88008-1' y '72935878'
    And Tipo de comprobante 'NOTA DE VENTA (INTERNA)'
    And Tipo de pago 'TDEB'
    And Datos del pago 'BBVA  CONTINENTAL' y 'MASTER CARD' y '20005-205'
    Then Registro exitoso

@NuevaVenta
Scenario: Registrar venta con CO Credito
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Datos de la venta '1010-3' y '72935878'
    And Tipo de pago 'TCRE'
    And Datos del pago 'INTERBANK' y 'DINERS CLUB' y '10001-2005'
    Then Registro exitoso

@NuevaVenta
Scenario: Registrar venta con CO Transferencia
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Datos de la venta '88008-1' y '72935878'
    And Tipo de pago 'TRANFON'
    And Datos del pago 'BCP | PEN | 5601898737134' y '10001-2005'
    Then Registro exitoso

@NuevaVenta
Scenario: Registrar venta con CO Cuenta Bancaria
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Datos de la venta '88008-1' y '72935878'
    And Tipo de pago 'DEPCU'
    And Datos del pago 'BCP | PEN | 5601898737134' y '10001-2005'
    Then Registro exitoso

@NuevaVenta
Scenario: Registrar venta con CO Efectivo
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Prueba '71310154'
    