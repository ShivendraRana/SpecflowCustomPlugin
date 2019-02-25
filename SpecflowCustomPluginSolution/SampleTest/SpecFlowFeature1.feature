Feature: SpecFlowFeature1
In order to avoid silly mistakes
As a math idiot
I want to be told the sum of two numbers

  @Timeout:1000  
  @Ignore:Enterprise Integration Service - ExamScriptService, ExamAuditService;
  @HTMLDelivery
  Scenario: TC66383: [AT] Warning message should appear on clicks of Continue button 

  @HTMLDelivery
  @ignore:this is ignore;
  @Timeout:555
	Scenario Outline: TC61751: Validate the Cancel functionality of Void dialog
	Given he is on Void dialog for a Mock Exam Name 2
	And he selects <Value> from void exam reason dropdown
	When he clicks on Cancel Button 
	Then Void Dialog should be closed
	And Mock Exam Name 2 should display on the grid
	Examples:
	| Value               | Key |
	| Withdrawn           | 1   |
	| Partially Completed | 2   |
	#| Someting            | hi  |


  @Ignore
  @Shiv
  @Timeout:555
  Scenario: TC61752: Validate the Cancel functionality of Void dialog
	Given he is on Void dialog for a Mock Exam Name 2

	@ignore
	@Shiva
	@Timeout:555
	  Scenario: TC61753: Validate the Cancel functionality of Void dialog
	Given he is on Void dialog for a Mock Exam Name 2

	@ignore
	@Shivendra
	@Timeout:555
	  Scenario: TC61754: Validate the Cancel functionality of Void dialog
	Given he is on Void dialog for a Mock Exam Name 2

		@ignore:this is ignore;
	@Shivendra
	@Timeout:555
	  Scenario: TC61755: Validate the Cancel functionality of Void dialog
	Given he is on Void dialog for a Mock Exam Name 2

