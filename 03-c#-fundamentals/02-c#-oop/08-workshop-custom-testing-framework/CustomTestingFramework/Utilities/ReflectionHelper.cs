namespace CustomTestingFramework.Utilities
{
    using System;
    using System.Reflection;

    public static class ReflectionHelper
    {
        public static bool HasAttribute<T>(this MemberInfo memberInfo) where T : Attribute
        {
            var hasAttribute = memberInfo.GetCustomAttribute<T>() != null;

            return hasAttribute;
        }
    }
}