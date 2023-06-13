namespace ConsoleApp1.utils
{
    class Validation
    {
        public static bool MustBeTwoChar(string countryId)
        {
            if (countryId.Length == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
