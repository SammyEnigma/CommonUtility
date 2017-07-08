using System;
using System.Linq;
using System.Reflection;

namespace CommonUtility.Convert
{
    public class Converter
    {
        /// <summary>
        /// 将字符串转换为指定类型的值，仅支持基本类型转换
        /// </summary>
        /// <typeparam name="T">
        /// 支持的类型：
        /// <see cref="bool"/>
        /// <see cref="char"/>
        /// <see cref="sbyte"/>
        /// <see cref="byte"/>
        /// <see cref="short"/>
        /// <see cref="ushort"/>
        /// <see cref="int"/>
        /// <see cref="uint"/>
        /// <see cref="long"/>
        /// <see cref="ulong"/>
        /// <see cref="float"/>
        /// <see cref="double"/>
        /// <see cref="decimal"/>
        /// <see cref="DateTime"/>
        /// </typeparam>
        /// <param name="value">需要转换的值</param>
        /// <returns>转换后的值或默认值</returns>
        public static T TryParse<T>(string value)
        {
            return TryParse(value, default(T));
        }

        /// <summary>
        /// 将字符串转换为指定类型的值，仅支持基本类型转换
        /// </summary>
        /// <typeparam name="T">想要得到的基本类型</typeparam>
        /// <param name="value">需要转换的值</param>
        /// <param name="defaultValue"></param>
        /// <returns>转换后的值或给定默认值</returns>
        public static T TryParse<T>(string value, T defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }
            Type type = typeof(T);
            // 泛型Nullable判断
            if (type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }
            // string object类型没有TryParse方法，直接返回value
            var noTryParseTypes = new string[] { "string", "object" };
            if (noTryParseTypes.Any(typeName => type.Name.ToLower().Equals(typeName)))
            {
                if (string.IsNullOrEmpty(value))
                {
                    return defaultValue;
                }
                return (T)(object)value;
            }

            var TryParse = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
                Type.DefaultBinder, new Type[] { typeof(string), type.MakeByRefType() },
                new ParameterModifier[] { new ParameterModifier(2) });
            var parameters = new object[] { value, Activator.CreateInstance(type) };
            if ((bool)TryParse.Invoke(null, parameters))
            {
                return (T)parameters[1];
            }

            return defaultValue;
        }
    }
}
