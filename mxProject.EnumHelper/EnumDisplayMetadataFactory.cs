using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace mxProject
{

    /// <summary>
    /// Factory of EnumMetadata.
    /// </summary>
    internal class EnumDisplayMetadataFactory : EnumMetadataFactoryBase<IEnumMetadata, IEnumDisplayInfo>
    {

        /// <summary>
        /// Creates a metadata of the specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="itemGetter">A method that get the information associated with the enum value.</param>
        /// <returns>metadata.</returns>
        protected override IEnumMetadata CreateContext<TEnum>(Func<TEnum, FieldInfo, IEnumDisplayInfo> itemGetter)
        {
            return new EnumDisplayMetadata<TEnum>(EnumMetadataFactory.GetItems(itemGetter));
        }

        /// <summary>
        /// Gets the information associated with the enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="field">The field information of the enum value.</param>
        /// <returns>the information associated with the enum value.</returns>
        protected override IEnumDisplayInfo GetItem<TEnum>(TEnum value, FieldInfo field)
        {

            EnumDisplayAttribute displayAttr = field.GetCustomAttribute<EnumDisplayAttribute>(false);
            EnumHiddenAttribute hiddenAttr = field.GetCustomAttribute<EnumHiddenAttribute>(false);

            return new EnumDisplayInfo(
                displayAttr ==null ? value.ToString() : displayAttr.DisplayName
                , displayAttr == null ? 0 : displayAttr.DisplayOrder
                , hiddenAttr != null
                );

        }

    }

}
