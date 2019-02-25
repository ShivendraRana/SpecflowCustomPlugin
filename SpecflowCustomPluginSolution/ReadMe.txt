This custom plugin allows user to create tags that can be used within specflow feature file 

1) Timeout attrubute
usage: @Timeout: millisecond
Using "@Timeout: milliseconds" above any scenario of a specflow feature file would make this scenario to fail if the execution doesnot complete within the time specified in milliseconds


2) Ignore attribute
usage: Add a description(ending with semi colon) as to why you want to ignore the tests.

Adding "@Ignore:reason to ignore;" above any scenario would ignore this scenario by printing reason to ignore as specified after @Ignore. Please note the reason must end with a semi colon.

  
  