namespace Endjin.Core.Specs.Helpers
{
    #region Using Directives

    using SpecsFor;

    #endregion

    public abstract class SharedContext<T> : IContext<T>
    {
        public void Initialize(ISpecs<T> state)
        {
            this.Initialize((ITestStateWithContext<T>)state);
        }

        protected abstract void Initialize(ITestStateWithContext<T> state);
    }
}