using System.CodeDom;
using TechTalk.SpecFlow.Utils;

namespace CustomPlugin.SpecflowPlugin
{
    public interface AttributeProvider 
    {
        CodeAttributeDeclaration ProvideAttribute(CodeDomHelper codeDomHelper, CodeMemberMethod method,
            string AttributeIdentifier,
            string AttributeParameters);
    }
}
