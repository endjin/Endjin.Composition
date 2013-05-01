namespace Endjin.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TypeDictionaryExtensions
    {
        public static bool TryGetValueByTypeFullName<TValue>(this Dictionary<Type, TValue> dictionary, Type key, out TValue value) where TValue : class
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            var matchingDictionaryItem = dictionary.FirstOrDefault(x => x.Key.FullName == key.FullName);

            if (matchingDictionaryItem.Value != null)
            {
                value = matchingDictionaryItem.Value;
                return true;
            }

            value = null;
            return false;
        }
    }
}
