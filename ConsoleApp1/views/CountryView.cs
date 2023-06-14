using ConsoleApp1.models;
using ConsoleApp1.objects;
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
                Console.WriteLine("ID country     : {0}", country.Id);
                Console.WriteLine("Country Name   : {0}", country.Name);
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
                    SearchCountry();
                    break;
                case 3:
                    EditCountry();
                    break;
                case 4:
                    DeleteCountry();
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

        public static void SearchCountry()
        {
            Console.Clear();
            Console.WriteLine("*** Search Region By Id ***");
            Console.Write("Enter country id : ");

            string countryId = Console.ReadLine().ToUpper();

            Country country = CountryModel.FindCountry(countryId);

            Console.Clear();
            Console.WriteLine("*** Region Detail ***");
            Console.WriteLine("ID : {0}", country.Id);
            Console.WriteLine("Country Name : {0}", country.Name);
            Console.WriteLine("Region Name : {0}", country.RegionName);
            Console.ReadKey();
            CountryList();
        }

        public static void EditCountry()
        {
            Console.Clear();
            Console.WriteLine("*** Edit Country ***");
            Console.Write("Enter country id : ");

            string countryId = Console.ReadLine().ToUpper();

            Country country = CountryModel.FindCountry(countryId);

            if (country.Id is null)
            {
                Console.WriteLine("country not found!!!");
                Console.ReadKey();
                CountryList();
            }

            Console.Clear();
            Console.WriteLine("*** Edit Country ***");
            Console.Write("Country name : ");
            string regionName = Console.ReadLine();

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

            int affectedRows = CountryModel.Update(countryId, regionName, pilihanRegion);

            if (affectedRows > 0)
            {
                Console.WriteLine("Successfull updated country!!!");
                Console.ReadKey();
                CountryList();
            }
            else
            {
                Console.WriteLine("Failed to updated country!!!");
                Console.ReadKey();
                CountryList();
            }
        }

        public static void DeleteCountry()
        {
            Console.Clear();
            Console.WriteLine("*** Delete Country ***");
            Console.Write("Enter country id : ");

            string countryId = Console.ReadLine().ToUpper();

            Country country = CountryModel.FindCountry(countryId);

            if (country.Id is not null)
            {
                int affectedRows = CountryModel.Delete(countryId);

                if (affectedRows > 0)
                {
                    Console.WriteLine("Successfull deleted country!!!");
                    Console.ReadKey();
                    CountryList();
                }
                else
                {
                    Console.WriteLine("Failed to deleted country!!!");
                    Console.ReadKey();
                    CountryList();
                }
            }
            else
            {
                Console.WriteLine("country is not found!!!");
                Console.ReadLine();
                CountryList();
            }

        }
    }
}
