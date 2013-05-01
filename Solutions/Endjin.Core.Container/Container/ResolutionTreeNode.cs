namespace Endjin.Core.Container
{
    using System.Collections.Generic;

    public class ResolutionTreeNode
    {
        public string Component { get; set; }

        public List<ResolutionTreeNode> Children { get; set; }

        public bool IsInError { get; set; }
    }
}