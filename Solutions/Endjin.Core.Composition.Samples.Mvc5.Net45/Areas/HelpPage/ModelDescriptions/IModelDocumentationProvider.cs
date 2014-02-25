using System;
using System.Reflection;

namespace Endjin.Core.Composition.Samples.Mvc5.Net45.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}