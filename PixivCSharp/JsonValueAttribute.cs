using System;
using System.Reflection;

namespace PixivCSharp
{
    /// <summary>
    /// Attribute used to represent the Json value of an enum.
    /// </summary>
    public class JsonValueAttribute : Attribute
    {
        /// <summary>
        /// Holds the json value of an enum.
        /// </summary>
        public string JsonValue { get; protected set; }

        /// <summary>
        /// Constructor for JsonValueAttribute.
        /// </summary>
        /// <param name="value">The json value.</param>
        public JsonValueAttribute(string value)
        {
            JsonValue = value;
        }
    }

    /// <summary>
    /// Contains extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        public static string JsonValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            JsonValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(JsonValueAttribute), false) as JsonValueAttribute[];

            return attribs.Length > 0 ? attribs[0].JsonValue : null;
        }
    }
}
