Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](RESTAURANTE/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

	@FacturaAtencionSimple
Scenario: Factura de Atencion Simple ALIAS
	Given Inicio de sesion con usuario 'admin@tintoymadero.com' y contrasena 'calidad'
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'DIFERENCIADO'
	When Se ingresa los datos de la factura 'DNI' '72935878'
    And Selecciona el tipo de comprobante 'NOTA DE VENTA (INTERNA)'
	And Selecciona el modo de pago 'TRANFON'
	Then Factura exitoso

@FacturaAtencionSimple
Scenario: Factura de Atencion Simple DNI2
	Given Inicio de sesion con usuario 
	| Username               | Password |
	| admin@tintoymadero.com | calidad  |
	And Se ingresa al modulo 'Caja'
	And Selecciona el tipo de factura 'CUENTA DIVIDIDA'
	When Se ingresa los datos de la factura 'DNI' '72935878'
    And Selecciona el tipo de comprobante 'FACTURA ELECTRONICA'
	And Selecciona el modo de pago 'TDEB'
	And Datos de pago 'BBVA  CONTINENTAL' 'MASTER CARD' '20005-205'
	Then Factura exitoso