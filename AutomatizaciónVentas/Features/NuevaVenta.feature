Feature: Generar nueva venta en el sistema SIGES

  Como usuario registrado
  Quiero generar una venta en la plataforma SIGES

    Scenario: Generar una nueva venta
    Given el usuario está autenticado en SIGES
    When el usuario accede al módulo "Venta" y selecciona "Nueva venta"
    And selecciona el concepto e ingresa el producto "ACCESORIO TANQUE BAJO"
    Then el proceso debería estar listo para completar la venta

