Feature: NuevaVenta

Nueva Venta con tipo de pago CO

@NuevaVenta
Scenario: Registrar venta con CO
	Given Inicio de sesion
    When Datos de la venta
    And Tipo de pago
    And Medio de pago
    Then Registro exitoso