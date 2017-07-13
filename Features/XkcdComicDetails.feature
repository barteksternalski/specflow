@API @Regression
Feature: Getting information about xkcd comic (API example)

Scenario Outline: Sending request GET with wrong id of a comic returns error
	Given I send the GET request to the "<comicId>/info.0.json"
	Then I receive the response with response code: "<response code>"

Examples:
	| comicId    | response code |
	| abc        | 404           |
	| 9999999999 | 404           |

Scenario: Sending request GET with id of a comic returns comic description (single scenario)
	Given I send the GET request to the "1459/info.0.json"
	When I receive the response with response code: "200"
	Then response contains comic details:
		| day | month | num  | link | year | news | title     |
		| 12  | 12    | 1459 |      | 2014 |      | Documents |


Scenario Outline: Sending request GET with id of a comic returns comic description (multiple executions with different test data)
	Given I send the GET request to the "<comicId>/info.0.json"
	When I receive the response with response code: "200"
	Then response contains comic details:
		| day   | month   | num       | link   | year   | news | title   |
		| <day> | <month> | <comicId> | <link> | <year> |      | <title> |

Examples:
	| comicId | day | month | link | year | news | title     |
	| 1459    | 12  | 12    |      | 2014 |      | Documents |
	| 14      | 1   | 1     |      | 2006 |      | Copyright |
