using System;

namespace Endjin.Core.Composition.Contracts
{
    public interface IContentFactory
    {
        void RegisterContentFor(Type instanceType, string contentType);
    }

    public interface IContentFactory<T> : IContentFactory
    {
        T GetContentFor(string contentType);

        void RegisterContent(string contentType, T content);

        void RegisterContentFor<TInstance>(string contentType) where TInstance : T;
    }
}