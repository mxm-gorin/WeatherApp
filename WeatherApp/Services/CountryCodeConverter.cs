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
                throw new ArgumentException("Must be two letters.");
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

            throw new ArgumentException("Could not get country name.");
        }

        public static string ConvertNameToTwoLetterCode(string countryName)
        {
            if (countryName == null)
            {
                throw new ArgumentException("Must be a country name.");
            }

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (region.EnglishName.ToUpper() == countryName.ToUpper())
                {
                    return region.TwoLetterISORegionName;
                }
            }

            throw new ArgumentException("Could not get country code");
        }
    }
}