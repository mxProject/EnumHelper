using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mxProject
{

    /// <summary>
    /// Metadata of enum alias.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    public class EnumAliasMetadata<TEnum> : EnumMetadata<TEnum, IEnumAliasInfo> where TEnum : Enum
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="items">Pairs of enum value and alias.</param>
        internal EnumAliasMetadata(IDictionary<TEnum, IEnumAliasInfo> items) : base(items)
        {
            m_Aliases = CreateAliases(items);
        }

        private readonly IDictionary<string, TEnum> m_Aliases;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private static IDictionary<string, TEnum> CreateAliases(IDictionary<TEnum, IEnumAliasInfo> items)
        {
            Dictionary<string, TEnum> dic = new Dictionary<string, TEnum>(items.Count);

            foreach (KeyValuePair<TEnum, IEnumAliasInfo> item in items)
            {
                if (string.IsNullOrEmpty(item.Value.Alias)) { continue; }
                dic.Add(NormalizeAlias(item.Value.Alias), item.Key);
            }

            return dic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        private static string NormalizeAlias(string alias)
        {
            if (alias == null) { return ""; }
            return alias.ToLower().Trim();
        }

        #region HasAlias

        /// <summary>
        /// Gets whether the alias is set to the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public bool HasAlias(TEnum value)
        {

            IEnumAliasInfo info = GetItemOrDefault(value);

            if (info != null && !string.IsNullOrEmpty(info.Alias)) { return true; }

            if (!IsFlag || EnumHelper.IsZero(value)) { return false; }

            IEnumAliasInfo[] infos = GetItemsOrDefault(value);

            if (infos == null && infos.Length == 0) { return false; }

            for (int i = 0; i < infos.Length; ++i)
            {
                if (infos[i] != null && !string.IsNullOrEmpty(infos[i].Alias)) { return true; }
            }

            return false;

        }

        #endregion

        #region GetAlias

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The alias.</returns>
        public string GetAlias(TEnum value)
        {

            IEnumAliasInfo info = GetItemOrDefault(value);

            if (info != null && !string.IsNullOrEmpty(info.Alias)) { return info.Alias; }

            if (!IsFlag || EnumHelper.IsZero(value)) { return null; }

            IEnumAliasInfo[] infos = GetItemsOrDefault(value);

            if (infos == null || infos.Length == 0) { return null; }

            StringBuilder sb = new StringBuilder();

            foreach (string alias in infos.Select(o => o.Alias).Where(o => !string.IsNullOrEmpty(o)))
            {
                if (sb.Length > 0) { sb.Append(","); }
                sb.Append(alias);
            }

            return sb.Length == 0 ? null : sb.ToString();

        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="alias">The alias.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public bool TryGetAlias(TEnum value, out string alias)
        {
            alias = GetAlias(value);
            return !string.IsNullOrEmpty(alias);
        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The alias.</returns>
        public string[] GetAliases(TEnum value)
        {

            IEnumAliasInfo[] infos = GetItemsOrDefault(value);

            if (infos == null || infos.Length == 0) { return new string[] { }; }

            return infos.Select(o => o.Alias).Where(o => !string.IsNullOrEmpty(o)).ToArray();

        }

        /// <summary>
        /// Gets the alias of the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="aliases">The alias.</param>
        /// <returns>true if setted; otherwise, false.</returns>
        public bool TryGetAliases(TEnum value, out string[] aliases)
        {
            aliases = GetAliases(value);
            return (aliases != null && aliases.Length > 0);
        }

        #endregion

        #region FromAlias

        /// <summary>
        /// Converts the specified alias to an enum value.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>enum value.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public TEnum FromAlias(string alias)
        {
            if (!IsFlag)
            {
                return FromAliasCore(alias);
            }

            return FromAliases(alias.Split(','));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        private TEnum FromAliasCore(string alias)
        {
            try
            {
                return m_Aliases[NormalizeAlias(alias)];
            }
            catch (KeyNotFoundException ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gets the enum value corresponding to the specified alias.
        /// </summary>
        /// <param name="aliases">The alias.</param>
        /// <returns>The enum value.</returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public TEnum FromAliases(string[] aliases)
        {
            TEnum result = default;

            foreach (string alias in aliases)
            {
                result = EnumHelper.Or(result, FromAliasCore(alias));
            }

            return result;
        }

        /// <summary>
        /// Converts the specified alias to an enum value.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="value">enum value.</param>
        /// <returns>true if this contains the alias; otherwise, false.</returns>
        public bool TryFromAlias(string alias, out TEnum value)
        {
            if (!IsFlag)
            {
                return TryFromAliasCore(alias, out value);
            }

            return TryFromAliases(alias.Split(','), out value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool TryFromAliasCore(string alias, out TEnum value)
        {
            if (m_Aliases.TryGetValue(NormalizeAlias(alias), out value))
            {
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }

        /// <summary>
        /// Gets the enum value corresponding to the specified alias.
        /// </summary>
        /// <param name="aliases">The alias.</param>
        /// <param name="value">The enum value.</param>
        /// <returns>true if got; otherwise, false.</returns>
        public bool TryFromAliases(string[] aliases, out TEnum value)
        {
            TEnum result = default;

            foreach (string alias in aliases)
            {
                if (!TryFromAliasCore(alias, out TEnum val))
                {
                    value = default;
                    return false;
                }
                result = EnumHelper.Or(result, val);
            }

            value = result;
            return true;
        }

        #endregion

    }
}
