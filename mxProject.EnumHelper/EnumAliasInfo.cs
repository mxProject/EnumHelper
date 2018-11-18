using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject
{

    /// <summary>
    /// Alias information of the enum.
    /// </summary>
    public sealed class EnumAliasInfo : IEnumAliasInfo
    {

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="alias">The alias.</param>
        public EnumAliasInfo(string alias)
        {
            Alias = alias;
        }

        /// <summary>
        /// Gets the alias.
        /// </summary>
        public string Alias { get; }

    }

}
