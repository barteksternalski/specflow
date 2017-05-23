Feature: API calls to verify
	some feature to verify

Background:
	Given Service "http://localhost:3000" is up and running

@API
Scenario: Simple GET
	When I request list of users
	Then No of users is 2

@API
Scenario Outline: Creatne new user
	When I create new user with following data
		| Id   | Name   | Location   |
		| <id> | <name> | <location> |
	Then User is created

	Examples:
		| id | name  | location |
		| 7  | kokos | radom    |