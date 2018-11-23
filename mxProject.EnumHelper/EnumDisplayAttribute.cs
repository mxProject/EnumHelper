using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Display difinition of the enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class EnumDisplayAttribute : Attribute
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="displayOrder">The display order.</param>
        public EnumDisplayAttribute(string displayName, int displayOrder = 0)
        {
            DisplayName = displayName;
            DisplayOrder = displayOrder;
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
