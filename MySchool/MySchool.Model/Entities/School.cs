using MySchool.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Model.Entities
{
    public class School : DomainEntity<int>, IAuditTracking
    {
        #region Properties

        public string Name { get; set; }
        public string Domain { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public short BoardName { get; set; }
        public short WorkingDays { get; set; }
        public short AcademicYear { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        #endregion

        #region Constuctor

        public School() { }

        #endregion

        #region Methods

        /// <summary>
        /// Validates this object. It validates dependencies between properties and also calls Validate on child collections;
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name can't be None.", new[] { "Name" });
            }

            if (string.IsNullOrEmpty(Domain))
            {
                yield return new ValidationResult("Domain can't be None.", new[] { "Domain" });
            }

            if (string.IsNullOrEmpty(Address))
            {
                yield return new ValidationResult("Address can't be None.", new[] { "Address" });
            }

            if (string.IsNullOrEmpty(PhoneNumber))
            {
                yield return new ValidationResult("PhoneNumber can't be None.", new[] { "PhoneNumber" });
            }

            if (string.IsNullOrEmpty(RegistrationNumber))
            {
                yield return new ValidationResult("RegistrationNumber can't be None.", new[] { "RegistrationNumber" });
            }

            if (BoardName <= 0)
            {
                yield return new ValidationResult("BoardName can't be None.", new[] { "BoardName" });
            }

            if (WorkingDays <= 0)
            {
                yield return new ValidationResult("WorkingDays can't be None.", new[] { "WorkingDays" });
            }

            if (AcademicYear <= 0)
            {
                yield return new ValidationResult("AcademicYear can't be None.", new[] { "AcademicYear" });
            }
        }
        #endregion
    }
}
