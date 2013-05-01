namespace Endjin.Core.Composition.Samples.Net40.Storage
{
    using Endjin.Core.Composition.Samples.Net40.Contracts;

    public class SampleRepository : IRepository
    {
        public string GetMessage()
        {
            return "Hello, world!";
        }
    }
}