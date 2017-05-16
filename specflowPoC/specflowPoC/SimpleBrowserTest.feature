Feature: Simple browser test

Scenario: Open website
	When User opens 'http://demoqa.com' website
	Then Website title is 'Demoqa | Just another WordPress site'

Scenario: user registration
	When User opens registration page
		And User fill registration form with following data
			| FirstName | LastName | MartialStatus | Hobby | Country | PhoneNumber | Username | Email       | Password | ConfirmPassword |
			| kokos     | banan    | single        | dance | Poland  | 9393939344  | kokos    | banan@op.pl | qwe12345 | qwe12345        |
	Then User is created