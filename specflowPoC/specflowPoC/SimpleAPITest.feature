Feature: API calls to verify
	some feature to verify

Background:
	Given Service "http://localhost:3000" is up and running

@API
Scenario: 01 Simple GET
	When I request list of users
	Then No of users is 3

@API
Scenario Outline: 02 Creatne new user
	When I create new user with following data
		| Id   | Name   | Location   |
		| <id> | <name> | <location> |
	Then User is created

	Examples:
		| id | name  | location |
		| 7  | kokos | radom    |