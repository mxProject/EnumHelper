using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject
{

    /// <summary>
    /// Factory of EnumAliasMetadata.
    /// </summary>
    internal class EnumAliasMetadataFactory : EnumMetadataFactoryBase<IEnumMetadata, IEnumAliasInfo>
    {

        /// <summary>
        /// Creates a metadata of the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="itemGetter">A method that get the information associated with the enum value.</param>
        /// <returns>metadata.</returns>
        protected override IEnumMetadata CreateContext<TEnum>(Func<TEnum, FieldInfo, IEnumAliasInfo> itemGetter)
        {
            return new EnumAliasMetadata<TEnum>(EnumMetadataFactory.GetItems(itemGetter));
        }

        /// <summary>
        /// Gets the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="field">The field information of the enum value.</param>
        /// <returns>the information associated with the enum value.</returns>
        protected override IEnumAliasInfo GetItem<TEnum>(TEnum value, FieldInfo field)
        {

            EnumAliasAttribute attr = field.GetCustomAttribute<EnumAliasAttribute>(false);

            if (attr != null) { return attr; }

            return new EnumAliasInfo(null);

        }

    }

}
