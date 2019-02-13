using System;
using System.Globalization;

namespace WeatherApp.Services
{
    public static class CountryCodeConverter
    {
        public static string ConvertTwoLetterCodeToName(string twoLetterCountryCode)
        {
            if (twoLetterCountryCode == null || twoLetterCountryCode.Length != 2)
            {
                throw new ArgumentException("name must be three letters.");
            }

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (region.TwoLetterISORegionName.ToUpper() == twoLetterCountryCode.ToUpper())
                {
                    return region.EnglishName;
                }
            }

            throw new ArgumentException("Could not get country code");
        }
    }
}