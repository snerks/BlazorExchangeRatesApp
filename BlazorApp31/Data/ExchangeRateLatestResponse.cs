using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp31.Data
{
    public class ExchangeRateLatestResponse
    {
        public Dictionary<string, decimal> Rates { get; set; } = new Dictionary<string, decimal>();

        public string Base { get; set; }
        public DateTime Date { get; set; }
    }

    //public class ExchangeRate
    //{
    //    public string CurrencyIsoCode { get; set; }
    //    public decimal Value { get; set; }
    //}
}
