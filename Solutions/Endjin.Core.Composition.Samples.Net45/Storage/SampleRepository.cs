namespace Endjin.Core.Composition.Samples.Net45.Storage
{
    using Endjin.Core.Composition.Samples.Net45.Contracts;

    public class SampleRepository : IRepository
    {
        public string GetMessage()
        {
            return "Hello, world!";
        }
    }
}