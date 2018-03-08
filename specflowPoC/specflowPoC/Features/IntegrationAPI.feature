Feature: API integration
  As a User I want to verify API calculations

	Scenario Outline: 01. Verify simple user Flow Induced Excitation successful calculation
		Given Application API is up and running
		When User sends API request to calculate FIE parameters with following data
			| insideDiameter | length | waterFlowRate | gasFlowRate | oilFlowRate | waterDensity | gasDensity | oilDensity | mainBranchID | gasViscosity | speedOfSound |
			| <insDiam>      | <len>  | <waterFR>     | <gasFR>     | <oilFR>     | <waterDen>   | <gasDen>   | <oilDen>   | <branchID>   | <gasVis>     | <soundSpeed> |
		Then FIE parameters are calculated

		Examples:
			| insDiam | len | waterFR | gasFR | oilFR | waterDen | gasDen | oilDen | branchID | gasVis | soundSpeed |
			| 1       | 1   | 1       | 1     | 1     | 1        | 1      | 1      | 1        | 1      | 1          |
			| 0       | 0   | 0       | 0     | 0     | 0        | 0      | 0      | 0        | 0      | 0          |
			| -1      | -1  | -1      | -1    | -1    | -1       | -1     | -1     | -1       | -1     | -1         |
			| 136     | 5   | 0.001   | 0.152 | 0     | 977      | 286    | 601    | 12       | 1      | 3800000    |
			| 136     | 5   | 0.001   | 0.153 | 0     | 977      | 285    | 601    | 12       | 1      | 3800000    |
			| 136     | 10  | 0.001   | 0.153 | 0     | 977      | 280    | 601    | 12       | 1      | 3800000    |
			| 136     | 10  | 0.001   | 0.153 | 0     | 977      | 280    | 601    | 12       | 1      | 3800000    |
			| 50      | 45  | 0.09    | 0.15  | 0.015 | 794      | 1500   | 1500   | 20       | 1.5    | 4200000    |

	Scenario Outline: 02. Verify simple user Flow Induced Turbulence successful calculation
		Given Application API is up and running
		When User sends API request to calculate FIT parameters with following data
			| waterFlowRate | gasFlowRate | oilFlowRate | mainPipeOutsideDiameter | mainPipeInsideDiameter | mainPipeSpanLength | waterDensity | gasDensity | oilDensity | gasViscosity |
			| <waterFR>     | <gasFR>     | <oilFR>     | <pipeOutsideDiam>       | <pipeInsideDiam>       | <pipeLength>       | <waterDen>   | <gasDen>   | <oilDen>   | <gasVis>     |
		Then FIT parameters are calculated

		Examples:
			| waterFR | gasFR | oilFR | pipeOutsideDiam | pipeInsideDiam | pipeLength | waterDen | gasDen | oilDen | gasVis |
			| 1       | 1     | 1     | 1               | 1              | 1          | 1        | 1      | 1      | 1      |
			| 0       | 0     | 0     | 0               | 0              | 0          | 0        | 0      | 0      | 0      |
			| -1      | -1    | -1    | -1              | -1             | -1         | -1       | -1     | -1     | -1     |
			| 0.001   | 0.152 | 0     | 219             | 136            | 5          | 977      | 286    | 601    | 3      |
			| 0.001   | 0.162 | 0     | 219             | 136            | 5          | 977      | 276    | 601    | 3      |
			| 0.001   | 0.172 | 0     | 219             | 136            | 5          | 977      | 266    | 601    | 3      |
			| 0.001   | 0.182 | 0     | 219             | 136            | 5          | 977      | 256    | 601    | 3      |
			| 0.001   | 0.192 | 0     | 219             | 136            | 5          | 977      | 246    | 601    | 3      |
			| 0.001   | 0.200 | 0     | 94              | 12             | 1000       | 977      | 246    | 601    | 3      |

	Scenario Outline: 03. User is able to create new project
		Given Application API is up and running
		When User creates project with given data
			| pvtDataId   | name   | description | numberOfCases | equipments  | subEquipments  |
			| <pvtDataId> | <name> | <desc>      | <caseNo>      | <noOfEquip> | <noOfSubEquip> |
		Then Project is created

		Examples:
			| pvtDataId | name     | desc             | caseNo | noOfEquip | noOfSubEquip |
			| 0         | apiTest1 | some description | 10     | 2         | 2            |

	Scenario: 04. User is able to get list of created projects
		Given Application API is up and running
		When User sends API request to get list of created projects
		Then List of projects is returned

	Scenario: 05. User is able to get details of given project
		Given Application API is up and running
		When User sends API request to get project details
		Then Project details are returned
		Then Project has 2 added equipments

	Scenario Outline: 06. User is able to update aspects details of given project
		Given Application API is up and running
		When User send API request to update aspects details of given project
			| maxKineticEnergy | maxKineticEnergyComment | module2_7Enabled | module2_7Comment | module2_9Enabled | module2_9Comment | module2_8Enabled | module2_8Comment | module4Enabled | module4Comment |
			| <maxKinEnergy>   | <maxKinComment>         | <mod27>          | <mod27_comment>  | <mod29>          | <mod29_comment>  | <mod28>          | <mod28_comment>  | <mod4>         | <mod4_comment> |
		Then Aspects details are updated

		Examples:
			| maxKinEnergy | maxKinComment            | mod27 | mod27_comment | mod29 | mod29_comment | mod28 | mod28_comment | mod4  | mod4_comment |
			| 1000         | module should be checked | false |               | false |               | false |               | false |              |

	Scenario: 07. User is able to get aspects details of given project
		Given Application API is up and running
		When User send API request to get aspects details of given project
		Then Aspects details are returned with Max kinetic energy set to 1000.0

	Scenario: 08. User is able to delete given project
		Given Application API is up and running
		When User sends API request to delete given project
		Then Project is deleted

	Scenario Outline: 09. Wrong file upload verification
		Given Application API is up and running
		When User sends API request to upload <fileName> file
		Then Proper error message <message> is returned

		Examples:
			| fileName       | message                  |
			| alpaca26kb.jpg | Invalid PVT file format. |

	Scenario Outline: 10. User is able to upload PVT file
		Given Application API is up and running
		When User sends API request to upload <fileName> file
		Then File is uploaded

		Examples:
			| fileName        |
			| PVT_correct.tab |