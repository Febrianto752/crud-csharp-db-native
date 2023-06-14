namespace ConsoleApp1.objects
{
    class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? LocationId { get; set; }
        public int? ManagerId { get; set; }

        public string? StreetAddress { get; set; }

        public string? ManagerName { get; set; }
    }
}
