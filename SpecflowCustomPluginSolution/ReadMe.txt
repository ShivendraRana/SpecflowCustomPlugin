This custom plugin allows user to create tags that can be used within specflow feature file 

1) Timeout attrubute
usage: @Timeout: millisecond
Using "@Timeout: milliseconds" above any scenario of a specflow feature file would make this scenario to fail if the execution doesnot complete within the time specified in milliseconds


2) Ignore attribute
usage: Add a description(ending with semi colon) as to why you want to ignore the tests.

Adding "@Ignore:reason to ignore;" above any scenario would ignore this scenario by printing reason to ignore as specified after @Ignore. Please note the reason must end with a semi colon.


How to use:
1) Compile this project and save "CustomPlugin.SpecflowPlugin.dll" to your disk.
2) In order to use this plugin please add the below code in the app.config file. The path location should be the location of "CustomPlugin.SpecflowPlugin.dll".




<specFlow>

  <plugins>

    <add name="CustomPlugin" path="..\..\..\packages\BTL.SpecFlow.CustomPlugin.1.0.4\lib\" type="Generator" />

  </plugins>

</specFlow>


