using System;

namespace Endjin.Core.Composition.Contracts
{
    public interface IContentFactory<T>
    {
        T GetContentFor(string contentType);

        void RegisterContent(string contentType, T content);

        void RegisterContentFor<TInstance>(string contentType) where TInstance : T;

        void RegisterContentFor(Type instanceType, string contentType);
    }
}