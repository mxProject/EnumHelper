using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Extension methods of enum.
    /// </summary>
    public static class EnumExtensions
    {

        #region underlyingType

        /// <summary>
        /// Converts to Byte.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<byte>.CastFrom(value);
        }

        /// <summary>
        /// Converts to SByte.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static sbyte ToSByte<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<sbyte>.CastFrom(value);
        }

        /// <summary>
        /// Converts to Int16.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short ToInt16<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<short>.CastFrom(value);
        }

        /// <summary>
        /// Converts to UInt16.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ushort ToUInt16<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<ushort>.CastFrom(value);
        }

        /// <summary>
        /// Converts to Int32.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<int>.CastFrom(value);
        }

        /// <summary>
        /// Converts to UInt32.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint ToUInt32<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<uint>.CastFrom(value);
        }

        /// <summary>
        /// Converts to Int64.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<long>.CastFrom(value);
        }

        /// <summary>
        /// Converts to UInt64.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ulong ToUInt64<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Core.ExpressionCast<ulong>.CastFrom(value);
        }

        #endregion

        #region numeric string

        /// <summary>
        /// Converts to a numeric character string.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="format">The numeric format string.</param>
        /// <param name="value">The enum value.</param>
        /// <returns>The numeric string.</returns>
        public static string ToNumericString<TEnum>(this TEnum value, string format = null) where TEnum : Enum
        {
            return EnumHelper.ToNumericString(value, format);
        }

        #endregion

        #region DisplayInfo

        /// <summary>
        /// Gets the display name of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The display name.</returns>
        public static string GetDisplayName<TEnum>(this TEnum value) where TEnum : Enum
        {
            return EnumHelper.GetDisplayName(value);
        }

        /// <summary>
        /// Gets the display order of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The display order.</returns>
        public static int GetDisplayOrder<TEnum>(this TEnum value) where TEnum : Enum
        {
            return EnumHelper.GetDisplayOrder(value);
        }

        /// <summary>
        /// Gets whether the specified enum value is a hidden value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>true if the enum value is hidden; otherwise, false.</returns>
        public static bool IsHidden<TEnum>(this TEnum value) where TEnum : Enum
        {
            return EnumHelper.IsHidden(value);
        }

        #endregion

        #region alias

        /// <summary>
        /// Gets whether the alias is set to the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public static bool HasAlias<TEnum>(this TEnum value) where TEnum : Enum
        {
            return EnumHelper.HasAlias(value);
        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The alias.</returns>
        public static string GetAlias<TEnum>(this TEnum value) where TEnum : Enum
        {
            return EnumHelper.GetAlias(value);
        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="alias">The alias.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public static bool TryGetAlias<TEnum>(this TEnum value, out string alias) where TEnum : Enum
        {
            return EnumHelper.TryGetAlias(value, out alias);
        }

        /// <summary>
        /// Gets the enumeration value corresponding to the specified alias.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="alias">The alias.</param>
        /// <returns>The enum value.</returns>
        public static TEnum FromAlias<TEnum>(this string alias) where TEnum : Enum
        {
            return EnumHelper.FromAlias<TEnum>(alias);
        }

        /// <summary>
        /// Gets the enumeration value corresponding to the specified alias.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="alias">The alias.</param>
        /// <param name="value">The enum value.</param>
        /// <returns>true if got; otherwise, false.</returns>
        public static bool TryFromAlias<TEnum>(string alias, out TEnum value) where TEnum : Enum
        {
            return EnumHelper.TryFromAlias(alias, out value);
        }

        #endregion

    }

}
