//-----------------------------------------------------------------------
// <copyright file="PaginationHelper.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Constants;

namespace TestTask_Roman.Utilities
{
    /// <summary>
    /// Provides helper methods for working with pagination.
    /// </summary>
    public static class PaginationHelper
    {
        /// <summary>
        /// Sets the default values for page and page size if they are null or invalid.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <remarks>If <paramref name="page"/> is null or less than 1, it will be set to the default page number defined in <see cref="RoutingConstants.PageDefault"/>.
        /// If <paramref name="pageSize"/> is null or less than 1, it will be set to the default page size defined in <see cref="RoutingConstants.PageSizeDefault"/>.</remarks>
        public static void SetDefaultIfInvalidPagination(ref int? page, ref int? pageSize)
        {
            if (page == null || page < 1)
            {
                page = RoutingConstants.PageDefault;
            }

            if (page == null || pageSize < 1)
            {
                pageSize = RoutingConstants.PageSizeDefault;
            }
        }

        /// <summary>
        /// Sets the default values for page and page size if they are invalid.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <remarks>If <paramref name="page"/> is less than 1, it will be set to the default page number defined in <see cref="RoutingConstants.PageDefault"/>.
        /// If <paramref name="pageSize"/> is less than 1, it will be set to the default page size defined in <see cref="RoutingConstants.PageSizeDefault"/>.</remarks>
        public static void SetDefaultIfInvalidPagination(ref int page, ref int pageSize)
        {
            if (page < 1)
            {
                page = RoutingConstants.PageDefault;
            }

            if (pageSize < 1)
            {
                pageSize = RoutingConstants.PageSizeDefault;
            }
        }
    }
}
