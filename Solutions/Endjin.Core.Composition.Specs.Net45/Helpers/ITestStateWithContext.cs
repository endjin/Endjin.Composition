namespace Endjin.Core.Specs.Helpers
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using SpecsFor;

    #endregion

    public interface ITestStateWithContext<T> : ISpecs<T>
    {
        TContextType GetContext<TContextType>() where TContextType : IContext<T>;

        TContextType GetContext<TContextType>(Func<IEnumerable<TContextType>, TContextType> search) where TContextType : IContext<T>;
    }
}