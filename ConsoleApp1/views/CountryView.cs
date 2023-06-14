using ConsoleApp1.models;
using ConsoleApp1.utils;

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
                    CreateCountry();
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

        public static void CreateCountry()
        {
            Console.Clear();
            Console.WriteLine("*** Create Country ***");
            Console.Write("Country id (2 characters) : ");
            string countryId = Console.ReadLine().ToUpper();
            Console.Write("Country Name : ");
            string countryName = Console.ReadLine();

            List<Region> regions = RegionModel.FindAllRegion();
            Console.WriteLine("Pilihan region : ");
            int i = 1;
            foreach (Region region in regions)
            {
                Console.WriteLine($"{i}. {region.Name}");
                i++;
            }

            Console.Write($"region (1 - {i - 1}) : ");

            int pilihanRegion = default;

            // validation pilihan region input
            try
            {
                pilihanRegion = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid choice region input!!!");
                Console.ReadKey();
                CountryList();
            }

            if (pilihanRegion > i - 1 || pilihanRegion < 1)
            {
                Console.WriteLine("Pilihan tidak tersedia!!!");
                Console.ReadKey();
                CountryList();
            }

            // validation id country
            bool validId = Validation.MustBeTwoChar(countryId);





            if (validId)
            {
                Country country = CountryModel.FindCountry(countryId);

                if (country.Id is null)
                {
                    int affectedRows = CountryModel.Create(countryId, countryName, regions[pilihanRegion].Id);

                    if (affectedRows > 0)
                    {
                        Console.WriteLine("Successfull created country!!!");
                        Console.ReadKey();
                        CountryList();
                    }
                    else
                    {
                        Console.WriteLine("Failed to created country!!!");
                        Console.ReadKey();
                        CountryList();
                    }
                }
                else
                {
                    Console.WriteLine("country id already exist!!!");
                    Console.ReadKey();
                    CountryList();
                }


            }
            else
            {
                Console.WriteLine("country id must be 2 characthers");
                Console.ReadKey();
                CountryList();
            }



        }

        public static void SearchRegion()
        {
            Console.Clear();
            Console.WriteLine("*** Search Region By Id ***");
            Console.Write("Enter region id : ");

            string countryId = Console.ReadLine();

            Country country = CountryModel.FindCountry(countryId);

            Console.Clear();
            Console.WriteLine("*** Region Detail ***");
            Console.WriteLine("ID : {0}", country.Id);
            Console.WriteLine("Region Name : {0}", country.Name);
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
