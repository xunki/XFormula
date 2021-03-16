using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace XFormula
{
    internal static class TypeExtensions
    {
        #region 类型转换
        public static int AsInt(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out var result) ? result : defaultValue;
        }

        public static decimal AsDecimal(this string value, decimal defaultValue = 0M)
        {
            return decimal.TryParse(value, out var result) ? result : defaultValue;
        }

        public static float AsFloat(this string value, float defaultValue = 0.0F)
        {
            return float.TryParse(value, out var result) ? result : defaultValue;
        }

        public static DateTime AsDateTime(this string value, DateTime defaultValue = new DateTime(),
            string format = null)
        {
            if (format == null)
                return DateTime.TryParse(value, out var result) ? result : defaultValue;
            else
                return DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.None,
                    out var result)
                    ? result
                    : defaultValue;
        }

        public static bool AsBool(this string value, bool defaultValue = false)
        {
            return bool.TryParse(value, out var result) ? result : defaultValue;
        }

        public static string SafeTrim(this string str, params char[] trimChars)
        {
            return str == null ? "" : str.Trim(trimChars);
        }

        public static string SafeString(this object str)
        {
            return str == null ? "" : str.ToString();
        }

        public static int AsInt(this bool value)
        {
            return value ? 1 : 0;
        }

        public static string AsIntString(this bool value)
        {
            return value ? "1" : "0";
        }

        public static CancellationToken AsCancellationToken(this object value)
        {
            return (value as CancellationTokenSource)?.Token ?? CancellationToken.None;
        }

        public static async Task<List<T>> AwaitToList<T>(this Task<IEnumerable<T>> task)
        {
            var source = await task;
            return (source == null || source is List<T>) ? (List<T>) source : source.ToList();
        }
        #endregion

        #region 类型检查
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsBlank(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotBlank(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsBool(this string value)
        {
            return bool.TryParse(value, out _);
        }

        public static bool IsInt(this string value)
        {
            return int.TryParse(value, out _);
        }

        public static bool IsDecimal(this string value)
        {
            return decimal.TryParse(value, out _);
        }

        public static bool IsFloat(this string value)
        {
            return float.TryParse(value, out _);
        }

        public static bool IsDateTime(this string value, string format = null)
        {
            return format == null
                ? DateTime.TryParse(value, out _)
                : DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out _);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> value)
        {
            return value == null || !value.Any();
        }

        public static bool IsNotEmpty<T>(this IEnumerable<T> value)
        {
            return !IsEmpty(value);
        }
        #endregion

        #region 类型扩展
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static TR GetValueOrDefault<T, TR>(this IReadOnlyDictionary<T, TR> dict, T key,
            TR defaultValue = default)
        {
            if (dict == null)
                return defaultValue;

            return dict.TryGetValue(key, out var value) ? value : defaultValue;
        }
        #endregion
    }
}