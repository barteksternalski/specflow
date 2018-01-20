Feature: API integration
  As a User I want to verify API integration with the system

	@IntegrationAPI
	Scenario Outline: 01. Verify successful sign in request
	Given System API on '<env>' environment is up and running
	When User sends sign in request with following data
		| Command | Login   | Password |
		| <comm>  | <login> | <pass>   |
	Then Access token is sent back by the system

	Examples:
		| env | comm   | login                                   | pass      |
		| DEV | SignIn | default.carrier@csiodev.onmicrosoft.com | Infusi0n! |

	@IntegrationAPI
	Scenario Outline: 02. Verify unsuccessful sign in request
	Given System API on '<env>' environment is up and running
	When User sends sign in request with following data
		| Command | Login   | Password |
		| <comm>  | <login> | <pass>   |
	Then System responses with proper error '<message>'

	Examples:
		| env | comm   | login                              | pass       | message                                                        |
		| DEV | SignIn | admin.five@csiodev.onmicrosoft.com | BadPass    | Invalid username or password                                   |
		| DEV | SignIn | admin.five@op.pl                   | Si3ple9Ass | account must be added to the csiodev.onmicrosoft.com directory |
		| DEV | SignIn | admin.five@csiodev.onmicrosoft.com |            | Password field is required                                     |
		| DEV | SignIn |                                    | Kokos      | UserId field is required                                       |
		| DEV | SignIn |                                    |            | UserId field is required                                       |
		| DEV | SignIn |                                    |            | Password field is required                                     |
		| DEV | SignIn | dsadsa                             | dsadsa     | Unknown User Type                                              |  

	@IntegrationAPI
	Scenario Outline: 03. Verify successful eSlip request
	Given System API on '<env>' environment is up and running
	When User sends eSlip creation request with following data
		| RequestDate | OtherID   | CommercialName | UserEmail | EffectiveDate | ExpirationDate | InsuranceCompName | Language | PolicyNumber |
		| <reqDate>   | <otherId> | <brokerName>   | <email>   | <effDate>     | <expDate>      | <insuranceName>   | <lang>   | <policyNo>   |
	Then ESlip is properly created in the system

	Examples:
		| env | reqDate    | otherId   | brokerName | email                    | effDate    | expDate    | insuranceName     | lang | policyNo |
		| DEV | 2018-01-20 | sitBroker | sitBroker  | b.sternalski@avanade.com | 2018-01-01 | 2018-10-31 | Awesome Infurance | EN   | PL102938 |