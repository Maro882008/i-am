using MVC.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVC.viewModel
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public decimal salary { get; set; } 
        public int DepId { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
