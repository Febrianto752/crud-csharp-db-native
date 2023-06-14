using ConsoleApp1.models;
using ConsoleApp1.objects;

namespace ConsoleApp1.views
{
    class HistoryView
    {

        public static void HistoryList()
        {
            Console.Clear();
            Console.WriteLine("Loading...");

            List<History> histories = HistoryModel.FindAllHistory();
            Console.Clear();

            Console.WriteLine("*** History List ***\n");

            foreach (var history in histories)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("Start Date   : {0}", history.StartDate);
                Console.WriteLine("Employee ID  : {0}", history.EmployeeId);
                Console.WriteLine("End Date     : {0}", history.EndDate);
                Console.WriteLine("Job ID       : {0}", history.JobId);
                Console.WriteLine("===========================");
            }


            Console.WriteLine("\nPress any key for back!");
            Console.ReadLine();
            GeneralView.HomePage();


        }
    }
}
