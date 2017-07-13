@AVD @Regression
Feature: Selendroid test app example

Scenario: Interacting with buttons
	Given I started test app
	When I click on 'EN Button'
	Then 'This will end the activity' text is shown on modal

Scenario: Interacting with buttons (watiting for element example)
	Given I started test app
	And I click on 'Show Progress Bar for a while'
	When 'Waiting Dialog' text is shown on modal
	Then I wait for 'Waiting Dialog' modal to disappear
	And 'Welcome to register a new User' text is shown on screen