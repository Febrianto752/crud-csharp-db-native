using ConsoleApp1.models;

namespace ConsoleApp1.views
{
    class CountryView
    {
        public static void CountryList()
        {
            Console.Clear();
            List<Country> countries = CountryModel.FindAllCountry();

            Console.WriteLine("*** Country List ***\n");

            foreach (var country in countries)
            {
                Console.WriteLine("===========================");
                Console.WriteLine("ID country : {0}", country.Id);
                Console.WriteLine("Country Name : {0}", country.Name);
                Console.WriteLine("Country Region : {0}", country.RegionName);
                Console.WriteLine("===========================");
            }

            Console.WriteLine("\n\nMain menu : ");
            Console.WriteLine("1. Create Country");
            Console.WriteLine("2. Search Country");
            Console.WriteLine("3. Edit Country");
            Console.WriteLine("4. Delete Country");
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
                CountryList();
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
                    CountryList();
                    break;
            }

        }

        public static void CreateRegion()
        {
            Console.Clear();
            Console.WriteLine("*** Create Country ***");
            Console.Write("Country Name : ");
            string regionName = Console.ReadLine();

            int affectedRows = CountryModel.Create(regionName);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull created region!!!");
                Console.ReadKey();
                CountryList();
            }
            else
            {
                Console.WriteLine("Failed to created region!!!");
                Console.ReadKey();
                CountryList();
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

            Region region = CountryModel.FindOneRegion(regionId);

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

            int affectedRows = CountryModel.Update(regionId, regionName);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull updated region!!!");
                Console.ReadKey();
                CountryList();
            }
            else
            {
                Console.WriteLine("Failed to updated region!!!");
                Console.ReadKey();
                CountryList();
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

            int affectedRows = CountryModel.Delete(regionId);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull deleted region!!!");
                Console.ReadKey();
                CountryList();
            }
            else
            {
                Console.WriteLine("Failed to deleted region!!!");
                Console.ReadKey();
                CountryList();
            }


        }
    }
}
