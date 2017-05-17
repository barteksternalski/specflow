Feature: Simple browser test

Scenario: Open website
	When User opens 'http://demoqa.com' website
	Then Website title is 'Demoqa | Just another WordPress site'

Scenario Outline: User registration
	When User opens 'http://demoqa.com' website
	When User opens registration page
		And User fill registration form with following data
			| FirstName   | LastName   | MartialStatus | Hobby   | Country   | PhoneNumber | Username | Email  | Password | ConfirmPassword |
			| <firstname> | <lastname> | <status>      | <hobby> | <country> | <phone>     | <user>   | <mail> | <pass>   | <confirmation>  |
	Then User is created

	Examples:
		| firstname | lastname | status | hobby | country | phone      | user  | mail        | pass     | confirmation |
		| kokos     | banan    | single | dance | Poland  | 9393939344 | kokos | banan@op.pl | qwe12345 | qwe12345     |
		| test1     | test2    | single | dance | Poland  | 9393757344 | baton | baton@op.pl | qwe12345 | qwe12345     |