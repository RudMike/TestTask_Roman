//-----------------------------------------------------------------------
// <copyright file="IMapper.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Infrastructure.Mapping
{
    /// <summary>
    /// Interface for mapping between two types.
    /// </summary>
    /// <typeparam name="TFrom">The type of the source object.</typeparam>
    /// <typeparam name="TTo">The type of the destination object.</typeparam>
    public interface IMapper<TFrom, TTo>
    {
        /// <summary>
        /// Maps the source object to the destination object.
        /// </summary>
        /// <param name="from">The source object.</param>
        /// <returns>The destination object.</returns>
        public TTo Map(TFrom from);
    }
}
