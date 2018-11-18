using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Represents metadata of enum.
    /// </summary>
    public interface IEnumMetadata
    {

        #region items

        /// <summary>
        /// Gets the information associated with the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="item">The information associated with the specified enum value.</param>
        /// <returns>true if this contains the specified enum value; otherwise, false.</returns>
        bool TryGetItem(Enum value, out object item);

        /// <summary>
        /// Gets the information associated with the specified enum value.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <param name="items">The information associated with the specified enum value.</param>
        /// <returns>true if this contains the specified enum value; otherwise, false.</returns>
        bool TryGetItems(Enum value, out object[] items);

        /// <summary>
        /// Gets the information associated with the specified enum value. 
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The information associated with the specified enum value. If this don't contains the specified enum value, returns default value.</returns>
        object GetItemOrDefault(Enum value);

        /// <summary>
        /// Gets the information associated with the specified enum value. 
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The information associated with the specified enum value. If this don't contains the specified enum value, returns default value.</returns>
        object[] GetItemsOrDefault(Enum value);

        #endregion

    }

}
