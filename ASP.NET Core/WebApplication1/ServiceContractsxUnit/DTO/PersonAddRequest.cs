using Entities;
using ServiceContractsxUnit.Enums;
using System.ComponentModel.DataAnnotations;

namespace ServiceContractsxUnit.DTO
{
    /// <summary>
    /// Acts as DTO for inserting a new Person
    /// </summary>
    public class PersonAddRequest
    {
        [Required(ErrorMessage = "Person Name can't be blank")]
        public string? PersonName { get; set; }
        public Guid? CountryID { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email value should be a valid email")]
        public string? Email { get; set; }
        public GenderOptions Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }

        /// <summary>
        /// Converts the current object of the PersonAddRequest into a new object of Person type
        /// </summary>
        /// <returns></returns>
        public Person ToPerson()
        {
            return new()
            {
                CountryID = CountryID,
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Address = Address,
                Gender = Gender.ToString(),
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }
}
