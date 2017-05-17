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
	Then Message <message> is displayed

	Examples:
		| firstname | lastname | status | hobby | country | phone      | user    | mail          | pass     | confirmation | message                              |
		| kokos     | banan    | single | dance | Poland  | 9393939344 | banan   | banan@op.pl   | qwe12345 | qwe12345     | Error: E-mail address already exists |
		| test1     | test2    | single | dance | Poland  | 9393757344 | sputnik | bputnik@op.pl | qwe12345 | qwe12345     | Thank you for your registration      |