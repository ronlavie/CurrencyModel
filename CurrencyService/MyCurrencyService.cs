using CurrencyBL;
using CurrencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyService
{
    public class MyCurrencyService : ICurrencyService
    {
        public CurrencyList GetAllCurrencies()
        {
            CurrencyManager manager = new CurrencyManager();
            return manager.GetCurrencyList();
        }

        public double Convert(Currency source, Currency dest, double amount)
        {
            CurrencyManager manager = new CurrencyManager();
            return manager.convert(source, dest, amount);
        }
    }


}
