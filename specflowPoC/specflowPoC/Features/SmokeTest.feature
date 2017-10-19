Feature: Simple browser test

	@UISmoke
	Scenario: 001. Setup browser
		Given Clear email account
		Given Generate unique name
		Given Setup 'Chrome' browser

	@UISmoke
	Scenario Outline: 002. User can login
		Given User is on login page
		When User enters '<login>' and '<password>'
		Then Main page is displayed

		Examples:
			| login                              | password   |
			| admin.five@csiodev.onmicrosoft.com | Si3ple9Ass |

	@UISmoke
	Scenario Outline: 003. Successfully create new user
		Given User is on dashboard page
		When User creates new user with given data
			| UserType   | UserId   | UserName | Email   | OrganizationId | OrganizationType | CsioNetId | Carrier   | Broker      | File   | Modules   |
			| <userType> | <userId> | <name>   | <email> | <orgUserId>    | <orgType>        | <csioId>  | <carrier> | <brokerage> | <file> | <modules> |
		Then User '<name>' is created
		When User logs out

		Examples:
			| userType     | userId | name  | email                 | orgUserId | orgType | csioId | carrier     | brokerage | file   | modules             |
			| Organization | baton  | baton | bartavanade@gmail.com | {null}    | Carrier | baton  | TestCarrier | {null}    | {null} | Users,Create Single |

	@UISmoke
	Scenario Outline: 004. Verify user access
		Given User is on login page
		When Created user enters '<login>' and '<password>'
		Then Main page is displayed
		Then User has access to '<modulesAvailable>' modules
		Then User does not have access to '<modulesUnavailable>' modules
		When User logs out

		Examples:
			| login                         | password   | modulesAvailable                                | modulesUnavailable                                 |
			| baton@csiodev.onmicrosoft.com | Si3ple9Ass | Create Single,Drafts,Sent,Create User,User List | Dashboard,Reporting,Create Bulk,E-mail,E-Slip Back |

	@UISmoke
	Scenario Outline: 005. User can login
		Given User is on login page
		When User enters '<login>' and '<password>'
		Then Main page is displayed

		Examples:
			| login                                 | password |
			| bartBrokerage@csiodev.onmicrosoft.com | 2@d!tQy4 |

	@UISmoke
	Scenario Outline: 006. User is able to fill Customer and Policy Information
		Given User is creating new eEslip
		When User creates new eSlip with given customer and policy information with given data
			| EslipName | PolicyNumber | Email   | PhoneNumber | Language | Province   | AddressLine1 | AddressLine2 | City   | PostalCode | EffectiveDate | ExpirationDate | Insurer   | Brokerage |
			| <name>    | <policyNo>   | <email> | <phoneNo>   | <lang>   | <province> | <address1>   | <address2>   | <city> | <code>     | <effDate>     | <expDate>      | <insurer> | <broker>  |
		When User saves eSlip draft
		Then ESlip '<name>' is displayed on Drafts list

		Examples:
			| name  | policyNo  | email                 | phoneNo   | lang    | province | address1 | address2 | city | code  | effDate    | expDate    | insurer    | broker |
			| banan | 123123123 | bartavanade@gmail.com | 123123123 | English | Manitoba | temp1    | temp1    | krk  | 30300 | 12/12/2020 | 12/12/2022 | RSA Canada | {null} |

	@UISmoke
	Scenario: 007. Tear down browser
		Given Close browser