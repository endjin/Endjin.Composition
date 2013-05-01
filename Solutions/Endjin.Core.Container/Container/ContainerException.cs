namespace Endjin.Core.Container
{
    using System;

    public class ContainerException : Exception
    {
        public ContainerException(ResolutionTreeNode resolutionTree, string message) : base(message)
        {
            this.ResolutionTree = resolutionTree;
        }

        public ResolutionTreeNode ResolutionTree { get; private set; }
    }
}