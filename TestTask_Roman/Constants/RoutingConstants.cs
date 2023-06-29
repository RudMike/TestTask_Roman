//-----------------------------------------------------------------------
// <copyright file="RoutingConstants.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Constants
{
    /// <summary>
    /// Defines the constant names used for routing parameters in the web API.
    /// </summary>
    public static class RoutingConstants
    {
        /// <summary>
        /// The name of the address parameter used in routing.
        /// </summary>
        public const string Address = "address";

        /// <summary>
        /// The name of the area parameter used in routing.
        /// </summary>
        public const string Area = "area";

        /// <summary>
        /// The name of the birthdate parameter used in routing.
        /// </summary>
        public const string BirthDate = "birthdate";

        /// <summary>
        /// The name of the ascending sort order parameter used in routing.
        /// </summary>
        public const string ByAscending = "asc";

        /// <summary>
        /// The name of the descending sort order parameter used in routing.
        /// </summary>
        public const string ByDescending = "desc";

        /// <summary>
        /// The name of the first name parameter used in routing.
        /// </summary>
        public const string FirstName = "firstname";

        /// <summary>
        /// The name of the last name parameter used in routing.
        /// </summary>
        public const string LastName = "lastname";

        /// <summary>
        /// The name of the middle name parameter used in routing.
        /// </summary>
        public const string MiddleName = "middlename";

        /// <summary>
        /// The name of the room parameter used in routing.
        /// </summary>
        public const string Room = "room";

        /// <summary>
        /// The name of the sex parameter used in routing.
        /// </summary>
        public const string Sex = "sex";

        /// <summary>
        /// The name of the specialization parameter used in routing.
        /// </summary>
        public const string Specialization = "specialization";

        /// <summary>
        /// The name of the current page number parameter used in routing.
        /// </summary>
        public const string Page = "page";

        /// <summary>
        /// The name of the current page size parameter used in routing.
        /// </summary>
        public const string PageSize = "pagesize";

        /// <summary>
        /// The default value for the <see cref="Page"/> parameter if it is not specified in the query string.
        /// </summary>
        public const int PageDefault = 1;

        /// <summary>
        /// The default value for the <see cref="PageSize"/> parameter if it is not specified in the query string.
        /// </summary>
        public const int PageSizeDefault = 10;
    }
}
