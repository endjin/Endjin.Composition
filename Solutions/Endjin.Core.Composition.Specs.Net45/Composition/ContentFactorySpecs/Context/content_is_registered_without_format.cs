namespace Endjin.Core.Specs.Composition.ContentFactorySpecs.Context
{
    #region Using statements

    using Endjin.Core.Specs.Helpers;    

    #endregion

    public class content_is_registered_without_format : content_is_registered
    {
        protected override void Initialize(ITestStateWithContext<TestContentFactory> state)
        {
            this.ContentName = "WellKnownContent";
            this.ContentNameForFallback = "WellKnownContent.Extension";
            base.Initialize(state);
        }
    }
}