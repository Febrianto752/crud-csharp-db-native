using ConsoleApp1.models;
using ConsoleApp1.objects;

namespace ConsoleApp1.views
{
    class DepartmentView
    {
        public static void DepartmentList()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Department> departments = DepartmentModel.FindAllDepartment();
            Console.Clear();

            Console.WriteLine("*** Department List ***\n");

            foreach (var deparment in departments)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID deparment    : {0}", deparment.Id);
                Console.WriteLine("Name            : {0}", deparment.Name);
                Console.WriteLine("Street Address  : {0}", deparment.StreetAddress);
                Console.WriteLine("Manager         : {0}", deparment.ManagerName);
                Console.WriteLine("===========================");
            }


            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            GeneralView.HomePage();


        }
    }
}
