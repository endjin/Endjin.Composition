namespace Endjin.Core.Composition.Samples.WP8.Storage
{
    using Endjin.Core.Composition.Samples.WP8.Contracts;

    public class SampleRepository : IRepository
    {
        public string GetMessage()
        {
            return "Hello, world!";
        }
    }
}