using System;
using System.Collections;
using System.Linq;
using Autofac;

namespace Kitty.Core.Extensions
{
    public static class TypeExtensions
    {
        public static string GetCollectionItemType(this Type type)
        {
            if (type.IsAssignableTo<IEnumerable>())
            {
                return type.GenericTypeArguments.Single().Name;
            }
            return type.Name;
        }
    }
}