namespace Endjin.Core.Composition
{
    using System;

    public class Marker
    {
        public static Type Type
        {
            get
            {
                return typeof(Marker);
            }
        }
    }
}