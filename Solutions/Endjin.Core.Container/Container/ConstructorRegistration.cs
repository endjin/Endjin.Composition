namespace Endjin.Core.Container
{
    using System.Reflection;

    public class ConstructorRegistration
    {
        public ConstructorInfo Constructor { get; set; }

        public ParameterInfo[] Parameters { get; set; }
    }
}