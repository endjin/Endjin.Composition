namespace Endjin.Core.Composition
{
    #region Using Directives

    using Endjin.Core.Composition.Contracts;
    using Endjin.Core.Container;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    #endregion Using Directives

    public abstract class ContentFactory<T> : IContentFactory<T> where T : class
    {
        private readonly HashSet<string> registeredTypes;

        protected ContentFactory()
        {
            this.registeredTypes = new HashSet<string>();
        }

        public virtual T GetContentFor(string contentType)
        {
            return this.GetContentForCore(contentType);
        }

        public void RegisterContent(string contentType, T content)
        {
            if (this.registeredTypes.Contains(contentType))
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        ExceptionMessages.ContentFactory_ContentAlreadyRegistered,
                        contentType),
                    "contentType");
            }

            this.registeredTypes.Add(contentType);
            ApplicationServiceLocator.Container.Register(
                Component.For<T>().ImplementedBy(content).Named(contentType).AsSingleton());
        }

        public virtual void RegisterContentFor<TInstance>(string contentType) where TInstance : T
        {
            if (this.registeredTypes.Contains(contentType))
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        ExceptionMessages.ContentFactory_ContentAlreadyRegistered,
                        contentType),
                    "contentType");
            }

            this.registeredTypes.Add(contentType);
            ApplicationServiceLocator.Container.Register(
                Component.For<T>().ImplementedBy<TInstance>().Named(contentType).AsTransient());
        }

        public virtual void RegisterContentFor(Type instanceType, string contentType)
        {
            if (this.registeredTypes.Contains(contentType))
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        ExceptionMessages.ContentFactory_ContentAlreadyRegistered,
                        contentType),
                    "contentType");
            }

            this.registeredTypes.Add(contentType);
            ApplicationServiceLocator.Container.Register(
                Component.For<T>().ImplementedByType(instanceType).Named(contentType).AsTransient());
        }

        private T GetContentForCore(string contentType)
        {
            if (this.registeredTypes.Contains(contentType))
            {
                return ApplicationServiceLocator.Container.Resolve<T>(contentType);
            }

            int indexOfPlusSuffix = contentType.LastIndexOf('+');
            string suffix = string.Empty;

            if (indexOfPlusSuffix >= 0)
            {
                suffix = contentType.Substring(indexOfPlusSuffix);
            }

            int indexOfLastDot = contentType.LastIndexOf('.');
            if (indexOfLastDot > 0)
            {
                return this.GetContentForCore(contentType.Substring(0, indexOfLastDot) + suffix);
            }

            return default(T);
        }
    }
}