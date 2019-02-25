using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace SpecflowCustomPluginProject.SpecFlowPlugin
{
    public class AttributeGeneratorProvider : IUnitTestGeneratorProvider
    {
        private readonly IUnitTestGeneratorProvider baseGeneratorProvider;
        private readonly CodeDomHelper codeDomHelper;
        private const string NUnitFrameworkNamespace = "NUnit.Framework";
        private const string TIMEOUT_TAG_PREFIX = "Timeout:";
        private const string IGNORE_TAG_PREFIX = "Ignore:";
        private const string CATEOGRY_WITH_SEMICOLON = ";";
        private const string CATEOGRY_WITH_COLON = ":";
        bool flagForCategoryWithSemicolon = false;
        private const string CATEGORY_ATTR = "NUnit.Framework.CategoryAttribute";



        public AttributeGeneratorProvider(CodeDomHelper codeDomHelper, SpecFlowProjectConfiguration configuration)
        {
            string runtimeUnitTestProvider = configuration.SpecFlowConfiguration.UnitTestProvider;
            switch (runtimeUnitTestProvider.ToUpper(CultureInfo.InvariantCulture))
            {
                case "NUNIT":
                    baseGeneratorProvider = new NUnit3TestGeneratorProvider(codeDomHelper);
                    break;
                default:
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The specified unit test provider '{0}' is not usable with NUnit wrapper",
                        runtimeUnitTestProvider));
            }

            this.codeDomHelper = codeDomHelper;
        }

        public UnitTestGeneratorTraits GetTraits()
        {
            return baseGeneratorProvider.GetTraits();
        }

        public void SetTestClass(TestClassGenerationContext generationContext, string featureTitle,
            string featureDescription)
        {
            baseGeneratorProvider.SetTestClass(generationContext, featureTitle, featureDescription);
        }

        public void SetTestClassCategories(TestClassGenerationContext generationContext,
            IEnumerable<string> featureCategories)
        {
            baseGeneratorProvider.SetTestClassCategories(generationContext, featureCategories);
        }

        public void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            baseGeneratorProvider.FinalizeTestClass(generationContext);
        }

        public void SetTestClassInitializeMethod(TestClassGenerationContext generationContext)
        {
            baseGeneratorProvider.SetTestClassInitializeMethod(generationContext);
        }

        public void SetTestClassCleanupMethod(TestClassGenerationContext generationContext)
        {
            baseGeneratorProvider.SetTestClassCleanupMethod(generationContext);
        }

        public void SetTestInitializeMethod(TestClassGenerationContext generationContext)
        {
            baseGeneratorProvider.SetTestInitializeMethod(generationContext);
        }

        public void SetTestCleanupMethod(TestClassGenerationContext generationContext)
        {
            baseGeneratorProvider.SetTestCleanupMethod(generationContext);
        }

        public void SetTestMethod(TestClassGenerationContext generationContext, CodeMemberMethod testMethod,
            string scenarioTitle)
        {
            baseGeneratorProvider.SetTestMethod(generationContext, testMethod, scenarioTitle);
        }

        public void SetTestMethodCategories(TestClassGenerationContext generationContext, CodeMemberMethod testMethod,
            IEnumerable<string> scenarioCategories)
        {
            List<string> ignoreParameters = new List<string>();
            foreach (string category in scenarioCategories)
            {
                int IndexOfAttributeIdentifier = category.IndexOf(CATEOGRY_WITH_COLON);
                int IndexOfCategoryWithSemicolon = category.IndexOf(CATEOGRY_WITH_SEMICOLON);

                if (IndexOfAttributeIdentifier > 0)
                {
                    if (category.StartsWith(TIMEOUT_TAG_PREFIX))
                    {
                        string TimeoutAttributeIdentifier = category.Substring(0, IndexOfAttributeIdentifier);
                        string TimeoutAttributeParameters = category.Substring(IndexOfAttributeIdentifier + 1);
                        AddNUnitAttributes(testMethod, TimeoutAttributeIdentifier, TimeoutAttributeParameters);
                    }
                    else 
                    {
                        string IgnoreAttributeFirstParameter = category.Substring(IndexOfAttributeIdentifier + 1);
                        ignoreParameters.Add(IgnoreAttributeFirstParameter);
                        flagForCategoryWithSemicolon = true;
                    }
                }
                else if (flagForCategoryWithSemicolon)
                {
                    if (category.Contains(CATEOGRY_WITH_SEMICOLON))
                    {
                        string CategoryAttributeWithoutSemicolon = category.Substring(0, IndexOfCategoryWithSemicolon);
                        ignoreParameters.Add(CategoryAttributeWithoutSemicolon);
                        flagForCategoryWithSemicolon = false;
                    }
                    else
                    {
                        ignoreParameters.Add(category);
                    }
                }
                else
                {
                    codeDomHelper.AddAttribute(testMethod, CATEGORY_ATTR, category);
                }
            }
            string combindedIgnoreParameter = string.Join(" ", ignoreParameters.ToArray());
            if (!String.IsNullOrWhiteSpace(combindedIgnoreParameter))
            {
                AddNUnitAttributes(testMethod, "Ignore", combindedIgnoreParameter);
            }
        }

        public void SetRowTest(TestClassGenerationContext generationContext, CodeMemberMethod testMethod,
            string scenarioTitle)
        {
            baseGeneratorProvider.SetRowTest(generationContext, testMethod, scenarioTitle);
        }

        public void SetRow(TestClassGenerationContext generationContext, CodeMemberMethod testMethod,
            IEnumerable<string> arguments,
            IEnumerable<string> tags, bool isIgnored)
        {
            baseGeneratorProvider.SetRow(generationContext, testMethod, arguments, tags, isIgnored);
        }

        public void SetTestMethodAsRow(TestClassGenerationContext generationContext, CodeMemberMethod testMethod,
            string scenarioTitle,
            string exampleSetName, string variantName, IEnumerable<KeyValuePair<string, string>> arguments)
        {
            baseGeneratorProvider.SetTestMethodAsRow(generationContext, testMethod, scenarioTitle, exampleSetName,
                variantName, arguments);
        }

        private void AddNUnitAttributes(CodeMemberMethod testMethod, string NUnitAttributeIdentifier, string NUnitAttributeValues)
        {
            if (MatchesIdentifier(NUnitAttributeIdentifier, AttributeNames.NUnitTimeout))
            {
                codeDomHelper.AddAttribute(testMethod, AttributeNames.NUnitTimeout, Int32.Parse(NUnitAttributeValues));
            }
            if (MatchesIdentifier(NUnitAttributeIdentifier, AttributeNames.NUnitIgnore))
            {
                codeDomHelper.AddAttribute(testMethod, AttributeNames.NUnitIgnore, NUnitAttributeValues);
            }
        }

        private static bool MatchesIdentifier(string NUnitAttributeIdentifier, string NUnitAttributeName)
        {
            return NUnitAttributeIdentifier == NUnitAttributeName || NUnitAttributeIdentifier == AttributeNames.RemovePrefixAndSuffix(NUnitAttributeName);
        }

        public void SetTestClassParallelize(TestClassGenerationContext generationContext)
        {
            baseGeneratorProvider.SetTestClassParallelize(generationContext);
        }

        public void SetTestClassIgnore(TestClassGenerationContext generationContext)
        {
            baseGeneratorProvider.SetTestClassIgnore(generationContext);
        }

        public void SetTestMethodIgnore(TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            baseGeneratorProvider.SetTestMethodIgnore(generationContext, testMethod);
        }
    }
}
