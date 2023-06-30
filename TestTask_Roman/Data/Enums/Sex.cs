//-----------------------------------------------------------------------
// <copyright file="Sex.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;

namespace TestTask_Roman.Data.Enums
{
    /// <summary>
    /// Represents the biological sex of a person.
    /// </summary>
    public enum Sex : byte
    {
        /// <summary>
        /// The male sex.
        /// </summary>
        [Description("Муж")]
        Male = 0,

        /// <summary>
        /// The female sex.
        /// </summary>
        [Description("Жен")]
        Female = 1,
    }
}
