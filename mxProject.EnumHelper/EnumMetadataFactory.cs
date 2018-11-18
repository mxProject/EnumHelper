using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject
{

    /// <summary>
    /// Factory of EnumMetadata.
    /// </summary>
    public static class EnumMetadataFactory
    {

        /// <summary>
        /// Creates the metadata associated with the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
        /// <param name="items">Pairs of enum value and information.</param>
        /// <returns>metadata.</returns>
        public static EnumMetadata<TEnum, TItem> Create<TEnum, TItem>(IEnumerable<KeyValuePair<TEnum, TItem>> items) where TEnum : Enum
        {
            return new EnumMetadata<TEnum, TItem>(GetItems(items));
        }

        /// <summary>
        /// Gets the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
        /// <param name="items">Pairs of enum value and information.</param>
        /// <returns>A dictionary containing pairs of enum value and information.</returns>
        public static IDictionary<TEnum, TItem> GetItems<TEnum, TItem>(IEnumerable<KeyValuePair<TEnum, TItem>> items) where TEnum : Enum
        {

            Dictionary<TEnum, TItem> dic = new Dictionary<TEnum, TItem>();

            foreach (KeyValuePair<TEnum, TItem> pair in items)
            {
                dic.Add(pair.Key, pair.Value);
            }

            FieldInfo[] fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {

                TEnum value = (TEnum)field.GetValue(null);

                if (!dic.ContainsKey(value)) { dic.Add(value, default); }

            }

            return dic;

        }

        /// <summary>
        /// Creates the metadata associated with the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
        /// <param name="itemGetter">A method that get the information associated with the enum value.</param>
        /// <returns>metadata.</returns>
        public static EnumMetadata<TEnum, TItem> Create<TEnum, TItem>(Func<TEnum, TItem> itemGetter) where TEnum : Enum
        {
            return new EnumMetadata<TEnum, TItem>(GetItems(itemGetter));
        }

        /// <summary>
        /// Gets the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
        /// <param name="itemGetter">A method that get the information associated with the enum value.</param>
        /// <returns>A dictionary containing pairs of enum value and information.</returns>
        public static IDictionary<TEnum, TItem> GetItems<TEnum, TItem>(Func<TEnum, TItem> itemGetter) where TEnum : Enum
        {

            Dictionary<TEnum, TItem> dic = new Dictionary<TEnum, TItem>();

            FieldInfo[] fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {

                TEnum value = (TEnum)field.GetValue(null);

                TItem item = itemGetter(value);

                if (dic.TryGetValue(value, out TItem found))
                {
                    if (found == null)
                    {
                        dic[value] = item;
                    }
                }
                else
                {
                    dic.Add(value, item);
                }

            }

            return dic;

        }

        /// <summary>
        /// Creates the metadata associated with the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
        /// <param name="itemGetter">A method that get the information associated with the enum value.</param>
        /// <returns>metadata.</returns>
        public static EnumMetadata<TEnum, TItem> Create<TEnum, TItem>(Func<TEnum, FieldInfo, TItem> itemGetter) where TEnum : Enum
        {
            return new EnumMetadata<TEnum, TItem>(GetItems(itemGetter));
        }

        /// <summary>
        /// Gets the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
        /// <param name="itemGetter">A method that get the information associated with the enum value.</param>
        /// <returns>A dictionary containing pairs of enum value and information.</returns>
        public static IDictionary<TEnum, TItem> GetItems<TEnum, TItem>(Func<TEnum, FieldInfo, TItem> itemGetter) where TEnum : Enum
        {

            Dictionary<TEnum, TItem> dic = new Dictionary<TEnum, TItem>();

            FieldInfo[] fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {

                TEnum value = (TEnum)field.GetValue(null);

                TItem item = itemGetter(value, field);

                if (dic.TryGetValue(value, out TItem found))
                {
                    if (found == null)
                    {
                        dic[value] = item;
                    }
                }
                else
                {
                    dic.Add(value, item);
                }

            }

            return dic;

        }

    }

}
