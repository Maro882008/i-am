using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public decimal Salary { get; set; }
        public int depid { get; set; }
        [ForeignKey("depid")]
        public Department  Department { get; set; }
    }
}
