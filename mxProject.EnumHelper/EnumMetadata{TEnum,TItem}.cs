using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace mxProject
{

    /// <summary>
    /// Metadata of enum.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <typeparam name="TItem">The type of information associated with the enum value.</typeparam>
    public class EnumMetadata<TEnum, TItem> : IEnumMetadata where TEnum : Enum
    {

        #region ctor

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="items">Pairs of enum value and information.</param>
        public EnumMetadata(IDictionary<TEnum, TItem> items)
        {
            m_Items = items;
            IsFlag = EnumHelper.IsFlag<TEnum>();
        }

        #endregion

        /// <summary>
        /// Gets whether the specified enum type has the Flag attribute.
        /// </summary>
        protected bool IsFlag { get; private set; }

        #region items

        private readonly IDictionary<TEnum, TItem> m_Items;

        #endregion

        #region TryGetItem

        /// <summary>
        /// Gets the information associated with the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="item">The information associated with the specified enum value.</param>
        /// <returns>true if this contains the specified enum value; otherwise, false.</returns>
        public bool TryGetItem(TEnum value, out TItem item)
        {
            return m_Items.TryGetValue(value, out item);
        }

        /// <summary>
        /// Gets the information associated with the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="items">The information associated with the specified enum value.</param>
        /// <returns>true if this contains the specified enum value; otherwise, false.</returns>
        public bool TryGetItems(TEnum value, out TItem[] items)
        {
            if (EnumHelper.IsZero(value))
            {
                if (TryGetItem(value, out TItem item) && item != null)
                {
                    items = new TItem[] { item };
                    return true;
                }
                else
                {
                    items = new TItem[] { };
                    return false;
                }
            }

            List<TItem> list = new List<TItem>();

            foreach (KeyValuePair<TEnum, TItem> pair in m_Items)
            {
                if (EnumHelper.IsZero(pair.Key)) { continue; }
                if (!EnumHelper.HasFlag(value, pair.Key)) { continue; }
                if (pair.Value == null) { continue; }
                list.Add(pair.Value);
            }

            items = list.ToArray();
            return (items.Length > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        bool IEnumMetadata.TryGetItem(Enum value, out object item)
        {
            if (TryGetItem((TEnum)value, out TItem typedItem))
            {
                item = typedItem;
                return true;
            }
            else
            {
                item = null;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        bool IEnumMetadata.TryGetItems(Enum value, out object[] items)
        {
            if (TryGetItems((TEnum)value, out TItem[] typedItems))
            {
                items = new object[typedItems.Length];
                typedItems.CopyTo(items, 0);
                return true;
            }
            else
            {
                items = null;
                return false;
            }
        }

        #endregion

        #region GetItemOrDefault

        /// <summary>
        /// Gets the information associated with the specified enum value. 
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The information associated with the specified enum value. If this don't contains the specified enum value, returns default value.</returns>
        public TItem GetItemOrDefault(TEnum value)
        {
            if (TryGetItem(value, out TItem item))
            {
                return item;
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Gets the information associated with the specified enum value. 
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The information associated with the specified enum value. If this don't contains the specified enum value, returns default value.</returns>
        public TItem[] GetItemsOrDefault(TEnum value)
        {
            if (TryGetItems(value, out TItem[] items))
            {
                return items;
            }
            else
            {
                return new TItem[] { };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object IEnumMetadata.GetItemOrDefault(Enum value)
        {
            return GetItemOrDefault((TEnum)value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object[] IEnumMetadata.GetItemsOrDefault(Enum value)
        {
            TItem[] typedItems = GetItemsOrDefault((TEnum)value);
            object[] items = new object[typedItems.Length];
            typedItems.CopyTo(items, 0);
            return items;
        }

        #endregion

    }

}
