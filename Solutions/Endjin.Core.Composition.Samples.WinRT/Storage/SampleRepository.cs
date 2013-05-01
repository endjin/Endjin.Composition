namespace Endjin.Core.Composition.Samples.WinRT.Storage
{
    public class SampleRepository  : IRepository
    {
        public string GetMessage()
        {
            return "Hello, world!";
        }
    }
}