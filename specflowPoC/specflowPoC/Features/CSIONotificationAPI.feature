Feature: CsioNET integration
  As a User I want to integrate properly with CsioNET

@CsioNET
Scenario Outline: 01. Verify unsuccessful sign in request to CsioNET
	Given CsioNET API is up and running
	When User sends sign in request to CsioNET with following data
		| CommandType | CSIOnetID | CSIOnetPassword |
		| <comm>      | <login>   | <pass>          |
	Then CsioNET system responses with proper error '<message>'

	Examples:
		| comm    | login                         | pass      | message                     |
		| SignIn  | avanade@vendor.edi.csio.comX  | r49M5VTT  | Failed to sign in this user |
		| SignIn  | avanade@vendor.edi.csio.com   | X49M5VTT  | Failed to sign in this user |

@CsioNET
Scenario Outline: 02. Verify successful sign in request to CsioNET
	Given CsioNET API is up and running
	When User sends sign in request to CsioNET with following data
		| CommandType | CSIOnetID | CSIOnetPassword |
		| <comm>      | <login>   | <pass>          |
	Then CsioNET sessionID is sent back by the system

	Examples:
		| comm   | login                           | pass         |
		| SignIn | dev_avanade@vendor.edi.csio.com | !F6sxL0v10@4 |

@CsioNET
Scenario Outline: 03. Get list of messages from CsioNET
	Given CsioNET API is up and running
	When Users sends request to get CsioNET messages with following data
		| FromDateTime | ToDateTime | Page   | PageSize |
		| <from>       | <to>       | <page> | <items>  |
	Then List of CsioNET messages is sent

	Examples:
		| from                   | to                     | page | items |
		| 2018-01-15 00:00:00 AM | 2018-01-20 11:59:59 PM | 1    | 10    |

@CsioNET
Scenario Outline: 04. Get single message from CsioNET
	Given CsioNET API is up and running
	When User sends request to get '<no>' message from obtained list
	Then Message details are sent by CsioNET system

	Examples:
		| no    |
		| 1     |

@CsioNET
Scenario: 05. Verify successful logout request from CsioNET
	Given CsioNET API is up and running
	When User logs out from CsioNET
	Then CsioNET sessionID is closed

#Scenario Outline: Sent notification message to CsioNET
#    Given CsioNET API is up and running
#    When User sends notification message to CsioNET with following data
#      | Policy Number   | <policy>  |
#      | Effective Date  | <effDate> |
#      | Expiration Date | <expDate> |
#      | Email           | <email>   |
#    Then Message is successfully delivered to CsioNET system
#
#    Examples:
#      | policy      | effDate    | expDate    | email                     |
#      | POL123461   | 2017-07-15 | 2018-07-15 | b.sternalski@avanade.com  |