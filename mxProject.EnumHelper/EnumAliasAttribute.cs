using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Alias difinition of the enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class EnumAliasAttribute : Attribute, IEnumAliasInfo
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="alias">The alias.</param>
        public EnumAliasAttribute(string alias)
        {
            Alias = alias;
        }

        /// <summary>
        /// Gets the alias.
        /// </summary>
        public string Alias { get; }

    }

}
