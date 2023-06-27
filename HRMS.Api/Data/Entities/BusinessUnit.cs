using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Api.Data.Entities
{
    public class BusinessUnit
    {
        [Key]
        public long BusinessUnitId { get; set; }

        [ForeignKey("FK_BusinessUnit_Company_CompanyId")]
        public long CompanyId { get; set; }

        [MaxLength(100), Required]
        public string BusinessUnitName { get; set; }

        public Company Company { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
