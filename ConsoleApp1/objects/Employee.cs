namespace ConsoleApp1.objects
{
    class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public int Salary { get; set; }
        public decimal comissionPct { get; set; }
        public bool IsManager { get; set; }
        public string? JobId { get; set; }
        public int DepartmentId { get; set; }


    }
}
