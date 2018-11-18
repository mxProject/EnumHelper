using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Display information of the enum.
    /// </summary>
    public sealed class EnumDisplayInfo : IEnumDisplayInfo
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="displayOrder">The display order.</param>
        /// <param name="hidden">whether it's a hidden value.</param>
        public EnumDisplayInfo(string displayName, int displayOrder = 0, bool hidden = false)
        {
            DisplayName = displayName;
            DisplayOrder = displayOrder;
            Hidden = hidden;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the display order.
        /// </summary>
        public int DisplayOrder { get; }

        /// <summary>
        /// Gets whether it's a hidden value.
        /// </summary>
        public bool Hidden { get; }

    }

}
