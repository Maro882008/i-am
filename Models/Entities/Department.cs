namespace MVC.Models.Entities
{
    public class Department
    {
        public int ID { get; set; }
        public string name { get; set; }    
        public ICollection<Employee> Employees { get;}
    }
}
