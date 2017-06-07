Feature: API calls to verify
	some feature to verify

Background:
	Given Service "http://localhost:3000" is up and running

@API
Scenario: 01. Simple GET
	When I request list of users
	Then No of users is 2

@API
Scenario Outline: 02. Creatne new user
	When I create new user with following data
		| Id   | Name   | Location   |
		| <id> | <name> | <location> |
	Then User is created

	Examples:
		| id | name  | location |
		| 7  | kokos | radom    |

@API
Scenario Outline: 03. Remove created user
	When I delete user with id <id>
	Then List of users is updated

	Examples:
		| id |
		| 7  |