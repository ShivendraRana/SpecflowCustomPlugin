using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowCustomPluginProject
{
    [Binding]
    public class Class1
    {
        [Given(@"I have entered (.*) into the calculator")]        
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
    }
}
