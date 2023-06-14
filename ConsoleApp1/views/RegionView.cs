using ConsoleApp1.models;
using ConsoleApp1.objects;

namespace ConsoleApp1.views
{
    class RegionView
    {
        public static void RegionList()
        {
            Console.Clear();
            List<Region> regions = RegionModel.FindAllRegion();

            Console.WriteLine("*** Region List ***\n");

            foreach (var region in regions)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID Region : {0}", region.Id);
                Console.WriteLine("Region Name : {0}", region.Name);
                Console.WriteLine("===========================");
            }

            Console.WriteLine("\n\nMain menu : ");
            Console.WriteLine("1. Create Region");
            Console.WriteLine("2. Search Region");
            Console.WriteLine("3. Edit Region");
            Console.WriteLine("4. Delete Region");
            Console.WriteLine("5. Back");
            Console.WriteLine("*************");
            Console.Write("Pilihan : ");


            int pilihan = default;

            try
            {
                pilihan = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid choice input : ");
                Console.ReadKey();
                RegionList();
            }

            switch (pilihan)
            {
                case 1:
                    CreateRegion();
                    break;
                case 2:
                    SearchRegion();
                    break;
                case 3:
                    EditRegion();
                    break;
                case 4:
                    DeleteRegion();
                    break;
                case 5:
                    GeneralView.HomePage();
                    break;
                default:
                    Console.WriteLine("Invalid choice input!!!");
                    Console.ReadKey();
                    RegionList();
                    break;
            }

        }

        public static void CreateRegion()
        {
            Console.Clear();
            Console.WriteLine("*** Create Region ***");
            Console.Write("Region Name : ");
            string regionName = Console.ReadLine();

            int affectedRows = RegionModel.Create(regionName);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull created region!!!");
                Console.ReadKey();
                RegionList();
            }
            else
            {
                Console.WriteLine("Failed to created region!!!");
                Console.ReadKey();
                RegionList();
            }
        }

        public static void SearchRegion()
        {
            Console.Clear();
            Console.WriteLine("*** Search Region By Id ***");
            Console.Write("Enter region id : ");

            int regionId = default;

            try
            {
                regionId = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid region id input!!!");
                Console.ReadKey();
                SearchRegion();
            }

            Region region = RegionModel.FindOneRegion(regionId);

            Console.Clear();
            Console.WriteLine("*** Region Detail ***");
            Console.WriteLine("ID : {0}", region.Id);
            Console.WriteLine("Region Name : {0}", region.Name);
            Console.ReadKey();
            GeneralView.HomePage();
        }

        public static void EditRegion()
        {
            Console.Clear();
            Console.WriteLine("*** Edit Region ***");
            Console.Write("Enter region id : ");

            int regionId = default;

            try
            {
                regionId = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid region id input!!!");
                Console.ReadKey();
                EditRegion();
            }

            Console.Clear();
            Console.WriteLine("*** Edit Region ***");
            Console.Write("Region name : ");
            string regionName = Console.ReadLine();

            int affectedRows = RegionModel.Update(regionId, regionName);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull updated region!!!");
                Console.ReadKey();
                RegionList();
            }
            else
            {
                Console.WriteLine("Failed to updated region!!!");
                Console.ReadKey();
                RegionList();
            }
        }

        public static void DeleteRegion()
        {
            Console.Clear();
            Console.WriteLine("*** Delete Region ***");
            Console.Write("Enter region id : ");

            int regionId = default;

            try
            {
                regionId = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid region id input!!!");
                Console.ReadKey();
                DeleteRegion();
            }

            int affectedRows = RegionModel.Delete(regionId);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull deleted region!!!");
                Console.ReadKey();
                RegionList();
            }
            else
            {
                Console.WriteLine("Failed to deleted region!!!");
                Console.ReadKey();
                RegionList();
            }
        }
    }
}
