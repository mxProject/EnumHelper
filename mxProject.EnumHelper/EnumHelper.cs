using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace mxProject
{

    /// <summary>
    /// Helper methods of enum.
    /// </summary>
    public static class EnumHelper
    {

        #region IsFlag

        /// <summary>
        /// Gets whether the specified enum type has the Flag attribute.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns></returns>
        public static bool IsFlag<TEnum>() where TEnum : Enum
        {
            return typeof(TEnum).GetCustomAttribute<FlagsAttribute>() != null;
        }

        #endregion

        #region and, or, xor

        /// <summary>
        /// Computes the logical product of the specified enum value and another value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="target">The enum value.</param>
        /// <param name="value">The another value.</param>
        /// <returns></returns>
        public static TEnum And<TEnum>(TEnum target, TEnum value) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() & value.ToInt32());
            }
            if (type == typeof(byte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToByte() & value.ToByte());
            }
            if (type == typeof(short))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt16() & value.ToInt16());
            }
            if (type == typeof(long))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt64() & value.ToInt64());
            }

            if (type == typeof(uint))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt32() & value.ToUInt32());
            }
            if (type == typeof(sbyte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToSByte() & value.ToSByte());
            }
            if (type == typeof(ushort))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt16() & value.ToUInt16());
            }
            if (type == typeof(ulong))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt64() & value.ToUInt64());
            }

            return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() & value.ToInt32());

        }

        /// <summary>
        /// Computes the logical sum of the specified enum value and another value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="target">The enum value.</param>
        /// <param name="value">The another value.</param>
        /// <returns></returns>
        public static TEnum Or<TEnum>(TEnum target, TEnum value) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() | value.ToInt32());
            }
            if (type == typeof(byte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToByte() | value.ToByte());
            }
            if (type == typeof(short))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt16() | value.ToInt16());
            }
            if (type == typeof(long))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt64() | value.ToInt64());
            }

            if (type == typeof(uint))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt32() | value.ToUInt32());
            }
            if (type == typeof(sbyte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToSByte() | value.ToSByte());
            }
            if (type == typeof(ushort))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt16() | value.ToUInt16());
            }
            if (type == typeof(ulong))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt64() | value.ToUInt64());
            }

            return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() | value.ToInt32());

        }

        /// <summary>
        /// Computes the exclusive or of the specified enum value and another value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="target">The enum value.</param>
        /// <param name="value">The another value.</param>
        /// <returns></returns>
        public static TEnum Xor<TEnum>(TEnum target, TEnum value) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() ^ value.ToInt32());
            }
            if (type == typeof(byte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToByte() ^ value.ToByte());
            }
            if (type == typeof(short))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt16() ^ value.ToInt16());
            }
            if (type == typeof(long))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt64() ^ value.ToInt64());
            }

            if (type == typeof(uint))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt32() ^ value.ToUInt32());
            }
            if (type == typeof(sbyte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToSByte() ^ value.ToSByte());
            }
            if (type == typeof(ushort))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt16() ^ value.ToUInt16());
            }
            if (type == typeof(ulong))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt64() ^ value.ToUInt64());
            }

            return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() ^ value.ToInt32());

        }

        #endregion

        #region Remove

        /// <summary>
        /// Removes one or more bit fields from the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="target">The enum value.</param>
        /// <param name="bitfields">The bit fields.</param>
        /// <returns></returns>
        public static TEnum Remove<TEnum>(TEnum target, TEnum bitfields) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() & ~bitfields.ToInt32());
            }
            if (type == typeof(byte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToByte() & ~bitfields.ToByte());
            }
            if (type == typeof(short))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt16() & ~bitfields.ToInt16());
            }
            if (type == typeof(long))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt64() & ~bitfields.ToInt64());
            }

            if (type == typeof(uint))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt32() & ~bitfields.ToUInt32());
            }
            if (type == typeof(sbyte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToSByte() & ~bitfields.ToSByte());
            }
            if (type == typeof(ushort))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt16() & ~bitfields.ToUInt16());
            }
            if (type == typeof(ulong))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(target.ToUInt64() & ~bitfields.ToUInt64());
            }

            return Core.ExpressionCast<TEnum>.CastFrom(target.ToInt32() & ~bitfields.ToInt32());

        }

        #endregion

        #region HasFlag

        /// <summary>
        /// Determines whether one or more bit fields are set in the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="target">The enum value.</param>
        /// <param name="bitfields">The bit fields.</param>
        /// <returns></returns>
        public static bool HasFlag<TEnum>(TEnum target, TEnum bitfields) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));
            
            if (type == typeof(int))
            {
                int value = bitfields.ToInt32();
                return (target.ToInt32() & value) == value;
            }
            if (type == typeof(byte))
            {
                byte value = bitfields.ToByte();
                return (target.ToByte() & value) == value;
            }
            if (type == typeof(short))
            {
                short value = bitfields.ToInt16();
                return (target.ToInt16() & value) == value;
            }
            if (type == typeof(long))
            {
                long value = bitfields.ToInt64();
                return (target.ToInt64() & value) == value;
            }

            if (type == typeof(uint))
            {
                uint value = bitfields.ToUInt32();
                return (target.ToUInt32() & value) == value;
            }
            if (type == typeof(sbyte))
            {
                sbyte value = bitfields.ToSByte();
                return (target.ToSByte() & value) == value;
            }
            if (type == typeof(ushort))
            {
                ushort value = bitfields.ToUInt16();
                return (target.ToUInt16() & value) == value;
            }
            if (type == typeof(ulong))
            {
                ulong value = bitfields.ToUInt64();
                return (target.ToUInt64() & value) == value;
            }

            int intValue = bitfields.ToInt32();
            return (target.ToInt32() & intValue) == intValue;

        }

        #endregion

        #region IsZero

        /// <summary>
        /// Gets whether the specified enum value is zero.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns></returns>
        public static bool IsZero<TEnum>(TEnum value) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                return value.ToInt32() == 0;
            }
            if (type == typeof(byte))
            {
                return value.ToByte() == 0;
            }
            if (type == typeof(short))
            {
                return value.ToInt16() == 0;
            }
            if (type == typeof(long))
            {
                return value.ToInt64() == 0;
            }

            if (type == typeof(uint))
            {
                return value.ToUInt32() == 0;
            }
            if (type == typeof(sbyte))
            {
                return value.ToSByte() == 0;
            }
            if (type == typeof(ushort))
            {
                return value.ToUInt16() == 0;
            }
            if (type == typeof(ulong))
            {
                return value.ToUInt64() == 0;
            }

            return value.ToInt32() == 0;

        }

        #endregion

        #region numeric string

        /// <summary>
        /// Converts the specified enum value to a numeric character string.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="format">The numeric format string.</param>
        /// <returns></returns>
        public static string ToNumericString<TEnum>(TEnum value, string format = null) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                return value.ToInt32().ToString(format);
            }
            if (type == typeof(byte))
            {
                return value.ToByte().ToString(format);
            }
            if (type == typeof(short))
            {
                return value.ToInt16().ToString(format);
            }
            if (type == typeof(long))
            {
                return value.ToInt64().ToString(format);
            }

            if (type == typeof(uint))
            {
                return value.ToUInt32().ToString(format);
            }
            if (type == typeof(sbyte))
            {
                return value.ToSByte().ToString(format);
            }
            if (type == typeof(ushort))
            {
                return value.ToUInt16().ToString(format);
            }
            if (type == typeof(ulong))
            {
                return value.ToUInt64().ToString(format);
            }

            return value.ToInt32().ToString(format);

        }

        /// <summary>
        /// Converts the numeric character string to an enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="numericString">The numeric character string.</param>
        /// <returns>The enum value.</returns>
        public static TEnum FromNumericString<TEnum>(string numericString) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToInt32(numericString));
            }
            if (type == typeof(byte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToByte(numericString));
            }
            if (type == typeof(short))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToInt16(numericString));
            }
            if (type == typeof(long))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToInt64(numericString));
            }

            if (type == typeof(uint))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToUInt32(numericString));
            }
            if (type == typeof(sbyte))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToSByte(numericString));
            }
            if (type == typeof(ushort))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToUInt16(numericString));
            }
            if (type == typeof(ulong))
            {
                return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToUInt64(numericString));
            }

            return Core.ExpressionCast<TEnum>.CastFrom(Convert.ToInt32(numericString));

        }

        /// <summary>
        /// Gets the enum value corresponding to the specified name.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="numericString">The name.</param>
        /// <param name="value">The enum value.</param>
        /// <returns>true if got; otherwise, false.</returns>
        public static bool TryFromNumericString<TEnum>(string numericString, out TEnum value) where TEnum : Enum
        {

            Type type = Enum.GetUnderlyingType(typeof(TEnum));

            if (type == typeof(int))
            {
                int number = Convert.ToInt32(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }
            if (type == typeof(byte))
            {
                byte number = Convert.ToByte(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }
            if (type == typeof(short))
            {
                short number = Convert.ToInt16(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }
            if (type == typeof(long))
            {
                long number = Convert.ToInt64(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }

            if (type == typeof(uint))
            {
                uint number = Convert.ToUInt32(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }
            if (type == typeof(sbyte))
            {
                sbyte number = Convert.ToSByte(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }
            if (type == typeof(ushort))
            {
                ushort number = Convert.ToUInt16(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }
            if (type == typeof(ulong))
            {
                ulong number = Convert.ToUInt64(numericString);
                if (!Enum.IsDefined(typeof(TEnum), number)) { value = default; return false; }
                value = Core.ExpressionCast<TEnum>.CastFrom(number);
                return true;
            }

            int intValue = Convert.ToInt32(numericString);
            if (!Enum.IsDefined(typeof(TEnum), intValue)) { value = default; return false; }
            value = Core.ExpressionCast<TEnum>.CastFrom(intValue);
            return true;

        }

        #endregion

        #region name

        /// <summary>
        /// Gets the enum value corresponding to the specified name.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="ignoreCase">Whether to ignore differences between uppercase and lowercase letters.</param>
        /// <returns>The enum value.</returns>
        public static TEnum FromName<TEnum>(string name, bool ignoreCase) where TEnum : Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), name, ignoreCase);
        }

        /// <summary>
        /// Gets the enum value corresponding to the specified name.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="ignoreCase">Whether to ignore differences between uppercase and lowercase letters.</param>
        /// <param name="value">The enum value.</param>
        /// <returns>true if got; otherwise, false.</returns>
        public static bool TryFromName<TEnum>(string name, bool ignoreCase, out TEnum value) where TEnum : struct, Enum
        {
            return Enum.TryParse(name, ignoreCase, out value);
        }

        #endregion

        #region DisplayInfo

        /// <summary>
        /// Factory of metadata.
        /// </summary>
        private readonly static EnumDisplayMetadataFactory s_DisplayFactory = new EnumDisplayMetadataFactory();

        /// <summary>
        /// Regists the method that get the display information of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="getter">The method that get the display information of the enum value.</param>
        public static void RegistDisplayInfo<TEnum>(Func<TEnum, IEnumDisplayInfo> getter) where TEnum : Enum
        {
            IEnumDisplayInfo func(TEnum value, FieldInfo field)
            {
                return getter(value);
            }

            s_DisplayFactory.RegistItemGetter<TEnum>(func);
        }

        /// <summary>
        /// Regists the method that get the display information of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="getter">The method that get the display information of the enum value.</param>
        public static void RegistDisplayInfo<TEnum>(Func<TEnum, FieldInfo, IEnumDisplayInfo> getter) where TEnum : Enum
        {
            s_DisplayFactory.RegistItemGetter(getter);
        }

        /// <summary>
        /// Unregists the method that get the display information of the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        public static void UnregistDisplayInfo<TEnum>() where TEnum : Enum
        {
            s_DisplayFactory.UnregistItemGetter<TEnum>();
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>The metadata.</returns>
        public static EnumDisplayMetadata<TEnum> GetDisplayMetadata<TEnum>() where TEnum : Enum
        {
            return (EnumDisplayMetadata<TEnum>)s_DisplayFactory.GetMetadata<TEnum>();
        }

        /// <summary>
        /// Gets the display name of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The display name.</returns>
        public static string GetDisplayName<TEnum>(TEnum value) where TEnum : Enum
        {
            return GetDisplayMetadata<TEnum>().GetDisplayName(value);
        }

        /// <summary>
        /// Gets the display order of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The display order.</returns>
        public static int GetDisplayOrder<TEnum>(TEnum value) where TEnum : Enum
        {
            return GetDisplayMetadata<TEnum>().GetDisplayOrder(value);
        }

        /// <summary>
        /// Gets whether the specified enum value is a hidden value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>true if the enum value is hidden; otherwise, false.</returns>
        public static bool IsHidden<TEnum>(TEnum value) where TEnum : Enum
        {
            return GetDisplayMetadata<TEnum>().IsHidden(value);
        }

        /// <summary>
        /// Get enum values sorted in display order.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="excludeHidden">Whether to exclude hidden values.</param>
        /// <returns>The enum values.</returns>
        public static IList<TEnum> GetOrderedValues<TEnum>(bool excludeHidden) where TEnum : Enum
        {
            return GetDisplayMetadata<TEnum>().GetOrderedValues(excludeHidden);
        }

        #endregion

        #region Alias

        /// <summary>
        /// Factory of metadata.
        /// </summary>
        private readonly static EnumAliasMetadataFactory s_AliasFactory = new EnumAliasMetadataFactory();

        /// <summary>
        /// Regists the method that get the alias associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="getter">The method that get the alias associated with the enum value.</param>
        public static void RegistAlias<TEnum>(Func<TEnum, IEnumAliasInfo> getter) where TEnum : Enum
        {
            IEnumAliasInfo func(TEnum value, FieldInfo field)
            {
                return getter(value);
            }

            s_AliasFactory.RegistItemGetter<TEnum>(func);
        }

        /// <summary>
        /// Regists the method that get the alias associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="getter">The method that get the alias associated with the enum value.</param>
        public static void RegistAlias<TEnum>(Func<TEnum, FieldInfo, IEnumAliasInfo> getter) where TEnum : Enum
        {
            s_AliasFactory.RegistItemGetter(getter);
        }

        /// <summary>
        /// Unregists the method that get the alias associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        public static void UnregistAlias<TEnum>()
        {
            s_AliasFactory.UnregistItemGetter<TEnum>();
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <returns>The metadata.</returns>
        public static EnumAliasMetadata<TEnum> GetAliasMetadata<TEnum>() where TEnum : Enum
        {
            return (EnumAliasMetadata<TEnum>)s_AliasFactory.GetMetadata<TEnum>();
        }

        /// <summary>
        /// Gets whether the alias is set to the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public static bool HasAlias<TEnum>(TEnum value) where TEnum : Enum
        {
            return GetAliasMetadata<TEnum>().HasAlias(value);
        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The alias.</returns>
        public static string GetAlias<TEnum>(TEnum value) where TEnum : Enum
        {
            return GetAliasMetadata<TEnum>().GetAlias(value);
        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="alias">The alias.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public static bool TryGetAlias<TEnum>(TEnum value, out string alias) where TEnum : Enum
        {
            alias = GetAlias<TEnum>(value);
            return !string.IsNullOrEmpty(alias);
        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>The alias.</returns>
        public static string[] GetAliases<TEnum>(TEnum value) where TEnum : Enum
        {
            return GetAliasMetadata<TEnum>().GetAliases(value);
        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="aliases">The alias.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public static bool TryGetAliases<TEnum>(TEnum value, out string[] aliases) where TEnum : Enum
        {
            aliases = GetAliases(value);
            return (aliases != null && aliases.Length > 0);
        }

        /// <summary>
        /// Gets the enum value corresponding to the specified alias.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="alias">The alias.</param>
        /// <returns>The enum value.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static TEnum FromAlias<TEnum>(string alias) where TEnum : Enum
        {
            return GetAliasMetadata<TEnum>().FromAlias(alias);
        }

        /// <summary>
        /// Gets the enum value corresponding to the specified alias.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="aliases">The alias.</param>
        /// <returns>The enum value.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static TEnum FromAliases<TEnum>(string[] aliases) where TEnum : Enum
        {
            return GetAliasMetadata<TEnum>().FromAliases(aliases);
        }

        /// <summary>
        /// Gets the enum value corresponding to the specified alias.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="alias">The alias.</param>
        /// <param name="value">The enum value.</param>
        /// <returns>true if got; otherwise, false.</returns>
        public static bool TryFromAlias<TEnum>(string alias, out TEnum value) where TEnum : Enum
        {
            return GetAliasMetadata<TEnum>().TryFromAlias(alias, out value);
        }

        /// <summary>
        /// Gets the enum value corresponding to the specified alias.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="aliases">The alias.</param>
        /// <param name="value">The enum value.</param>
        /// <returns>true if got; otherwise, false.</returns>
        public static bool TryFromAliases<TEnum>(string[] aliases, out TEnum value) where TEnum : Enum
        {
            return GetAliasMetadata<TEnum>().TryFromAliases(aliases, out value);
        }

        #endregion

    }

}
