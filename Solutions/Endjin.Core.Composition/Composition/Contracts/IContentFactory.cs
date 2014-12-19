namespace Endjin.Core.Composition.Contracts
{
    #region Using Directives 

    

    #endregion

    public interface IContentFactory<T>
    {
        void RegisterContentFor<TInstance>(string contentType) where TInstance : T;
        void RegisterContent(string contentType, T content);
        T GetContentFor(string contentType);
    }
}