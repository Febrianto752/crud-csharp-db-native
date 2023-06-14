namespace ConsoleApp1.views
{
    class GeneralView
    {

        public static void HomePage()
        {
            Console.Clear();
            Console.WriteLine("*** Main Menu ***");
            Console.WriteLine("1. Get all regions");
            Console.WriteLine("2. Get all countries");
            Console.WriteLine("3. Get all locations");
            Console.WriteLine("4. Get all departments");
            Console.WriteLine("5. Get all employees");
            Console.WriteLine("6. Get all jobs");
            Console.WriteLine("7. Get all histories");
            Console.WriteLine("8. Exit");
            Console.WriteLine("******************");
            Console.Write("pilihan : ");

            int pilihan = default;

            try
            {
                pilihan = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid choice input : ");
                Console.ReadKey();
                HomePage();
            }

            switch (pilihan)
            {
                case 1:
                    RegionView.RegionList();
                    break;
                case 2:
                    CountryView.CountryList();
                    break;
                case 3:
                    LocationView.LocationList();
                    break;
                case 4:
                    DepartmentView.DepartmentList();
                    break;
                case 5:
                    EmployeeView.EmployeeList();
                    break;
                case 6:
                    JobView.JobList();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice input!!!");
                    Console.ReadKey();
                    HomePage();
                    break;
            }
        }


    }
}
