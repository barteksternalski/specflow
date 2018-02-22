Feature: API integration
  As a User I want to verify API calculations

	Scenario Outline: 01. Verify simple user Flow Induced Excitation calculation
		Given Application API is up and running
		When User sends API request to calculate FIE parameters with following data
			| insideDiameter | length | waterFlowRate | gasFlowRate | oilFlowRate | waterDensity | gasDensity | oilDensity | mainBranchID | gasViscosity | speedOfSound |
			| <insDiam>      | <len>  | <waterFR>     | <gasFR>     | <oilFR>     | <waterDen>   | <gasDen>   | <oilDen>   | <branchID>   | <gasVis>     | <soundSpeed> |
		Then FIE parameters are calculated

		Examples:
			| insDiam | len | waterFR | gasFR | oilFR | waterDen | gasDen | oilDen | branchID | gasVis | soundSpeed |
			| 1       | 1   | 1       | 1     | 1     | 1        | 1      | 1      | 1        | 1      | 1          |

	Scenario Outline: 02. Verify simple user Flow Induced Turbulence calculation
		Given Application API is up and running
		When User sends API request to calculate FIT parameters with following data
			| waterFlowRate | gasFlowRate | oilFlowRate | mainPipeOutsideDiameter | mainPipeInsideDiameter | mainPipeSpanLength | waterDensity | gasDensity | oilDensity | gasViscosity |
			| <waterFR>     | <gasFR>     | <oilFR>     | <pipeOutsideDiam>       | <pipeInsideDiam>       | <pipeLength>       | <waterDen>   | <gasDen>   | <oilDen>   | <gasVis>     |
		Then FIT parameters are calculated

		Examples:
			| waterFR | gasFR | oilFR | pipeOutsideDiam | pipeInsideDiam | pipeLength | waterDen | gasDen | oilDen | gasVis |
			| 1       | 1     | 1     | 1               | 1              | 1          | 1        | 1      | 1      | 1      |
