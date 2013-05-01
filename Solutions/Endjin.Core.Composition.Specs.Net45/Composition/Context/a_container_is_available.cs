namespace Endjin.Core.Specs.Composition.Context
{
    #region Using statements

    using Endjin.Core.Container;
    using Endjin.Core.Specs.Helpers;

    using Moq;

    #endregion

    public class a_container_is_available<T> : SharedContext<T>
    {
        public static Mock<IContainer> Container { get; set; }

        protected override void Initialize(ITestStateWithContext<T> state)
        {
            var container = state.GetMockFor<IContainer>();
            Container = container;
        }
    }
}