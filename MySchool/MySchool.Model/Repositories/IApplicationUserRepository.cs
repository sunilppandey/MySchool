using MySchool.Infrastructure;
using MySchool.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Repositories
{
    /// <summary>
    /// Defines the various methods available to work with people in the system.
    /// </summary>
    public interface IApplicationUserRepository : IRepository<ApplicationUser, int>
    {
        /// <summary>
        /// Gets a list of all the people whose last name exactly matches the search string.
        /// </summary>
        /// <param name="lastName">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Person with the matching people.</returns>
        IEnumerable<ApplicationUser> FindByLastName(string lastName);
    }
}
