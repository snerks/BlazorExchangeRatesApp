using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp31.Services
{
    public class CurrencyIsoCodeService
    {
        private static IDictionary<string, RegionInfo> map;

        public CurrencyIsoCodeService()
        {
            map = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                //.Select(culture => {
                //    try
                //    {
                //        return new RegionInfo(culture.Name);
                //    }
                //    catch
                //    {
                //        return null;
                //    }
                //})
                .Select(culture => string.IsNullOrWhiteSpace(culture.Name) ? null : new RegionInfo(culture.Name))
                .Where(ri => ri != null)
                .GroupBy(ri => ri.ISOCurrencySymbol)
                //.ToDictionary(x => x.Key, x => x.First().CurrencySymbol);
                .ToDictionary(x => x.Key, x => x.First());
        }

        public bool TryGetCurrencyRegionInfo(
                              string isoCurrencyCode,
                              out RegionInfo regionInfo)
        {
            var wasRegionFound = map.TryGetValue(isoCurrencyCode, out RegionInfo regionInfoInner);

            if (wasRegionFound)
            {
                regionInfo = regionInfoInner;
                return true;
            }

            regionInfo = null;
            return false;
        }
    }
}
