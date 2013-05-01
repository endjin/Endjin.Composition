namespace Endjin.Core.Specs.Helpers
{
    using SpecsFor;

    public abstract class SharedContext<T> : IContext<T>
    {
        public void Initialize(ITestState<T> state)
        {
            this.Initialize((ITestStateWithContext<T>)state);
        }

        protected abstract void Initialize(ITestStateWithContext<T> state);
    }
}