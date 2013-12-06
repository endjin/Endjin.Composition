namespace Endjin.Core.Specs.Composition.Context
{
    #region Using statements

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
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
            container.SetupGet(c => c.MisconfiguredComponents).Returns(new ReadOnlyCollection<ComponentRegistration>(new List<ComponentRegistration>()));
            container.Setup(c => c.InstallAsync(It.IsAny<IBootstrapper>())).Returns(CreateTask() );
            Container = container;
        }

        private Task CreateTask()
        {
            var task = new Task(() => { });
            task.RunSynchronously();
            return task;
        }
    }
}