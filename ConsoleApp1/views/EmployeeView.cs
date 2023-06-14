using ConsoleApp1.models;
using ConsoleApp1.objects;

namespace ConsoleApp1.views
{
    class EmployeeView
    {
        public static void EmployeeList()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Employee> employees = EmployeeModel.FindAllEmployee();
            //Console.Clear();

            Console.WriteLine("*** Employee List ***\n");

            foreach (var employee in employees)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID              : {0}", employee.Id);
                Console.WriteLine("First Name      : {0}", employee.FirstName);
                Console.WriteLine("Last Name       : {0}", employee.LastName);
                Console.WriteLine("Email           : {0}", employee.Email);
                Console.WriteLine("Phone           : {0}", employee.PhoneNumber);
                Console.WriteLine("Hire Date       : {0}", employee.HireDate);
                Console.WriteLine("Salary          : {0}", employee.Salary);
                Console.WriteLine("Comission pct   : {0}", employee.comissionPct);
                Console.WriteLine("Status          : {0}", employee.IsManager ? "Manager" : "Staff");
                Console.WriteLine("Job Id          : {0}", employee.JobId);
                Console.WriteLine("Department Id   : {0}", employee.DepartmentId);

                Console.WriteLine("===========================");
            }


            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            GeneralView.HomePage();


        }
    }
}
