namespace Endjin.Core.Composition.Samples.Mvc5.Net45.Storage
{
    using Endjin.Core.Composition.Samples.Mvc5.Net45.Contracts;

    public class SampleRepository : IRepository
    {
        public string GetMessage()
        {
            return "Hello, world!";
        }
    }
}