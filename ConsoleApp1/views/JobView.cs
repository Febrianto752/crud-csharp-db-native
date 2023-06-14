using ConsoleApp1.models;
using ConsoleApp1.objects;

namespace ConsoleApp1.views
{
    class JobView
    {
        public static void JobList()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<Job> jobs = JobModel.FindAllJob();
            Console.Clear();

            Console.WriteLine("*** Country List ***\n");

            foreach (var job in jobs)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID job      : {0}", job.Id);
                Console.WriteLine("Title       : {0}", job.Title);
                Console.WriteLine("Min Salary  : {0}", job.MinSalary);
                Console.WriteLine("Max Salary  : {0}", job.MaxSalary);
                Console.WriteLine("===========================");
            }


            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            GeneralView.HomePage();


        }

    }
}
