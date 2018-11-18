using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Metadata of enum display information.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    public class EnumDisplayMetadata<TEnum> : EnumMetadata<TEnum, IEnumDisplayInfo> where TEnum : Enum
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="items">Pairs of enum value and alias.</param>
        internal EnumDisplayMetadata(IDictionary<TEnum, IEnumDisplayInfo> items) : base(items)
        {
        }

        #region GetDisplayName

        /// <summary>
        /// Gets the display name of the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The display name.</returns>
        public string GetDisplayName(TEnum value)
        {

            IEnumDisplayInfo info = GetItemOrDefault(value);

            if (info != null && info.DisplayName != null) { return info.DisplayName; }

            if (!IsFlag || EnumHelper.IsZero(value)) { return null; }

            StringBuilder sb = new StringBuilder();

            IEnumDisplayInfo[] infos = GetItemsOrDefault(value);

            for (int i = 0; i < infos.Length; ++i)
            {
                if (sb.Length > 0) { sb.Append(","); }
                sb.Append(infos[i].DisplayName);
            }

            return sb.Length == 0 ? null : sb.ToString();

        }

        #endregion

        #region GetDisplayOrder

        /// <summary>
        /// Gets the display order of the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The display order.</returns>
        public int GetDisplayOrder(TEnum value)
        {

            IEnumDisplayInfo info = GetItemOrDefault(value);

            return info == null ? 0 : info.DisplayOrder;

        }

        #endregion

        #region IsHidden

        /// <summary>
        /// Gets whether the specified enum value is a hidden value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>true if the enum value is hidden; otherwise, false.</returns>
        public bool IsHidden(TEnum value)
        {

            IEnumDisplayInfo info = GetItemOrDefault(value);

            return info == null ? false : info.Hidden;

        }

        #endregion

        #region GetOrderedValues

        /// <summary>
        /// Get enum values sorted in display order.
        /// </summary>
        /// <param name="excludeHidden">Whether to exclude hidden values.</param>
        /// <returns>The enum values.</returns>
        public IList<TEnum> GetOrderedValues(bool excludeHidden)
        {

            TEnum[] array = (TEnum[])Enum.GetValues(typeof(TEnum));

            if (!excludeHidden)
            {
                Array.Sort(array, (x, y) =>
                {
                    return CompareByDisplayOrder(x, y);
                });
                return array;
            }

            List<TEnum> list = new List<TEnum>(array.Length);

            for (int i = 0; i < array.Length; ++i)
            {
                TEnum value = (TEnum)array.GetValue(i);

                IEnumDisplayInfo info = GetItemOrDefault(value);
                if (info != null && info.Hidden) { continue; }

                list.Add(value);
            }

            list.Sort((x, y) =>
            {
                return CompareByDisplayOrder(x, y);
            });

            return list;

        }

        /// <summary>
        /// Compares the specified enum value according to the display order.
        /// </summary>
        /// <param name="x">The first value to compare.</param>
        /// <param name="y">The second value to compare.</param>
        /// <returns>If <paramref name="x"/> is greater than <paramref name="y"/>, returns a positive number; If <paramref name="y"/> is greater than <paramref name="x"/>, returns a negative number; otherwise, zero.</returns>
        private int CompareByDisplayOrder(TEnum x, TEnum y)
        {

            IEnumDisplayInfo X = GetItemOrDefault(x);
            IEnumDisplayInfo Y = GetItemOrDefault(y);

            if (X != null && Y != null)
            {
                int ret;
                ret = X.DisplayOrder.CompareTo(Y.DisplayOrder);
                if (ret != 0) { return ret; }
            }
            else if (X != null)
            {
                return 1;
            }
            else if (Y != null)
            {
                return -1;
            }

            return x.CompareTo(y);

        }

        #endregion

    }

}
