using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Endjin.Core.Composition.Samples.Mvc5.Net45.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}