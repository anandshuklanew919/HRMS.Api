using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Api.Data.Entities
{
    public class Department
    {
        [Key]
        public long DepartmentId { get; set; }

        [ForeignKey("FK_Department_BusinessUnit_BusinessUnitId")]
        public long BusinessUnitId { get; set; }

        [MaxLength(100), Required]
        public string DepartmentName { get; set; }

        public BusinessUnit BusinessUnit  { get; set; }
    }
}
