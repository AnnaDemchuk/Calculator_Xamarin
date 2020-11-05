Feature: Functions
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
Given Start app

@add
Scenario Outline: Add two numbers
	When the two numbers  "<first>" and "<second>" are added
	Then the result should be "<result>"

@integer	
	Examples: 
	 | first | second | result |
	 |  33   |   5    |   38   |
	 |   0   |   4    |    4   |
	 |   0   |   0    |    0   |
	 |  20   |   5    |   25   |
	 |  -4   |   5    |    1   |
	 |  21   |  -5    |   16   |
	 |  -3   |  -5    |   -8   |
	 |   111111111  |   222222222    |   333333333   |

@double	
	Examples: 
	 | first  | second | result |
	 |   1,4  |   5    |  6,6   |
	 |   2    |   2,4  |  4,4   |
	 |   3,1  |   2,1  |  5,2   |
	 |   0,1  |   2,1  |  2,2   |	
	 |   3,2  |   0,1  |  3,3   |
	 |   3,02 |   1,1  |  3,12  |
     |   5,2  |   0,01 |  5,21  |


@minus
Scenario Outline: Minus two numbers
	When the two numbers  "<first>" and "<second>" are minused
	Then the result should be "<result>"

@integer	
	Examples: 
	 | first | second | result |
	 |   0   |   0    |   0    |
	 |   0   |   4    |  -4    |
	 |   5   |   0    |   5    |
	 |   5   |   4    |   1    |
	 |   5   |   8    |  -3    |
	 |   6   |   6    |   0    |
 	 |  50   |   5    |  45    | 
	 |  -5   |   4    |  -9    |
	 |   3   |  -2    |   5    |
     |  -7   |  -1    |   6    |
     |  -1   |  -1    |   0    |

@double	
	Examples: 
	 | first  | second | result |
	 |   3    |   1,3  |  1,7   |
	 |   5,5  |   4    |  1,5   |
	 |   4    |   0,4  |  3,6   |
	 |   0,1  |   3    | -2,9   |	
	 |   0,03 |   3    | -2,97  |
	 |   2    |   2,01 |  0,01  |

	
 