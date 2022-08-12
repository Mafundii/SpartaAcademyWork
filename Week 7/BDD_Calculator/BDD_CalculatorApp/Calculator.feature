Feature: Calculator

As a user that is bad at maths,
I want a calculator,
That would do the math for me

@HappyPath
Scenario: Addition
	Given I have a calculator
	And I enter 5 and 7 in the calculator
	When I press Add
	Then The result should be 12

@HappyPath
Scenario: Subtract
	Given I have a calculator
	And I enter <input1> and <input2> in the calculator
	When I press Subtract
	Then The result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 1      | 1      | 0      |
	| 0      | 1      | -1     |
	| 1000   | 1      | 999    |

@HappyPath
Scenario: Multiply
	Given I have a calculator
	And I enter <input1> and <input2> in the calculator
	When I press Multiply
	Then The result should be <result>
	Examples:
	| input1 | input2 | result |
	| 2      | 2      | 4      |
	| 3      | 3      | 9      |
	| 12     | 2      | 24     |

@HappyPath
Scenario: Divide
	Given I have a calculator
	And I enter <input1> and <input2> in the calculator
	When I press Divide
	Then The result should be <result>
	Examples:
	| input1 | input2 | input3 |
	| 4      | 2      | 2      |
	| 10     | 5      | 2      |
	| 5      | 5      | 1      |

@Sadpath
Scenario: Divide by zero
	Given I have a calculator
	And I enter <input> and zero in the calculator
	When I press Divide
	Then An exception shopuld be thrown 
	And The exception should have message "Cannot divide by zero"
	Examples: 
	| input |
	| 4     |
	| 5     |
	| 100   |

