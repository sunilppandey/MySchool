using MySchool.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Entities
{
    public class Book : DomainEntity<int>, IAuditTracking
    {
        #region Constructor
        public Book() { }

        #endregion

        #region Properties

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Validates this object. It validates dependencies between properties and also calls Validate on child collections;
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult("Title can't be None.", new[] { "Title" });
            }

            if (string.IsNullOrEmpty(Description))
            {
                yield return new ValidationResult("Description can't be None.", new[] { "Description" });
            }

            if (string.IsNullOrEmpty(Author))
            {
                yield return new ValidationResult("Author can't be None.", new[] { "Author" });
            }
        }
        #endregion
    }

}
