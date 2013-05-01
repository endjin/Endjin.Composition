namespace Endjin.Core.Specs.Composition.ContentFactorySpecs.Context
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.Specs.Composition.Context;
    using Endjin.Core.Specs.Helpers;

    using SpecsFor;

    #endregion

    public class content_is_registered : a_container_is_available<TestContentFactory>
    {
        public string ContentName { get; set; }

        public string ContentNameForFallback { get; set; }

        public object Content { get; set; }

        protected override void Initialize(ITestStateWithContext<TestContentFactory> state)
        {
            base.Initialize(state);

            ApplicationServiceLocator.Initialize(Container.Object);

            this.ContentName = this.ContentName ?? "WellKnownContent+format";
            this.ContentNameForFallback = this.ContentNameForFallback ?? "WellKnownContent.Extension+format";
            this.Content = new ExampleContent();
            state.SUT.RegisterContentFor<ExampleContent>(this.ContentName);
            Container.Setup(c => c.Resolve<object>(this.ContentName)).Returns(this.Content);
        }
    }
}