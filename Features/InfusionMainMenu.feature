Feature: InfusionMainMenu example

@UI @Regression
Scenario: Check Menu Items
	Given I open home page
	When I click on menu button
	Then list of menu items is displayed
		| menu items  |
		| Solutions   |
		| Work        |
		| Industries  |
		| About       |
		| Join        |
		| Events      |
		| Contact     |
		| Back to Top |