using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

namespace SpecflowCustomPluginProject.SpecFlowPlugin
{
    public class GeneratorCustomPlugin : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters)
        {
            generatorPluginEvents.CustomizeDependencies += (sender, args) =>
            {
                args.ObjectContainer.RegisterTypeAs<AttributeGeneratorProvider, IUnitTestGeneratorProvider>();
            };
        }
    }
}
