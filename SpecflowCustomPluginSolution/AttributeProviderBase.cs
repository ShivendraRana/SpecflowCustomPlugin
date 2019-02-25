using CustomPlugin.SpecflowPlugin;
using System.CodeDom;
using TechTalk.SpecFlow.Utils;

namespace SpecflowCustomPluginProject
{
    internal abstract class AttributeProviderBase : AttributeProvider
    {
        public CodeAttributeDeclaration ProvideAttribute(CodeDomHelper codeDomHelper, CodeMemberMethod method,
    string AttributeIdentifier,
    string AttributeParameters)
        {
            if (AttributeIdentifier == AttributeName())
            {
                return InternalProvideAttribute(codeDomHelper, method, AttributeParameters);
            }

            return null;
        }

        protected abstract CodeAttributeDeclaration InternalProvideAttribute(CodeDomHelper codeDomHelper,
            CodeMemberMethod method, string AttributeParameters);

        protected abstract string AttributeName();
    }
}
