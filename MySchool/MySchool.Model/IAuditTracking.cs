using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model
{
    public interface IAuditTracking
    {
        /// <summary>
        /// Gets or sets the user creating the object.
        /// </summary>
        string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the date and time the object was created.
        /// </summary>
        DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the user updating the object.
        /// </summary>
        string ModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets the date and time the object was last modified.
        /// </summary>
        DateTime? ModifiedDate { get; set; }
    }
}
