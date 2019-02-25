1. Add the plugins tag to the App.config file with the relative path
<plugins>
    <add name="CustomPlugin" path="..\SED\Aspire.Administration\packages\Specflow.CustomPlugin" type="Generator" />
 </plugins>
 
2. Tags or Plugins

a.Timeout
  usage: Timeout:milliseconds
b. Ignore
usage: Add a description(ending with semi colon) as to why you want to ignore the tests.
@Ignore: This is ignores scenario;
  
  