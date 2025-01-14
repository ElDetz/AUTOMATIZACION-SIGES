Feature: NuevaVenta

Nueva Venta con tipo de pago CO

@NuevaVenta
Scenario: Registrar venta con CO
    Given Inicio de sesion con usuario 'admin@plazafer.com' y contrasena 'calidad'
    When Datos de la venta '1010-3' y '72935878' y '12025600'
    And Tipo de pago
    And Medio de pago
    Then Registro exitoso