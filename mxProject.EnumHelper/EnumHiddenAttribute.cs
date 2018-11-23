using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Hidden difinition of the enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class EnumHiddenAttribute : Attribute
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public EnumHiddenAttribute()
        {
        }

    }

}
