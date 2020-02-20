using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RulesFakes
{
    public static class IEnumerableExtensions
    {
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return (collection == null) || (!collection.Any());
        }
    }
}