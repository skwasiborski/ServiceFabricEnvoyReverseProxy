using System;
using System.Collections.Generic;
using Grpc.Core.Logging;

namespace EnvoyControlPlane
{
    public static class LoggerExtenstions
    {
        public static void Debug(this ILogger logger, FormattableString formattableString)
        {
            logger.Debug(formattableString.Format, formattableString.GetArguments());
        }

        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key,
            Func<TKey, TValue> factory)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            var newValue = factory(key);
            dictionary.Add(key, newValue);

            return newValue;
        }
    }
}