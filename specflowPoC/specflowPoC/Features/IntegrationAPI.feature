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