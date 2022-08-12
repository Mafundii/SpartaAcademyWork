Feature: Calculator

As a Spartan who is crap at maths,
I want a calculator that takes numbers,
So I can do maths on 'em

@HappyPath
Scenario: Addition
	Given I have a calculator
	And I enter 5 and 2 in the calculator
	When I press add
	Then the result should be 7

@HappyPath
Scenario: Subtract
	Given I have a calculator
	And I enter <input1> and <input2> in the calculator
	When I press subtract
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 1      | 1      | 0      |
	| 0      | 1      | -1     |
	| 1000   | 1      | 999    |
