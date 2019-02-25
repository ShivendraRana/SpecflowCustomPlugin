using System.Collections.Generic;


namespace SpecflowCustomPluginProject
{
    public static class AttributeNames
    {
        public static readonly string NUnitAttributePrefix = "NUnit.Framework.";
        public static readonly string AttributeSuffix = "Attribute";
        public static readonly string NUnitTimeout = NUnitAttributePrefix + "Timeout" + AttributeSuffix;
        public static readonly string NUnitIgnore = NUnitAttributePrefix + "Ignore" + AttributeSuffix;

        public static IEnumerable<string> All()
        {
            yield return NUnitTimeout;
            yield return NUnitIgnore;
        }

        public static string RemovePrefixAndSuffix(string attributeName)
        {
            return attributeName.Replace(NUnitAttributePrefix, "").Replace(AttributeSuffix, "");
        }
    }
}
