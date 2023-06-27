using System.ComponentModel.DataAnnotations;

namespace HRMS.Api.Data.Entities
{
    public class Company
    {
        public long CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public ICollection<BusinessUnit> BusinessUnits { get; set;}

    }
}
