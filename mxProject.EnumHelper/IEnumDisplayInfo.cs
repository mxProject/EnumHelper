using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Represents the display information of the enum.
    /// </summary>
    public interface IEnumDisplayInfo
    {

        /// <summary>
        /// Gets the display name.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the display order.
        /// </summary>
        int DisplayOrder { get; }

        /// <summary>
        /// Gets whether it's a hidden value.
        /// </summary>
        bool Hidden { get; }

    }

}
