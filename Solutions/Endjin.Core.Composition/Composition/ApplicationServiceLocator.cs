namespace Endjin.Core.Composition
{
    #region Using Directives

    using Endjin.Core.Container;
    using System;
    using System.Threading.Tasks;

    #endregion Using Directives

    public class ApplicationServiceLocator
    {
        public static IContainer Container { get; private set; }

        public static bool IsInitialized
        {
            get
            {
                return Container != null;
            }
        }

        public static bool IsInitializedSuccessfully
        {
            get
            {
                return IsInitialized && Container.MisconfiguredComponents.Count == 0;
            }
        }

        public static void Initialize(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (Container != null)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.ApplicationServiceLocator_TheContainerIsAlreadyInitialized);
            }

            Container = container;
        }

        public static Task InitializeAsync(IContainer container, IBootstrapper bootstrapper)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (Container != null)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.ApplicationServiceLocator_TheContainerIsAlreadyInitialized);
            }

            Container = container;

            if (bootstrapper != null)
            {
                var task = container.InstallAsync(bootstrapper);
                return task.ContinueWith(t =>
                {
                    if (!IsInitializedSuccessfully)
                    {
                        throw new ContainerInitializationException(container);
                    }
                });
            }

            return Task.Factory.StartNew(() => { });
        }

        public static void Shutdown()
        {
            if (Container != null)
            {
                Container.Shutdown();
            }

            Container = null;
        }
    }
}