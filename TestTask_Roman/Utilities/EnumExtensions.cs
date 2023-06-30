//-----------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using Microsoft.OpenApi.Extensions;

namespace TestTask_Roman.Utilities
{
    /// <summary>
    /// Provides extension methods for working with enumerations.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description of the enumeration value.
        /// </summary>
        /// <param name="value">The enumeration value.</param>
        /// <returns>The description of the enumeration value, or the string representation of the value if it does not have a description.</returns>
        public static string GetDescription(this Enum value)
        {
            var descriptionAttribute = value.GetAttributeOfType<DescriptionAttribute>();
            return descriptionAttribute?.Description ?? value.ToString();
        }
    }
}
