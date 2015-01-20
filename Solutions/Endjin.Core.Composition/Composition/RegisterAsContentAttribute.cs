namespace Endjin.Core.Composition
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RegisterAsContentAttribute : Attribute
    {
        public Type ContentFactoryInterface { get; set; }

        public string ContentType { get; set; }
    }
}