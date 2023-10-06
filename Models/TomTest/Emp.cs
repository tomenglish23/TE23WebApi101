namespace TEWebApi101.Models.TomTest
{
    public class Emp
    {
        public int Id { get; set; }
        public required string LName { get; set; }
        public required string FName { get; set; }
        public int? DeptId { get; set; }
        public int? Salary { get; set; }
        public int? Months { get; set; }
    }
}